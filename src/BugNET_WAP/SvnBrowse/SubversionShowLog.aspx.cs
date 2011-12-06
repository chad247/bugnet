using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;
using BugNET.BLL;
using BugNET.Entities;

namespace BugNET.SvnBrowse
{
    public partial class SubversionShowLog : BugNET.UserInterfaceLayer.BasePage
    {
        private static Dictionary<int, string> errors = new Dictionary<int, string>();
      
        DataTable dt ;       
        private string  singleLog = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                DataColumn column;
                string svnUrl = "";
                
                if (Request.QueryString["pid"] != null)
                {
                    ProjectId = Convert.ToInt32(Request.QueryString["pid"]);
                    Project proj = ProjectManager.GetById(ProjectId);
                    svnUrl = proj.SvnRepositoryUrl;  
                    //在线程中保存svn地址
                    Session.Add("SvnUrl", svnUrl);
                }             

                dt = new DataTable("Log");

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Rev";
                column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Log";
                column.ReadOnly = true;

                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "Date";
                column.ReadOnly = true;

                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "User";
                column.ReadOnly = true;

                dt.Columns.Add(column);

                SvnReadLog(svnUrl);
                
                SvnLog.DataSource = dt;
                SvnLog.DataBind();
            }
        }

        protected void SvnReadLog(string svnUrl)
        {
            string command = "svn";
            string args = string.Format("--username {0} --password {1} --non-interactive --trust-server-cert log {2}", "admin", "jinyaoshi", svnUrl);
            //string command = "cmd";
            //string args = "dir";          

            Process proc = null;

            ProcessStartInfo startInfo = new ProcessStartInfo(command, args);
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            //startInfo.RedirectStandardError = true;
            

            try
            {
                proc = new Process();
                proc.StartInfo = startInfo;
                proc.OutputDataReceived += new DataReceivedEventHandler(proc_OutputDataReceived);
                proc.Start();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

            proc.BeginOutputReadLine();   

            proc.WaitForExit();
        }

        void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                string s = e.Data;

                if (s.IndexOf("------") == 0)
                {
                    if (string.IsNullOrEmpty(singleLog)) return;
                    var lines = singleLog.Split(new char[]{'|','\r'});

                    if (lines.Length == 5)
                    {
                        DataRow dr = dt.NewRow();
                        dr["rev"] = lines[0];
                        //dr["date"] = DateTime.Parse(lines[1].Substring(0,lines[1].IndexOf('(') - 1));
                        dr["user"] = lines[1];
                        dr["date"] = DateTime.Parse(lines[2].Substring(0, lines[2].IndexOf('(') - 1));
                        dr["log"] = lines[4];

                        dt.Rows.Add(dr);
                    }
                    singleLog = "";
                }
                else
                {
                    char t = ' ';
                    if (singleLog =="") t = '|';
                    
                    singleLog += e.Data + t;
                }

            }
        }

        public static string RunCommand(string command, string args, int killAfterSeconds, bool echoCommand)
        {
            Process proc = null;
            log4net.ILog logger = log4net.LogManager.GetLogger("CommandExecutor");

            if (logger.IsDebugEnabled) logger.DebugFormat("Running Commandline: {0} {1}", command, args);

            try
            {
                var startInfo = new ProcessStartInfo(command, args);
                startInfo.CreateNoWindow = true;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;

                
                proc = new Process();
                proc.StartInfo = startInfo;
                proc.ErrorDataReceived += new DataReceivedEventHandler(CommandProcess_ErrorDataReceived);
                proc.Start();

                proc.BeginErrorReadLine();

                string retVal = proc.StandardOutput.ReadToEnd();                

                if (!proc.WaitForExit(killAfterSeconds * 1000))
                    proc.Kill();

                if (errors.ContainsKey(proc.Id))
                    retVal += Environment.NewLine + "Error: " + Environment.NewLine + errors[proc.Id];

                if (echoCommand)
                {
                    // hide password from being displayed
                    Regex RegexObj = new Regex("--password\\s+\\S+\\s", RegexOptions.IgnoreCase);
                    args = RegexObj.Replace(args, "--password **** ");


                    return command + " " + args + Environment.NewLine + retVal;
                }
                else
                {
                    return retVal;
                }

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("An error occurred running the command line: {2} {3}\n\n {0} \n\n {1}", ex.Message, ex.StackTrace, command, args);
                return string.Empty;
            }
            finally
            {
                if (proc != null)
                {
                    if (errors.ContainsKey(proc.Id))
                        errors.Remove(proc.Id);

                    proc.Dispose();
                }
            }

        }

        static void CommandProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            // RC: Sometimes an error occurres in here. I think the process is ending while we are getting the data, but Im not sure.
            // I'm stuffing it for now.
            try
            {
                if (sender != null)
                {
                    if (e.Data != null && e.Data.Length > 0)
                    {
                        int id = ((Process)sender).Id;

                        if (errors.ContainsKey(id))
                            errors[id] += Environment.NewLine + e.Data;
                        else
                            errors.Add(id, e.Data);
                    }
                }
            }
            catch { }
        }

    }
}
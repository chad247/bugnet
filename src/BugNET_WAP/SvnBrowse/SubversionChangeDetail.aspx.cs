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
    public partial class SubversionChangeDetail : BugNET.UserInterfaceLayer.BasePage
    {
        private static Dictionary<int, string> errors = new Dictionary<int, string>();
        DataTable dt;
        private string singleLog = "";
        private string SvnUser = "admin";
        private string SvnPassWord = "jinyaoshi";
        private string SvnUrl = "";
        private string SvnBugTragMessage = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                DataColumn column;
                string rev = "";
                if (Request.QueryString["pid"] != null)
                {
                    ProjectId = Convert.ToInt32(Request.QueryString["pid"]);
                    Project proj = ProjectManager.GetById(ProjectId);
                    SvnUrl = proj.SvnRepositoryUrl;
                }
                else return;             
                if (Request.QueryString["id"] == null) return;
                rev = Request.QueryString["id"] ;                             

                dt = new DataTable("Log");

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Rev";
                column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Change";
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

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Log";
                column.ReadOnly = true;
                dt.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "BugId";
                column.ReadOnly = true;
                dt.Columns.Add(column);

                string command = "svn";
                string args = string.Format("--username {0} --password {1} --non-interactive --trust-server-cert log {2} -v -r {3}", SvnUser, SvnPassWord, SvnUrl,rev);

                singleLog=SvnReadLog(command,args);
                SvnBugTragMessage = SvnReadBugTragMessage();

                SvnChangeLog();
                
                ChangeView.DataSource = dt;
                ChangeView.DataBind();
            }
        }

        protected string SvnReadLog(string command,string args)
        {            
            //string args = string.Format("--username {0} --password {1} --non-interactive --trust-server-cert log {2}", "admin", "jinyaoshi", svnUrl);
            //string command = "cmd";
            //string args = "dir";
            string returnVal;

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
                //proc.OutputDataReceived += new DataReceivedEventHandler(proc_OutputDataReceived);
                proc.Start();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

            returnVal = proc.StandardOutput.ReadToEnd();
          
            proc.WaitForExit();

            return returnVal;            
        }

        protected void SvnChangeLog()
        {
            if (singleLog.Length < 0) return;

            singleLog = singleLog.Substring(singleLog.IndexOf("--------\r\n") + 10, singleLog.IndexOf("\r\n--------") - singleLog.IndexOf("--------\r\n") - 10);
            var lines = singleLog.Split(new char[] { '|'});
            DataRow dr = dt.NewRow();
            dr["rev"] = lines[0];
            dr["user"] = lines[1];
            dr["date"] = DateTime.Parse(lines[2].Substring(0, lines[2].IndexOf('(') - 1));
            string s = lines[3];
            dr["change"] = s.Substring(s.IndexOf("\r\n") + 2, s.IndexOf("\r\n\r\n", s.IndexOf("\r\n")) - s.IndexOf("\r\n") - 2);
            dr["log"] = s.Substring(s.IndexOf("\r\n\r\n") + 4);

            //将问题ID与网页关联起来
           
            dt.Rows.Add(dr);
        }

        protected string SvnReadBugTragMessage()
        {
            //获取问题跟踪属性设置            
            string command = "svn";            
            string args = string.Format("--username {0} --password {1} --non-interactive --trust-server-cert {2} {3} {4}", SvnUser, SvnPassWord, "propget", "bugtraq:message", SvnUrl);

            return SvnReadLog(command, args);            
        }

        void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {          
            string s = e.Data;
            if (string.IsNullOrEmpty(s)) s = "|" ;
            if (s.IndexOf("------") == 0)
            {
                if (string.IsNullOrEmpty(singleLog)) return;
                var lines = singleLog.Split(new char[] { '|' });

                if (lines.Length == 5)
                {
                    DataRow dr = dt.NewRow();
                    dr["rev"] = lines[0];
                    //dr["date"] = DateTime.Parse(lines[1].Substring(0,lines[1].IndexOf('(') - 1));
                    dr["user"] = lines[1];
                    dr["date"] = DateTime.Parse(lines[2].Substring(0, lines[2].IndexOf('(') - 1));
                    dr["change"] = lines[4];
                    dr["log"] = "";

                    dt.Rows.Add(dr);
                }
                singleLog = "";
            }
            else
            {
                char t = ' ';
                if (singleLog == "") t = '|';

                singleLog += s + t + Environment.NewLine;
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

        protected void ChangeView_DataBinding(object sender, EventArgs e)
        {
            //
            
        }
       

    }
}
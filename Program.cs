using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysPing
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathDektop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nameFile = "PING.txt";
           
            string finalPath = Path.Combine(pathDektop, nameFile);

            if (!File.Exists(finalPath))
                File.Create(finalPath);

            while (true)
            {
                string resPing = "";
                string exception = "";
                try
                {
                    resPing = PingGoogle();
                }
                catch (Exception e)
                {
                    exception = e.Message;   
                }
                finally
                {
                    System.Threading.Thread.Sleep(5000);
                    WriteFile(finalPath, resPing, exception);
                }
            }
        }

        static void WriteFile(string finalPath, string resPing, string exception)
        {
            using (StreamWriter sw = File.AppendText(finalPath))
            {
                if (!string.IsNullOrEmpty(resPing))
                    sw.WriteLine(resPing);
                if (!string.IsNullOrEmpty(exception))
                    sw.WriteLine($"ECCEZIONE {DateTime.Now} : " + exception);
            }
        }

        static string PingGoogle()
        {
            string result = "";

            try
            {
                var ping = new Ping();
                var s = "www.google.com";
                var r = ping.Send(s);

                if (r.Status == IPStatus.Success)
                {
                    result = $"{DateTime.Now} Ping to " + s.ToString() + "[" + r?.Address?.ToString() + "]" + " Successful"
                       + " Response delay = " + r?.RoundtripTime.ToString() + " ms" + "\n";
                }
                else
                {
                    result = $"{DateTime.Now} Ping to " + s.ToString() + "[" + r?.Address?.ToString() + "]" + " Failed" +
                        " Status : " + r?.Status +
                       " Response delay = " + r?.RoundtripTime.ToString() + " ms" + "\n";
                }
            }
            catch (Exception e)
            {
                result += $"{DateTime.Now} -- eccezione : {e.Message}";
            }
            return result;
        }
    }
}

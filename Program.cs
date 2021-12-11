using System;
using System.IO;
using System.Net.NetworkInformation;

namespace AlwaysPing
{
    class Program
    {
        static void Main(string[] args)
        {
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
                    try
                    {
                        using (StreamWriter sw = File.AppendText(finalPath))
                        {
                            if (!string.IsNullOrEmpty(resPing))
                                sw.WriteLine(resPing);
                            if (!string.IsNullOrEmpty(exception))
                                sw.WriteLine($"ECCEZIONE {DateTime.Now} : " + exception);
                        }
                    }
                    catch (Exception) { }
                }
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
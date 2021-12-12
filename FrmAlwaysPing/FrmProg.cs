using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmAlwaysPing
{
    public partial class FrmProg : Form
    {
        private CancellationTokenSource _tokenSource;

        public FrmProg()
        {
            InitializeComponent();
            SetSettings();
        }

        private void SetSettings()
        {
            txtPath.Text = Properties.Settings.Default.DefaultPath;
            txtNameFile.Text = Properties.Settings.Default.DefaultFileName;
            txtSitePing.Text = Properties.Settings.Default.DefaultSite;
        }

        private void btnFolderDialog_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };

            DialogResult res = fld.ShowDialog();
            if (res == DialogResult.OK)
            {
                txtPath.Text = fld.SelectedPath;
            }
        }

        private async void btnStartPing_ClickAsync(object sender, System.EventArgs e)
        {
            string ext = Properties.Settings.Default.DefaultExtFile;
            btnStartPing.Visible = false;
            btnStopPing.Visible = true;
            lblPing.Visible = true;
            Application.DoEvents();

            string nameFile = txtNameFile.Text.Trim();
            string path = txtPath.Text.Trim();
            string fullPath = Path.Combine(path, nameFile + ext);

            if (!nameFile.Equals(Properties.Settings.Default.DefaultFileName))
            {
                string pathDefault = Properties.Settings.Default.DefaultPath;
                string fileDefault = Properties.Settings.Default.DefaultFileName;
                string fullPathDefault = Path.Combine(pathDefault, fileDefault + ext);

                if (File.Exists(fullPathDefault))
                    File.Delete(fullPathDefault);
            }

            if (!File.Exists(fullPath))
                File.Create(fullPath).Close();

            if (_tokenSource != null)
                return;

            _tokenSource = new CancellationTokenSource();
            var ct = _tokenSource.Token;

            await Task.Factory.StartNew(() =>
            {
                for (; ; )
                {
                    if (ct.IsCancellationRequested)
                        break;

                    PingAlways(fullPath);

                    Thread.Sleep(5000);
                }
            }, ct);

            _tokenSource = null;
        }

        private void PingAlways(string fullPath)
        {
            Invoke((Action)(() =>
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
                    try
                    {
                        using (StreamWriter sw = File.AppendText(fullPath))
                        {
                            if (!string.IsNullOrEmpty(resPing))
                                sw.WriteLine(resPing);
                            if (!string.IsNullOrEmpty(exception))
                                sw.WriteLine($"ECCEZIONE {DateTime.Now} : " + exception);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Eccezione : {e.Message} riavviare il programma.");
                    }
                }
            }));
        }

        private void btnStopPing_Click(object sender, EventArgs e)
        {
            if (_tokenSource == null)
                return;

            _tokenSource.Cancel();

            ResetForm();
        }

        private void ResetForm()
        {
            btnStopPing.Visible = false;
            btnStartPing.Visible = true;
            lblPing.Visible = false;
            Application.DoEvents();
        }

        private string PingGoogle()
        {
            string result = "";

            try
            {
                var ping = new Ping();
                var s = txtSitePing.Text.Trim();
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
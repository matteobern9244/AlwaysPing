using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrmAlwaysPing.Properties;

namespace FrmAlwaysPing
{
    public partial class FrmProg : Form
    {
        private CancellationTokenSource _tokenSource;

        public FrmProg()
        {
            InitializeComponent();
            SetDefaultSettings();
        }

        private void SetDefaultSettings()
        {
            txtPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            txtNameFile.Text = Settings.Default.DefaultFileName;
            txtSitePing.Text = Settings.Default.DefaultSite;
        }

        private void btnFolderDialog_Click(object sender, EventArgs e)
        {
            var fld = new FolderBrowserDialog { ShowNewFolderButton = true };

            if (fld.ShowDialog() == DialogResult.OK) 
                txtPath.Text = fld.SelectedPath;
        }


        private async void btnStartPing_ClickAsync(object sender, EventArgs e)
        {
            var extFile = Settings.Default.DefaultExtFile;

            if (btnStartPing != null) btnStartPing.Visible = false;
            if (btnStopPing != null) btnStopPing.Visible = true;
            if (lblPing != null) lblPing.Visible = true;

            Application.DoEvents();

            if (txtNameFile != null)
            {
                var nameFile = txtNameFile.Text.Trim();
                if (txtPath != null)
                {
                    var path = txtPath.Text.Trim();
                    {
                        var fullPath = Path.Combine(path, $"{nameFile}{extFile}");

                        if (!nameFile.Equals(Settings.Default.DefaultFileName))
                        {
                            var pathDefault = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                            var fileDefault = Settings.Default.DefaultFileName;
                            var fullPathDefault = Path.Combine(pathDefault, fileDefault + extFile);

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
                            for (; ;)
                            {
                                if (ct.IsCancellationRequested)
                                    break;

                                PingAlways(fullPath);

                                Thread.Sleep(5000);
                            }
                        }, ct);
                    }
                }
            }

            _tokenSource = null;
        }

        private void PingAlways(string fullPath)
        {
            Invoke((Action)(() =>
            {
                var resPing = "";
                var exception = "";
                try
                {
                    resPing = PingToSite();
                }
                catch (Exception e)
                {
                    exception = e.Message;
                }
                finally
                {
                    try
                    {
                        using (var sw = File.AppendText(fullPath))
                        {
                            if (!string.IsNullOrEmpty(resPing))
                                sw.WriteLine(resPing);
                            if (!string.IsNullOrEmpty(exception))
                                sw.WriteLine($"ECCEZIONE {DateTime.Now} : " + exception);
                        }
                    }
                    catch (Exception e)
                    {
                        if (e.Message != null) MessageBox.Show($@"Eccezione : {e.Message} riavviare il programma.");
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
            if (btnStopPing != null) btnStopPing.Visible = false;
            if (btnStartPing != null) btnStartPing.Visible = true;
            if (lblPing != null) lblPing.Visible = false;

            Application.DoEvents();
        }

        private string PingToSite()
        {
            var result = string.Empty;

            try
            {
                var textSitePing = txtSitePing.Text;
                if (!string.IsNullOrEmpty(textSitePing))
                {
                    textSitePing = textSitePing.Trim();

                    var pingReply = new Ping().Send(textSitePing);
                    if (pingReply != null && pingReply.Status == IPStatus.Success)
                    {
                        result = $"{DateTime.Now} Ping to " + textSitePing + " Successful" + 
                                 " Response delay = " + (pingReply.RoundtripTime) + " ms" + "\n";
                    }
                    else
                    {
                        if (pingReply != null)
                            result = $"{DateTime.Now} Ping to " + textSitePing + " Failed" +
                                     " Status : " + pingReply.Status +
                                     " Response delay = " + pingReply.RoundtripTime + " ms" + "\n";
                    }
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
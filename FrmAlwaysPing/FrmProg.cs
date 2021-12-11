using System.IO;
using System.Windows.Forms;

namespace FrmAlwaysPing
{
    public partial class FrmProg : Form
    {
        public FrmProg()
        {
            InitializeComponent();
            ControlFile();
        }

        private void ControlFile()
        {
            var path = Properties.Settings.Default.DefaultPath;
            var file = Properties.Settings.Default.FileName;
            var finalPath = Path.Combine(path, file);
            if (!File.Exists(finalPath))
                File.Create(finalPath);
        }
    }
}

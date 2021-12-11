using System;
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
            var path = Properties.Settings.Default.FinalPath;
            var file = Properties.Settings.Default.NameFile;
            var finalPath = Path.Combine(path, file);
            if (!File.Exists(finalPath))
                File.Create(finalPath);             
        }
    }
}

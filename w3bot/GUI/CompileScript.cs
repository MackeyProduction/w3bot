using System;
using System.Windows.Forms;
using w3bot.Core.Script;

namespace w3bot.GUI
{
    public partial class CompileScript : Form
    {
        private static Scriptloader _scriptLoader;

        public CompileScript()
        {
            InitializeComponent();

            _scriptLoader = new Scriptloader();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            _scriptLoader.CompileScriptFromWWW(tbUrl.Text);
        }

        private void rbFromDirectory_CheckedChanged(object sender, EventArgs e)
        {
            lblUrl.Enabled = false;
            tbUrl.Enabled = false;
            btnDownload.Enabled = false;
            btnCompile.Enabled = true;
        }

        private void rbDownload_CheckedChanged(object sender, EventArgs e)
        {
            lblUrl.Enabled = true;
            tbUrl.Enabled = true;
            btnDownload.Enabled = true;
            btnCompile.Enabled = false;
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            _scriptLoader.CompileScripts();
        }
    }
}

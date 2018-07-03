using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace APKAuthTool
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
            openFileDialog_APK.InitialDirectory = Application.StartupPath;
        }

        private void button_Open_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog_APK.ShowDialog())
            {
                textBox_APK.Text = openFileDialog_APK.FileName;
            }
        }

        private void button_Auth_Click(object sender, EventArgs e)
        {
            X509Certificate2 cert = new X509Certificate2("MPS_APK_AUTH.pfx", "Zqmh1234");
            RSA key = RSACertificateExtensions.GetRSAPrivateKey(cert);
            //key.SignData()
            
        }
    }
}

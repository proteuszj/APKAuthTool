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
using System.IO;
using Common;

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
            FileStream fs = new FileStream(textBox_APK.Text, FileMode.Open);
            byte[] hash = HashAlgorithm.Create("SHA1").ComputeHash(fs);
            fs.Close();

            string signData = new ByteArray(hash).ToHexString();
            string authExpireString = dateTimePicker_AuthExpire.Checked ? dateTimePicker_AuthExpire.Value.ToString("yyyyMMdd") : "00000000";
            signData += authExpireString;

            byte[] data = new ByteArray(signData, ByteArray.StringEncodingTypeEnum.ASCII).Data;
            byte[] value = key.SignData(data, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);

            //wirte to file
            StreamWriter sw = new StreamWriter(textBox_APK.Text + ".sign");
            sw.WriteLine("Expire: " + authExpireString);
            sw.WriteLine("Signature: "+ Convert.ToBase64String(value));
            //sw.WriteLine(new ByteArray(value).ToHexString());
            sw.Close();

            MessageBox.Show("授权文件生成成功");
        }
    }
}

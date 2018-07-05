
using Common;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace APKAuthTool
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();

            string productName = ((AssemblyProductAttribute)Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyProductAttribute))).Product;
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string fileVersion = ((AssemblyFileVersionAttribute)Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyFileVersionAttribute))).Version;
            Text = $"{productName} v{version}";

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
            string signFileName = textBox_APK.Text + ".sign";
            StreamWriter sw = new StreamWriter(signFileName);
            sw.WriteLine("Expire: " + authExpireString);
            sw.WriteLine("Signature: " + Convert.ToBase64String(value));
            //sw.WriteLine(new ByteArray(value).ToHexString());
            sw.Close();

            MessageBox.Show($"授权文件-{signFileName}-生成成功","信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox_APK_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string fileName = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                textBox_APK.Text = fileName;
            }
        }

        private void textBox_APK_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string fileName = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                if (new FileInfo(fileName).Extension.ToUpper() == ".APK")
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }
    }
}

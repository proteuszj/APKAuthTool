namespace APKAuthTool
{
    partial class Form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog_APK = new System.Windows.Forms.OpenFileDialog();
            this.textBox_APK = new System.Windows.Forms.TextBox();
            this.button_Auth = new System.Windows.Forms.Button();
            this.button_Open = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog_APK
            // 
            this.openFileDialog_APK.DefaultExt = "apk";
            this.openFileDialog_APK.Filter = "APK文件|*.apk|所有文件|*.*";
            // 
            // textBox_APK
            // 
            this.textBox_APK.Location = new System.Drawing.Point(145, 81);
            this.textBox_APK.Name = "textBox_APK";
            this.textBox_APK.Size = new System.Drawing.Size(534, 31);
            this.textBox_APK.TabIndex = 1;
            // 
            // button_Auth
            // 
            this.button_Auth.Location = new System.Drawing.Point(685, 76);
            this.button_Auth.Name = "button_Auth";
            this.button_Auth.Size = new System.Drawing.Size(103, 39);
            this.button_Auth.TabIndex = 2;
            this.button_Auth.Text = "授权";
            this.button_Auth.UseVisualStyleBackColor = true;
            this.button_Auth.Click += new System.EventHandler(this.button_Auth_Click);
            // 
            // button_Open
            // 
            this.button_Open.Location = new System.Drawing.Point(12, 76);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(127, 39);
            this.button_Open.TabIndex = 3;
            this.button_Open.Text = "打开APK";
            this.button_Open.UseVisualStyleBackColor = true;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 210);
            this.Controls.Add(this.button_Open);
            this.Controls.Add(this.button_Auth);
            this.Controls.Add(this.textBox_APK);
            this.Name = "Form_Main";
            this.Text = "APK授权工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog_APK;
        private System.Windows.Forms.TextBox textBox_APK;
        private System.Windows.Forms.Button button_Auth;
        private System.Windows.Forms.Button button_Open;
    }
}


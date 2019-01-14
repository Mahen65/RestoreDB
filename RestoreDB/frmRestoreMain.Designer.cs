namespace RestoreDB
{
    partial class frmRestoreMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectData = new System.Windows.Forms.Button();
            this.txtDataPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.btnSelectLog = new System.Windows.Forms.Button();
            this.btnSelectBackUp = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnSelectData
            // 
            this.btnSelectData.Location = new System.Drawing.Point(598, 49);
            this.btnSelectData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSelectData.Name = "btnSelectData";
            this.btnSelectData.Size = new System.Drawing.Size(28, 27);
            this.btnSelectData.TabIndex = 0;
            this.btnSelectData.Text = "...";
            this.btnSelectData.UseVisualStyleBackColor = true;
            this.btnSelectData.Click += new System.EventHandler(this.btnSelectData_Click);
            // 
            // txtDataPath
            // 
            this.txtDataPath.AccessibleName = "Data Path";
            this.txtDataPath.Location = new System.Drawing.Point(102, 52);
            this.txtDataPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDataPath.Name = "txtDataPath";
            this.txtDataPath.ReadOnly = true;
            this.txtDataPath.Size = new System.Drawing.Size(487, 23);
            this.txtDataPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data Folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Log Folder";
            // 
            // txtLogPath
            // 
            this.txtLogPath.AccessibleName = "Log Path";
            this.txtLogPath.Location = new System.Drawing.Point(102, 91);
            this.txtLogPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.ReadOnly = true;
            this.txtLogPath.Size = new System.Drawing.Size(487, 23);
            this.txtLogPath.TabIndex = 4;
            // 
            // btnSelectLog
            // 
            this.btnSelectLog.Location = new System.Drawing.Point(598, 87);
            this.btnSelectLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSelectLog.Name = "btnSelectLog";
            this.btnSelectLog.Size = new System.Drawing.Size(28, 27);
            this.btnSelectLog.TabIndex = 5;
            this.btnSelectLog.Text = "...";
            this.btnSelectLog.UseVisualStyleBackColor = true;
            this.btnSelectLog.Click += new System.EventHandler(this.btnSelectLog_Click);
            // 
            // btnSelectBackUp
            // 
            this.btnSelectBackUp.Location = new System.Drawing.Point(598, 9);
            this.btnSelectBackUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSelectBackUp.Name = "btnSelectBackUp";
            this.btnSelectBackUp.Size = new System.Drawing.Size(28, 27);
            this.btnSelectBackUp.TabIndex = 8;
            this.btnSelectBackUp.Text = "...";
            this.btnSelectBackUp.UseVisualStyleBackColor = true;
            this.btnSelectBackUp.Click += new System.EventHandler(this.btnSelectBackUp_Click);
            // 
            // txtPath
            // 
            this.txtPath.AccessibleName = "Backup Path";
            this.txtPath.Location = new System.Drawing.Point(102, 12);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(487, 23);
            this.txtPath.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Backup Folder";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 120);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(614, 222);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(537, 387);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(90, 31);
            this.btnRestore.TabIndex = 10;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 348);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(613, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // frmRestoreMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 434);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnSelectBackUp);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSelectLog);
            this.Controls.Add(this.txtLogPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDataPath);
            this.Controls.Add(this.btnSelectData);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmRestoreMain";
            this.Text = "RestoreDB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectData;
        private System.Windows.Forms.TextBox txtDataPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Button btnSelectLog;
        private System.Windows.Forms.Button btnSelectBackUp;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}


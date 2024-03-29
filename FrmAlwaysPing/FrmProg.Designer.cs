﻿namespace FrmAlwaysPing
{
    partial class FrmProg
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameFile = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnFolderDialog = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSitePing = new System.Windows.Forms.TextBox();
            this.btnStartPing = new System.Windows.Forms.Button();
            this.btnStopPing = new System.Windows.Forms.Button();
            this.lblPing = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome file :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Path file :";
            // 
            // txtNameFile
            // 
            this.txtNameFile.Location = new System.Drawing.Point(128, 20);
            this.txtNameFile.Name = "txtNameFile";
            this.txtNameFile.Size = new System.Drawing.Size(367, 30);
            this.txtNameFile.TabIndex = 2;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(128, 56);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(367, 30);
            this.txtPath.TabIndex = 3;
            // 
            // btnFolderDialog
            // 
            this.btnFolderDialog.Location = new System.Drawing.Point(501, 54);
            this.btnFolderDialog.Name = "btnFolderDialog";
            this.btnFolderDialog.Size = new System.Drawing.Size(32, 26);
            this.btnFolderDialog.TabIndex = 4;
            this.btnFolderDialog.Text = "...";
            this.btnFolderDialog.UseVisualStyleBackColor = true;
            this.btnFolderDialog.Click += new System.EventHandler(this.btnFolderDialog_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sito o path :";
            // 
            // txtSitePing
            // 
            this.txtSitePing.Location = new System.Drawing.Point(128, 95);
            this.txtSitePing.Name = "txtSitePing";
            this.txtSitePing.Size = new System.Drawing.Size(405, 30);
            this.txtSitePing.TabIndex = 6;
            // 
            // btnStartPing
            // 
            this.btnStartPing.Location = new System.Drawing.Point(33, 173);
            this.btnStartPing.Name = "btnStartPing";
            this.btnStartPing.Size = new System.Drawing.Size(500, 32);
            this.btnStartPing.TabIndex = 7;
            this.btnStartPing.Text = "START PING";
            this.btnStartPing.UseVisualStyleBackColor = true;
            this.btnStartPing.Click += new System.EventHandler(this.btnStartPing_ClickAsync);
            // 
            // btnStopPing
            // 
            this.btnStopPing.Location = new System.Drawing.Point(33, 173);
            this.btnStopPing.Name = "btnStopPing";
            this.btnStopPing.Size = new System.Drawing.Size(500, 32);
            this.btnStopPing.TabIndex = 8;
            this.btnStopPing.Text = "STOP PING";
            this.btnStopPing.UseVisualStyleBackColor = true;
            this.btnStopPing.Visible = false;
            this.btnStopPing.Click += new System.EventHandler(this.btnStopPing_Click);
            // 
            // lblPing
            // 
            this.lblPing.AutoSize = true;
            this.lblPing.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPing.ForeColor = System.Drawing.Color.Red;
            this.lblPing.Location = new System.Drawing.Point(196, 146);
            this.lblPing.Name = "lblPing";
            this.lblPing.Size = new System.Drawing.Size(180, 24);
            this.lblPing.TabIndex = 9;
            this.lblPing.Text = "PING IN CORSO...";
            this.lblPing.Visible = false;
            // 
            // FrmProg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 217);
            this.Controls.Add(this.lblPing);
            this.Controls.Add(this.btnStopPing);
            this.Controls.Add(this.btnStartPing);
            this.Controls.Add(this.txtSitePing);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFolderDialog);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.txtNameFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmProg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Always Ping";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNameFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnFolderDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSitePing;
        private System.Windows.Forms.Button btnStartPing;
        private System.Windows.Forms.Button btnStopPing;
        private System.Windows.Forms.Label lblPing;
    }
}


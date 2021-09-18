
namespace ScreenNShot
{
    partial class Configuration
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.label_PrintScreen = new System.Windows.Forms.Label();
            this.textBox_PrintScreen = new System.Windows.Forms.TextBox();
            this.button_Edit_PrintScreen = new System.Windows.Forms.Button();
            this.label_SavePDF = new System.Windows.Forms.Label();
            this.textBox_SavePDF = new System.Windows.Forms.TextBox();
            this.button_Edit_SavePDF = new System.Windows.Forms.Button();
            this.label_OutputPath = new System.Windows.Forms.Label();
            this.textBox_OutputPath = new System.Windows.Forms.TextBox();
            this._OutputPath = new System.Windows.Forms.Button();
            this.button_ResetPrintScreen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label_PrintScreen
            // 
            this.label_PrintScreen.AutoSize = true;
            this.label_PrintScreen.Location = new System.Drawing.Point(27, 16);
            this.label_PrintScreen.Name = "label_PrintScreen";
            this.label_PrintScreen.Size = new System.Drawing.Size(70, 15);
            this.label_PrintScreen.TabIndex = 0;
            this.label_PrintScreen.Text = "Print Screen";
            // 
            // textBox_PrintScreen
            // 
            this.textBox_PrintScreen.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_PrintScreen.Location = new System.Drawing.Point(103, 13);
            this.textBox_PrintScreen.Name = "textBox_PrintScreen";
            this.textBox_PrintScreen.ReadOnly = true;
            this.textBox_PrintScreen.Size = new System.Drawing.Size(132, 23);
            this.textBox_PrintScreen.TabIndex = 1;
            // 
            // button_Edit_PrintScreen
            // 
            this.button_Edit_PrintScreen.Location = new System.Drawing.Point(241, 13);
            this.button_Edit_PrintScreen.Name = "button_Edit_PrintScreen";
            this.button_Edit_PrintScreen.Size = new System.Drawing.Size(55, 23);
            this.button_Edit_PrintScreen.TabIndex = 2;
            this.button_Edit_PrintScreen.Text = "Edit";
            this.button_Edit_PrintScreen.UseVisualStyleBackColor = true;
            this.button_Edit_PrintScreen.Click += new System.EventHandler(this.button_Edit_PrintScreen_Click);
            // 
            // label_SavePDF
            // 
            this.label_SavePDF.AutoSize = true;
            this.label_SavePDF.Location = new System.Drawing.Point(11, 45);
            this.label_SavePDF.Name = "label_SavePDF";
            this.label_SavePDF.Size = new System.Drawing.Size(86, 15);
            this.label_SavePDF.TabIndex = 3;
            this.label_SavePDF.Text = "Auto-Save PDF";
            // 
            // textBox_SavePDF
            // 
            this.textBox_SavePDF.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_SavePDF.Location = new System.Drawing.Point(103, 42);
            this.textBox_SavePDF.Name = "textBox_SavePDF";
            this.textBox_SavePDF.ReadOnly = true;
            this.textBox_SavePDF.Size = new System.Drawing.Size(132, 23);
            this.textBox_SavePDF.TabIndex = 4;
            // 
            // button_Edit_SavePDF
            // 
            this.button_Edit_SavePDF.Location = new System.Drawing.Point(241, 42);
            this.button_Edit_SavePDF.Name = "button_Edit_SavePDF";
            this.button_Edit_SavePDF.Size = new System.Drawing.Size(111, 23);
            this.button_Edit_SavePDF.TabIndex = 5;
            this.button_Edit_SavePDF.Text = "Edit";
            this.button_Edit_SavePDF.UseVisualStyleBackColor = true;
            this.button_Edit_SavePDF.Click += new System.EventHandler(this.button_Edit_SavePDF_Click);
            // 
            // label_OutputPath
            // 
            this.label_OutputPath.AutoSize = true;
            this.label_OutputPath.Location = new System.Drawing.Point(25, 74);
            this.label_OutputPath.Name = "label_OutputPath";
            this.label_OutputPath.Size = new System.Drawing.Size(72, 15);
            this.label_OutputPath.TabIndex = 6;
            this.label_OutputPath.Text = "Output Path";
            // 
            // textBox_OutputPath
            // 
            this.textBox_OutputPath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_OutputPath.Location = new System.Drawing.Point(103, 71);
            this.textBox_OutputPath.Name = "textBox_OutputPath";
            this.textBox_OutputPath.ReadOnly = true;
            this.textBox_OutputPath.Size = new System.Drawing.Size(132, 23);
            this.textBox_OutputPath.TabIndex = 7;
            // 
            // _OutputPath
            // 
            this._OutputPath.Location = new System.Drawing.Point(241, 71);
            this._OutputPath.Name = "_OutputPath";
            this._OutputPath.Size = new System.Drawing.Size(111, 23);
            this._OutputPath.TabIndex = 8;
            this._OutputPath.Text = "Browse...";
            this._OutputPath.UseVisualStyleBackColor = true;
            this._OutputPath.Click += new System.EventHandler(this.button_OutputPath_Click);
            // 
            // button_ResetPrintScreen
            // 
            this.button_ResetPrintScreen.Location = new System.Drawing.Point(302, 13);
            this.button_ResetPrintScreen.Name = "button_ResetPrintScreen";
            this.button_ResetPrintScreen.Size = new System.Drawing.Size(50, 23);
            this.button_ResetPrintScreen.TabIndex = 9;
            this.button_ResetPrintScreen.Text = "Reset";
            this.button_ResetPrintScreen.UseVisualStyleBackColor = true;
            this.button_ResetPrintScreen.Click += new System.EventHandler(this.button_ResetPrintScreen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Screen&&Shot by elBandoler. Support on";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(251, 97);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(81, 15);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Bandoler.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 121);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_ResetPrintScreen);
            this.Controls.Add(this._OutputPath);
            this.Controls.Add(this.textBox_OutputPath);
            this.Controls.Add(this.label_OutputPath);
            this.Controls.Add(this.button_Edit_PrintScreen);
            this.Controls.Add(this.textBox_PrintScreen);
            this.Controls.Add(this.label_PrintScreen);
            this.Controls.Add(this.button_Edit_SavePDF);
            this.Controls.Add(this.textBox_SavePDF);
            this.Controls.Add(this.label_SavePDF);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Configuration";
            this.Text = "Screen&Shot - Configuration";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Configuration_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_PrintScreen;
        private System.Windows.Forms.TextBox textBox_PrintScreen;
        private System.Windows.Forms.Button button_Edit_PrintScreen;
        private System.Windows.Forms.Label label_SavePDF;
        private System.Windows.Forms.TextBox textBox_SavePDF;
        private System.Windows.Forms.Button button_Edit_SavePDF;
        private System.Windows.Forms.Label label_OutputPath;
        private System.Windows.Forms.TextBox textBox_OutputPath;
        private System.Windows.Forms.Button _OutputPath;
        private System.Windows.Forms.Button button_ResetPrintScreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}


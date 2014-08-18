namespace WindowsFormsApplication1
{
    partial class ScansPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScansPopup));
            this.btnDism = new System.Windows.Forms.Button();
            this.btnSfc = new System.Windows.Forms.Button();
            this.btnChkdsk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDism
            // 
            this.btnDism.BackColor = System.Drawing.Color.Transparent;
            this.btnDism.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnDism.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDism.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDism.Font = new System.Drawing.Font("Calibri Light", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDism.ForeColor = System.Drawing.Color.White;
            this.btnDism.Location = new System.Drawing.Point(12, 98);
            this.btnDism.Name = "btnDism";
            this.btnDism.Size = new System.Drawing.Size(405, 100);
            this.btnDism.TabIndex = 3;
            this.btnDism.Text = "DISM Scans";
            this.btnDism.UseVisualStyleBackColor = false;
            this.btnDism.Click += new System.EventHandler(this.btnDism_Click);
            // 
            // btnSfc
            // 
            this.btnSfc.BackColor = System.Drawing.Color.Transparent;
            this.btnSfc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnSfc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSfc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSfc.Font = new System.Drawing.Font("Calibri Light", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSfc.ForeColor = System.Drawing.Color.White;
            this.btnSfc.Location = new System.Drawing.Point(12, 222);
            this.btnSfc.Name = "btnSfc";
            this.btnSfc.Size = new System.Drawing.Size(405, 100);
            this.btnSfc.TabIndex = 4;
            this.btnSfc.Text = "SFC Scan";
            this.btnSfc.UseVisualStyleBackColor = false;
            this.btnSfc.Click += new System.EventHandler(this.btnSfc_Click);
            // 
            // btnChkdsk
            // 
            this.btnChkdsk.BackColor = System.Drawing.Color.Transparent;
            this.btnChkdsk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnChkdsk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnChkdsk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChkdsk.Font = new System.Drawing.Font("Calibri Light", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChkdsk.ForeColor = System.Drawing.Color.White;
            this.btnChkdsk.Location = new System.Drawing.Point(12, 346);
            this.btnChkdsk.Name = "btnChkdsk";
            this.btnChkdsk.Size = new System.Drawing.Size(405, 100);
            this.btnChkdsk.TabIndex = 5;
            this.btnChkdsk.Text = "Chkdsk (check disk)";
            this.btnChkdsk.UseVisualStyleBackColor = false;
            this.btnChkdsk.Click += new System.EventHandler(this.btnChkdsk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(115, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "Choose a Scan";
            // 
            // ScansPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(162)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(429, 469);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChkdsk);
            this.Controls.Add(this.btnDism);
            this.Controls.Add(this.btnSfc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScansPopup";
            this.Text = "Choose a Scan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDism;
        private System.Windows.Forms.Button btnSfc;
        private System.Windows.Forms.Button btnChkdsk;
        private System.Windows.Forms.Label label1;
    }
}
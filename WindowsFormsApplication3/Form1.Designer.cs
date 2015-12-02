namespace WindowsFormsApplication3
{
    partial class Form1
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
            this.txt_enr = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_customer = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_po = new System.Windows.Forms.TextBox();
            this.txt_country = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_amm1 = new System.Windows.Forms.CheckBox();
            this.cb_enr = new System.Windows.Forms.CheckBox();
            this.cb_mast = new System.Windows.Forms.CheckBox();
            this.cb_mbsa = new System.Windows.Forms.CheckBox();
            this.cb_misc = new System.Windows.Forms.CheckBox();
            this.cb_amm2 = new System.Windows.Forms.CheckBox();
            this.cb_amm3 = new System.Windows.Forms.CheckBox();
            this.txt_amm1 = new System.Windows.Forms.TextBox();
            this.txt_amm2 = new System.Windows.Forms.TextBox();
            this.txt_amm3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_cps = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_case = new System.Windows.Forms.TextBox();
            this.txt_misc = new System.Windows.Forms.TextBox();
            this.txt_mast = new System.Windows.Forms.TextBox();
            this.txt_mbsa = new System.Windows.Forms.TextBox();
            this.cb_sheet = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txt_enr
            // 
            this.txt_enr.Location = new System.Drawing.Point(98, 32);
            this.txt_enr.Name = "txt_enr";
            this.txt_enr.Size = new System.Drawing.Size(100, 20);
            this.txt_enr.TabIndex = 0;
            this.txt_enr.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_customer
            // 
            this.txt_customer.Location = new System.Drawing.Point(9, 210);
            this.txt_customer.Name = "txt_customer";
            this.txt_customer.Size = new System.Drawing.Size(260, 30);
            this.txt_customer.TabIndex = 2;
            this.txt_customer.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Customer Name:";
            // 
            // txt_po
            // 
            this.txt_po.Location = new System.Drawing.Point(122, 115);
            this.txt_po.Name = "txt_po";
            this.txt_po.Size = new System.Drawing.Size(135, 20);
            this.txt_po.TabIndex = 5;
            // 
            // txt_country
            // 
            this.txt_country.Location = new System.Drawing.Point(122, 143);
            this.txt_country.Name = "txt_country";
            this.txt_country.Size = new System.Drawing.Size(133, 20);
            this.txt_country.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Sales Location:";
            // 
            // cb_amm1
            // 
            this.cb_amm1.AutoSize = true;
            this.cb_amm1.Location = new System.Drawing.Point(16, 290);
            this.cb_amm1.Name = "cb_amm1";
            this.cb_amm1.Size = new System.Drawing.Size(90, 17);
            this.cb_amm1.TabIndex = 9;
            this.cb_amm1.Text = "Ammendment";
            this.cb_amm1.UseVisualStyleBackColor = true;
            // 
            // cb_enr
            // 
            this.cb_enr.AutoSize = true;
            this.cb_enr.Location = new System.Drawing.Point(16, 35);
            this.cb_enr.Name = "cb_enr";
            this.cb_enr.Size = new System.Drawing.Size(76, 17);
            this.cb_enr.TabIndex = 10;
            this.cb_enr.Text = "Enrolment:";
            this.cb_enr.UseVisualStyleBackColor = true;
            this.cb_enr.CheckedChanged += new System.EventHandler(this.cb_enr_CheckedChanged);
            // 
            // cb_mast
            // 
            this.cb_mast.AutoSize = true;
            this.cb_mast.Location = new System.Drawing.Point(16, 61);
            this.cb_mast.Name = "cb_mast";
            this.cb_mast.Size = new System.Drawing.Size(61, 17);
            this.cb_mast.TabIndex = 11;
            this.cb_mast.Text = "Master:";
            this.cb_mast.UseVisualStyleBackColor = true;
            // 
            // cb_mbsa
            // 
            this.cb_mbsa.AutoSize = true;
            this.cb_mbsa.Location = new System.Drawing.Point(16, 87);
            this.cb_mbsa.Name = "cb_mbsa";
            this.cb_mbsa.Size = new System.Drawing.Size(59, 17);
            this.cb_mbsa.TabIndex = 12;
            this.cb_mbsa.Text = "MBSA:";
            this.cb_mbsa.UseVisualStyleBackColor = true;
            // 
            // cb_misc
            // 
            this.cb_misc.AutoSize = true;
            this.cb_misc.Location = new System.Drawing.Point(16, 256);
            this.cb_misc.Name = "cb_misc";
            this.cb_misc.Size = new System.Drawing.Size(145, 17);
            this.cb_misc.TabIndex = 13;
            this.cb_misc.Text = "Miscalouse Docs Copies:";
            this.cb_misc.UseVisualStyleBackColor = true;
            // 
            // cb_amm2
            // 
            this.cb_amm2.AutoSize = true;
            this.cb_amm2.Location = new System.Drawing.Point(15, 313);
            this.cb_amm2.Name = "cb_amm2";
            this.cb_amm2.Size = new System.Drawing.Size(90, 17);
            this.cb_amm2.TabIndex = 14;
            this.cb_amm2.Text = "Ammendment";
            this.cb_amm2.UseVisualStyleBackColor = true;
            // 
            // cb_amm3
            // 
            this.cb_amm3.AutoSize = true;
            this.cb_amm3.Location = new System.Drawing.Point(15, 336);
            this.cb_amm3.Name = "cb_amm3";
            this.cb_amm3.Size = new System.Drawing.Size(90, 17);
            this.cb_amm3.TabIndex = 15;
            this.cb_amm3.Text = "Ammendment";
            this.cb_amm3.UseVisualStyleBackColor = true;
            // 
            // txt_amm1
            // 
            this.txt_amm1.Location = new System.Drawing.Point(134, 287);
            this.txt_amm1.Name = "txt_amm1";
            this.txt_amm1.Size = new System.Drawing.Size(100, 20);
            this.txt_amm1.TabIndex = 16;
            // 
            // txt_amm2
            // 
            this.txt_amm2.Location = new System.Drawing.Point(135, 310);
            this.txt_amm2.Name = "txt_amm2";
            this.txt_amm2.Size = new System.Drawing.Size(100, 20);
            this.txt_amm2.TabIndex = 17;
            // 
            // txt_amm3
            // 
            this.txt_amm3.Location = new System.Drawing.Point(135, 333);
            this.txt_amm3.Name = "txt_amm3";
            this.txt_amm3.Size = new System.Drawing.Size(100, 20);
            this.txt_amm3.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 377);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Author: denmantm@inbox.lv";
            // 
            // cb_cps
            // 
            this.cb_cps.AutoSize = true;
            this.cb_cps.Location = new System.Drawing.Point(16, 117);
            this.cb_cps.Name = "cb_cps";
            this.cb_cps.Size = new System.Drawing.Size(102, 17);
            this.cb_cps.TabIndex = 20;
            this.cb_cps.Text = "CPS (PO Numb)";
            this.cb_cps.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Case Number:";
            // 
            // txt_case
            // 
            this.txt_case.Location = new System.Drawing.Point(122, 169);
            this.txt_case.Name = "txt_case";
            this.txt_case.Size = new System.Drawing.Size(137, 20);
            this.txt_case.TabIndex = 22;
            // 
            // txt_misc
            // 
            this.txt_misc.Location = new System.Drawing.Point(167, 254);
            this.txt_misc.Name = "txt_misc";
            this.txt_misc.Size = new System.Drawing.Size(26, 20);
            this.txt_misc.TabIndex = 23;
            // 
            // txt_mast
            // 
            this.txt_mast.Location = new System.Drawing.Point(98, 58);
            this.txt_mast.Name = "txt_mast";
            this.txt_mast.Size = new System.Drawing.Size(100, 20);
            this.txt_mast.TabIndex = 24;
            // 
            // txt_mbsa
            // 
            this.txt_mbsa.Location = new System.Drawing.Point(98, 84);
            this.txt_mbsa.Name = "txt_mbsa";
            this.txt_mbsa.Size = new System.Drawing.Size(100, 20);
            this.txt_mbsa.TabIndex = 25;
            // 
            // cb_sheet
            // 
            this.cb_sheet.AutoSize = true;
            this.cb_sheet.Location = new System.Drawing.Point(15, 9);
            this.cb_sheet.Name = "cb_sheet";
            this.cb_sheet.Size = new System.Drawing.Size(102, 17);
            this.cb_sheet.TabIndex = 26;
            this.cb_sheet.Text = "Signature Sheet";
            this.cb_sheet.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 431);
            this.Controls.Add(this.cb_sheet);
            this.Controls.Add(this.txt_mbsa);
            this.Controls.Add(this.txt_mast);
            this.Controls.Add(this.txt_misc);
            this.Controls.Add(this.txt_case);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_cps);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_amm3);
            this.Controls.Add(this.txt_amm2);
            this.Controls.Add(this.txt_amm1);
            this.Controls.Add(this.cb_amm3);
            this.Controls.Add(this.cb_amm2);
            this.Controls.Add(this.cb_misc);
            this.Controls.Add(this.cb_mbsa);
            this.Controls.Add(this.cb_mast);
            this.Controls.Add(this.cb_enr);
            this.Controls.Add(this.cb_amm1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_country);
            this.Controls.Add(this.txt_po);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_customer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_enr);
            this.Name = "Form1";
            this.Text = "DocGenerator V0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_enr;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox txt_customer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_po;
        private System.Windows.Forms.TextBox txt_country;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_amm1;
        private System.Windows.Forms.CheckBox cb_enr;
        private System.Windows.Forms.CheckBox cb_mast;
        private System.Windows.Forms.CheckBox cb_mbsa;
        private System.Windows.Forms.CheckBox cb_misc;
        private System.Windows.Forms.CheckBox cb_amm2;
        private System.Windows.Forms.CheckBox cb_amm3;
        private System.Windows.Forms.TextBox txt_amm1;
        private System.Windows.Forms.TextBox txt_amm2;
        private System.Windows.Forms.TextBox txt_amm3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cb_cps;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_case;
        private System.Windows.Forms.TextBox txt_misc;
        private System.Windows.Forms.TextBox txt_mast;
        private System.Windows.Forms.TextBox txt_mbsa;
        private System.Windows.Forms.CheckBox cb_sheet;
    }
}


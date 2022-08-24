
namespace Supermarket1._0
{
    partial class ExEmployeesForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnObnovi = new System.Windows.Forms.Button();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvExZaposleni = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExZaposleni)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.btnObnovi);
            this.panel1.Controls.Add(this.tbFilter);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.dgvExZaposleni);
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.Color.Olive;
            this.panel1.Location = new System.Drawing.Point(24, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 473);
            this.panel1.TabIndex = 7;
            this.panel1.UseWaitCursor = true;
            // 
            // btnObnovi
            // 
            this.btnObnovi.BackColor = System.Drawing.Color.White;
            this.btnObnovi.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnObnovi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnObnovi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnObnovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObnovi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObnovi.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnObnovi.Location = new System.Drawing.Point(576, 429);
            this.btnObnovi.Name = "btnObnovi";
            this.btnObnovi.Size = new System.Drawing.Size(192, 34);
            this.btnObnovi.TabIndex = 5;
            this.btnObnovi.Text = "OBNOVI RADNI ODNOS";
            this.btnObnovi.UseVisualStyleBackColor = false;
            this.btnObnovi.UseWaitCursor = true;
            this.btnObnovi.Click += new System.EventHandler(this.btnPogledaj_Click);
            // 
            // tbFilter
            // 
            this.tbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilter.ForeColor = System.Drawing.Color.OrangeRed;
            this.tbFilter.Location = new System.Drawing.Point(358, 59);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(410, 26);
            this.tbFilter.TabIndex = 3;
            this.tbFilter.UseWaitCursor = true;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.OrangeRed;
            this.label12.Location = new System.Drawing.Point(258, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 24);
            this.label12.TabIndex = 2;
            this.label12.Text = "Pretraga:";
            this.label12.UseWaitCursor = true;
            // 
            // dgvExZaposleni
            // 
            this.dgvExZaposleni.BackgroundColor = System.Drawing.Color.White;
            this.dgvExZaposleni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExZaposleni.Location = new System.Drawing.Point(18, 91);
            this.dgvExZaposleni.Name = "dgvExZaposleni";
            this.dgvExZaposleni.Size = new System.Drawing.Size(750, 332);
            this.dgvExZaposleni.TabIndex = 4;
            this.dgvExZaposleni.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(297, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "BIVŠI ZAPOSLENI";
            this.label2.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.OrangeRed;
            this.label6.Location = new System.Drawing.Point(801, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "X";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // ExEmployeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OrangeRed;
            this.ClientSize = new System.Drawing.Size(834, 543);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExEmployeesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExEmployees";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExZaposleni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnObnovi;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvExZaposleni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
    }
}
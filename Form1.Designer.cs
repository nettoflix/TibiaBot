
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FirstForm
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cboxPlay = new System.Windows.Forms.CheckBox();
            this.cura1 = new System.Windows.Forms.Label();
            this.htk_cura1 = new System.Windows.Forms.ComboBox();
            this.valor_cura1 = new System.Windows.Forms.TextBox();
            this.valor_cura2 = new System.Windows.Forms.TextBox();
            this.htk_cura2 = new System.Windows.Forms.ComboBox();
            this.cura2 = new System.Windows.Forms.Label();
            this.valor_cura3 = new System.Windows.Forms.TextBox();
            this.htk_cura3 = new System.Windows.Forms.ComboBox();
            this.cura3 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            List<string> hotkeys = new List<string> { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12"};
            
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // cboxPlay
            // 
            this.cboxPlay.AutoSize = true;
            this.cboxPlay.Location = new System.Drawing.Point(12, 12);
            this.cboxPlay.Name = "cboxPlay";
            this.cboxPlay.Size = new System.Drawing.Size(46, 17);
            this.cboxPlay.TabIndex = 0;
            this.cboxPlay.Text = "Play";
            this.cboxPlay.UseVisualStyleBackColor = true;
            this.cboxPlay.CheckedChanged += new System.EventHandler(this.cboxPlay_CheckedChanged);
            // 
            // 
            // 
            this.cura1.AutoSize = true;
            this.cura1.Location = new System.Drawing.Point(60, 51);
            this.cura1.Name = "cura1";
            this.cura1.Size = new System.Drawing.Size(38, 13);
            this.cura1.TabIndex = 1;
            this.cura1.Text = "Cura 1";
            //this.cura1.Click += new System.EventHandler(this.cura1_Click);
            // 
            // comboBox
            // 
            this.htk_cura1.FormattingEnabled = true;
            this.htk_cura1.Location = new System.Drawing.Point(26, 67);
            this.htk_cura1.Name = "htk_Cura1";
            this.htk_cura1.Size = new System.Drawing.Size(48, 21);
            this.htk_cura1.TabIndex = 2;
            this.htk_cura2.BindingContext = new BindingContext();
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = hotkeys;
            this.htk_cura1.DataSource = bindingSource1.DataSource;
            this.htk_cura1.DisplayMember = "Name";
            this.htk_cura1.ValueMember = "Name";
            this.htk_cura1.SelectedIndexChanged += new System.EventHandler(this.htk_cura1_SelectedIndexChanged);
            // 
            // textBox
            // 
            this.valor_cura1.Location = new System.Drawing.Point(80, 68);
            this.valor_cura1.Name = "valor_cura1";
            this.valor_cura1.Size = new System.Drawing.Size(48, 20);
            this.valor_cura1.TabIndex = 3;
            this.valor_cura1.TextChanged += new System.EventHandler(this.valor_cura1_TextChanged);
            // 
            // textBox
            // 
            this.valor_cura2.Location = new System.Drawing.Point(80, 108);
            this.valor_cura2.Name = "valor_cura2";
            this.valor_cura2.Size = new System.Drawing.Size(48, 20);
            this.valor_cura2.TabIndex = 6;
            this.valor_cura2.TextChanged += new System.EventHandler(this.valor_cura2_TextChanged);
            // 
            // comboBox
            // 
            this.htk_cura2.FormattingEnabled = true;
            this.htk_cura2.Location = new System.Drawing.Point(26, 107);
            this.htk_cura2.Name = "htk_cura2";
            this.htk_cura2.Size = new System.Drawing.Size(48, 21);
            this.htk_cura2.TabIndex = 5;
            this.htk_cura2.SelectedIndexChanged += new System.EventHandler(this.htk_cura2_SelectedIndexChanged);
            this.htk_cura2.BindingContext = new BindingContext();
            var bindingSource2 = new BindingSource();
            bindingSource2.DataSource = hotkeys;
            this.htk_cura2.DataSource = bindingSource2.DataSource;
           // this.htk_cura2.DisplayMember = "Name";
            //this.htk_cura2.ValueMember = "Name";
            // 
            // label
            // 
            this.cura2.AutoSize = true;
            this.cura2.Location = new System.Drawing.Point(60, 91);
            this.cura2.Name = "cura2";
            this.cura2.Size = new System.Drawing.Size(38, 13);
            this.cura2.TabIndex = 4;
            this.cura2.Text = "Cura 2";
            // 
            // textBox
            // 
            this.valor_cura3.Location = new System.Drawing.Point(80, 148);
            this.valor_cura3.Name = "valor_cura3";
            this.valor_cura3.Size = new System.Drawing.Size(48, 20);
            this.valor_cura3.TabIndex = 9;
            this.valor_cura3.TextChanged += new System.EventHandler(this.valor_cura3_TextChanged);
            // 
            // comboBox
            // 
            this.htk_cura3.FormattingEnabled = true;
            this.htk_cura3.Location = new System.Drawing.Point(26, 147);
            this.htk_cura3.Name = "htk_cura3";
            this.htk_cura3.Size = new System.Drawing.Size(48, 21);
            this.htk_cura3.TabIndex = 8;
            this.htk_cura3.SelectedIndexChanged += new System.EventHandler(this.htk_cura3_SelectedIndexChanged);
            this.htk_cura3.BindingContext = new BindingContext();
            var bindingSource3 = new BindingSource();
            bindingSource3.DataSource = hotkeys;
            this.htk_cura3.DataSource = bindingSource3.DataSource;
         ;
            // 
            // label
            // 
            this.cura3.AutoSize = true;
            this.cura3.Location = new System.Drawing.Point(60, 131);
            this.cura3.Name = "cura3";
            this.cura3.Size = new System.Drawing.Size(38, 13);
            this.cura3.TabIndex = 7;
            this.cura3.Text = "Cura 3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.valor_cura3);
            this.Controls.Add(this.htk_cura3);
            this.Controls.Add(this.cura3);
            this.Controls.Add(this.valor_cura2);
            this.Controls.Add(this.htk_cura2);
            this.Controls.Add(this.cura2);
            this.Controls.Add(this.valor_cura1);
            this.Controls.Add(this.htk_cura1);
            this.Controls.Add(this.cura1);
            this.Controls.Add(this.cboxPlay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

     

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox cboxPlay;
        private System.Windows.Forms.Label cura1;
        private System.Windows.Forms.ComboBox htk_cura1;
        private System.Windows.Forms.TextBox valor_cura1;
        private System.Windows.Forms.TextBox valor_cura2;
        private System.Windows.Forms.ComboBox htk_cura2;
        private System.Windows.Forms.Label cura2;
        private System.Windows.Forms.TextBox valor_cura3;
        private System.Windows.Forms.ComboBox htk_cura3;
        private System.Windows.Forms.Label cura3;

        
       
    }
}


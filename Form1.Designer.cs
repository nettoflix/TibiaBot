
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FirstForm
{
    partial class Form1
    {
       // List<string> hotkeys = new List<string> { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12" };
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbox_Play = new System.Windows.Forms.CheckBox();
            this.cura1 = new System.Windows.Forms.Label();
            this.htk_cura1 = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.valor_cura1 = new System.Windows.Forms.TextBox();
            this.valor_cura2 = new System.Windows.Forms.TextBox();
            this.htk_cura2 = new System.Windows.Forms.ComboBox();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.cura2 = new System.Windows.Forms.Label();
            this.valor_cura3 = new System.Windows.Forms.TextBox();
            this.htk_cura3 = new System.Windows.Forms.ComboBox();
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.cura3 = new System.Windows.Forms.Label();
            this.arrow_up = new System.Windows.Forms.PictureBox();
            this.arrow_left = new System.Windows.Forms.PictureBox();
            this.arrow_down = new System.Windows.Forms.PictureBox();
            this.arrow_right = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_clearList = new System.Windows.Forms.Button();
            this.cbox_caveRun = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrow_up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrow_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrow_down)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrow_right)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // cbox_Play
            // 
            this.cbox_Play.AutoSize = true;
            this.cbox_Play.Location = new System.Drawing.Point(12, 12);
            this.cbox_Play.Name = "cbox_Play";
            this.cbox_Play.Size = new System.Drawing.Size(46, 17);
            this.cbox_Play.TabIndex = 0;
            this.cbox_Play.Text = "Play";
            this.cbox_Play.UseVisualStyleBackColor = true;
            this.cbox_Play.CheckedChanged += new System.EventHandler(this.cboxPlay_CheckedChanged);
            // 
            // cura1
            // 
            this.cura1.AutoSize = true;
            this.cura1.Location = new System.Drawing.Point(60, 51);
            this.cura1.Name = "cura1";
            this.cura1.Size = new System.Drawing.Size(38, 13);
            this.cura1.TabIndex = 1;
            this.cura1.Text = "Cura 1";
            // 
            // htk_cura1
            // 
            this.htk_cura1.DataSource = this.bindingSource1.DataSource;
            this.htk_cura1.DisplayMember = "Name";
            this.htk_cura1.FormattingEnabled = true;
            this.htk_cura1.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4"});
            this.htk_cura1.Location = new System.Drawing.Point(26, 67);
            this.htk_cura1.Name = "htk_cura1";
            this.htk_cura1.Size = new System.Drawing.Size(48, 21);
            this.htk_cura1.TabIndex = 2;
            this.htk_cura1.ValueMember = "Name";
            this.htk_cura1.SelectedIndexChanged += new System.EventHandler(this.htk_cura1_SelectedIndexChanged);
            // 
            // valor_cura1
            // 
            this.valor_cura1.Location = new System.Drawing.Point(80, 68);
            this.valor_cura1.Name = "valor_cura1";
            this.valor_cura1.Size = new System.Drawing.Size(48, 20);
            this.valor_cura1.TabIndex = 3;
            this.valor_cura1.TextChanged += new System.EventHandler(this.valor_cura1_TextChanged);
            // 
            // valor_cura2
            // 
            this.valor_cura2.Location = new System.Drawing.Point(80, 108);
            this.valor_cura2.Name = "valor_cura2";
            this.valor_cura2.Size = new System.Drawing.Size(48, 20);
            this.valor_cura2.TabIndex = 6;
            this.valor_cura2.TextChanged += new System.EventHandler(this.valor_cura2_TextChanged);
            // 
            // htk_cura2
            // 
            this.htk_cura2.DataSource = this.bindingSource2.DataSource;
            this.htk_cura2.FormattingEnabled = true;
            this.htk_cura2.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4"});
            this.htk_cura2.Location = new System.Drawing.Point(26, 107);
            this.htk_cura2.Name = "htk_cura2";
            this.htk_cura2.Size = new System.Drawing.Size(48, 21);
            this.htk_cura2.TabIndex = 5;
            this.htk_cura2.SelectedIndexChanged += new System.EventHandler(this.htk_cura2_SelectedIndexChanged);
            // 
            // cura2
            // 
            this.cura2.AutoSize = true;
            this.cura2.Location = new System.Drawing.Point(60, 91);
            this.cura2.Name = "cura2";
            this.cura2.Size = new System.Drawing.Size(38, 13);
            this.cura2.TabIndex = 4;
            this.cura2.Text = "Cura 2";
            // 
            // valor_cura3
            // 
            this.valor_cura3.Location = new System.Drawing.Point(80, 148);
            this.valor_cura3.Name = "valor_cura3";
            this.valor_cura3.Size = new System.Drawing.Size(48, 20);
            this.valor_cura3.TabIndex = 9;
            this.valor_cura3.TextChanged += new System.EventHandler(this.valor_cura3_TextChanged);
            // 
            // htk_cura3
            // 
            this.htk_cura3.DataSource = this.bindingSource3.DataSource;
            this.htk_cura3.FormattingEnabled = true;
            this.htk_cura3.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4"});
            this.htk_cura3.Location = new System.Drawing.Point(26, 147);
            this.htk_cura3.Name = "htk_cura3";
            this.htk_cura3.Size = new System.Drawing.Size(48, 21);
            this.htk_cura3.TabIndex = 8;
            this.htk_cura3.SelectedIndexChanged += new System.EventHandler(this.htk_cura3_SelectedIndexChanged);
            // 
            // cura3
            // 
            this.cura3.AutoSize = true;
            this.cura3.Location = new System.Drawing.Point(60, 131);
            this.cura3.Name = "cura3";
            this.cura3.Size = new System.Drawing.Size(38, 13);
            this.cura3.TabIndex = 7;
            this.cura3.Text = "Cura 3";
            // 
            // arrow_up
            // 
            this.arrow_up.Image = global::FirstForm.Properties.Resources.arrow_up2;
            this.arrow_up.Location = new System.Drawing.Point(540, 19);
            this.arrow_up.Name = "arrow_up";
            this.arrow_up.Size = new System.Drawing.Size(58, 85);
            this.arrow_up.TabIndex = 10;
            this.arrow_up.TabStop = false;
            this.arrow_up.Click += new System.EventHandler(this.arrow_up_Click);
            // 
            // arrow_left
            // 
            this.arrow_left.Image = ((System.Drawing.Image)(resources.GetObject("arrow_left.Image")));
            this.arrow_left.Location = new System.Drawing.Point(458, 106);
            this.arrow_left.Name = "arrow_left";
            this.arrow_left.Size = new System.Drawing.Size(86, 62);
            this.arrow_left.TabIndex = 11;
            this.arrow_left.TabStop = false;
            this.arrow_left.Click += new System.EventHandler(this.arrow_left_Click);
            // 
            // arrow_down
            // 
            this.arrow_down.Image = global::FirstForm.Properties.Resources.arrow_down2;
            this.arrow_down.Location = new System.Drawing.Point(540, 174);
            this.arrow_down.Name = "arrow_down";
            this.arrow_down.Size = new System.Drawing.Size(58, 80);
            this.arrow_down.TabIndex = 12;
            this.arrow_down.TabStop = false;
            this.arrow_down.Click += new System.EventHandler(this.arrow_down_Click);
            // 
            // arrow_right
            // 
            this.arrow_right.Image = global::FirstForm.Properties.Resources.arrow_right2;
            this.arrow_right.Location = new System.Drawing.Point(595, 103);
            this.arrow_right.Name = "arrow_right";
            this.arrow_right.Size = new System.Drawing.Size(82, 65);
            this.arrow_right.TabIndex = 13;
            this.arrow_right.TabStop = false;
            this.arrow_right.Click += new System.EventHandler(this.arrow_right_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(298, 9);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(128, 95);
            this.listBox1.TabIndex = 14;
            // 
            // btn_clearList
            // 
            this.btn_clearList.Location = new System.Drawing.Point(432, 9);
            this.btn_clearList.Name = "btn_clearList";
            this.btn_clearList.Size = new System.Drawing.Size(75, 23);
            this.btn_clearList.TabIndex = 15;
            this.btn_clearList.Text = "Clear";
            this.btn_clearList.UseVisualStyleBackColor = true;
            this.btn_clearList.Click += new System.EventHandler(this.btn_clearList_Click);
            // 
            // cbox_caveRun
            // 
            this.cbox_caveRun.AutoSize = true;
            this.cbox_caveRun.Location = new System.Drawing.Point(613, 19);
            this.cbox_caveRun.Name = "cbox_caveRun";
            this.cbox_caveRun.Size = new System.Drawing.Size(70, 17);
            this.cbox_caveRun.TabIndex = 16;
            this.cbox_caveRun.Text = "caveRun";
            this.cbox_caveRun.UseVisualStyleBackColor = true;
            this.cbox_caveRun.CheckedChanged += new System.EventHandler(this.cbox_caveRun_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbox_caveRun);
            this.Controls.Add(this.btn_clearList);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.arrow_right);
            this.Controls.Add(this.arrow_down);
            this.Controls.Add(this.arrow_left);
            this.Controls.Add(this.arrow_up);
            this.Controls.Add(this.valor_cura3);
            this.Controls.Add(this.htk_cura3);
            this.Controls.Add(this.cura3);
            this.Controls.Add(this.valor_cura2);
            this.Controls.Add(this.htk_cura2);
            this.Controls.Add(this.cura2);
            this.Controls.Add(this.valor_cura1);
            this.Controls.Add(this.htk_cura1);
            this.Controls.Add(this.cura1);
            this.Controls.Add(this.cbox_Play);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrow_up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrow_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrow_down)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrow_right)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       





        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox cbox_Play;
        private System.Windows.Forms.Label cura1;
        private System.Windows.Forms.ComboBox htk_cura1;
        private System.Windows.Forms.TextBox valor_cura1;
        private System.Windows.Forms.TextBox valor_cura2;
        private System.Windows.Forms.ComboBox htk_cura2;
        private System.Windows.Forms.Label cura2;
        private System.Windows.Forms.TextBox valor_cura3;
        private System.Windows.Forms.ComboBox htk_cura3;
        private System.Windows.Forms.Label cura3;
        private BindingSource bindingSource1;
        private BindingSource bindingSource2;
        private BindingSource bindingSource3;
        private PictureBox arrow_up;
        private PictureBox arrow_left;
        private PictureBox arrow_down;
        private PictureBox arrow_right;
        private ListBox listBox1;
        private Button btn_clearList;
        private CheckBox cbox_caveRun;
    }
}


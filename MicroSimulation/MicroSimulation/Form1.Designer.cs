
namespace MicroSimulation
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
            this.lbl_ClosingYear = new System.Windows.Forms.Label();
            this.lbl_Population = new System.Windows.Forms.Label();
            this.num_ClosingYear = new System.Windows.Forms.NumericUpDown();
            this.txt_PopulationPath = new System.Windows.Forms.TextBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_progress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_ClosingYear)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ClosingYear
            // 
            this.lbl_ClosingYear.AutoSize = true;
            this.lbl_ClosingYear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ClosingYear.Location = new System.Drawing.Point(13, 15);
            this.lbl_ClosingYear.Name = "lbl_ClosingYear";
            this.lbl_ClosingYear.Size = new System.Drawing.Size(50, 17);
            this.lbl_ClosingYear.TabIndex = 0;
            this.lbl_ClosingYear.Text = "Záróév";
            // 
            // lbl_Population
            // 
            this.lbl_Population.AutoSize = true;
            this.lbl_Population.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Population.Location = new System.Drawing.Point(144, 15);
            this.lbl_Population.Name = "lbl_Population";
            this.lbl_Population.Size = new System.Drawing.Size(91, 17);
            this.lbl_Population.TabIndex = 1;
            this.lbl_Population.Text = "Népesség fájl";
            // 
            // num_ClosingYear
            // 
            this.num_ClosingYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_ClosingYear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.num_ClosingYear.Location = new System.Drawing.Point(69, 12);
            this.num_ClosingYear.Maximum = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.num_ClosingYear.Minimum = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            this.num_ClosingYear.Name = "num_ClosingYear";
            this.num_ClosingYear.Size = new System.Drawing.Size(58, 25);
            this.num_ClosingYear.TabIndex = 2;
            this.num_ClosingYear.Value = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            // 
            // txt_PopulationPath
            // 
            this.txt_PopulationPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PopulationPath.Location = new System.Drawing.Point(241, 12);
            this.txt_PopulationPath.Name = "txt_PopulationPath";
            this.txt_PopulationPath.ReadOnly = true;
            this.txt_PopulationPath.Size = new System.Drawing.Size(292, 25);
            this.txt_PopulationPath.TabIndex = 3;
            // 
            // btn_Browse
            // 
            this.btn_Browse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Browse.Location = new System.Drawing.Point(539, 11);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(108, 26);
            this.btn_Browse.TabIndex = 4;
            this.btn_Browse.Text = "Tallózás";
            this.btn_Browse.UseVisualStyleBackColor = true;
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Start.Location = new System.Drawing.Point(653, 11);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(108, 26);
            this.btn_Start.TabIndex = 5;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(16, 74);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(745, 364);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 45);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(745, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // lbl_progress
            // 
            this.lbl_progress.AutoSize = true;
            this.lbl_progress.BackColor = System.Drawing.Color.Transparent;
            this.lbl_progress.Location = new System.Drawing.Point(371, 50);
            this.lbl_progress.Name = "lbl_progress";
            this.lbl_progress.Size = new System.Drawing.Size(24, 13);
            this.lbl_progress.TabIndex = 8;
            this.lbl_progress.Text = "0 %";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 450);
            this.Controls.Add(this.lbl_progress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.txt_PopulationPath);
            this.Controls.Add(this.num_ClosingYear);
            this.Controls.Add(this.lbl_Population);
            this.Controls.Add(this.lbl_ClosingYear);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.num_ClosingYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ClosingYear;
        private System.Windows.Forms.Label lbl_Population;
        private System.Windows.Forms.NumericUpDown num_ClosingYear;
        private System.Windows.Forms.TextBox txt_PopulationPath;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_progress;
    }
}


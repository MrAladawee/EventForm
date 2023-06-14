namespace EventForm
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSeqSum = new System.Windows.Forms.Label();
            this.lblParSum = new System.Windows.Forms.Label();
            this.btnStartSeqSum = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Послед.суммирование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Парал.суммирование";
            // 
            // lblSeqSum
            // 
            this.lblSeqSum.AutoSize = true;
            this.lblSeqSum.Location = new System.Drawing.Point(29, 49);
            this.lblSeqSum.Name = "lblSeqSum";
            this.lblSeqSum.Size = new System.Drawing.Size(60, 15);
            this.lblSeqSum.TabIndex = 2;
            this.lblSeqSum.Text = "Результат";
            // 
            // lblParSum
            // 
            this.lblParSum.AutoSize = true;
            this.lblParSum.Location = new System.Drawing.Point(327, 49);
            this.lblParSum.Name = "lblParSum";
            this.lblParSum.Size = new System.Drawing.Size(60, 15);
            this.lblParSum.TabIndex = 3;
            this.lblParSum.Text = "Результат";
            // 
            // btnStartSeqSum
            // 
            this.btnStartSeqSum.Location = new System.Drawing.Point(12, 149);
            this.btnStartSeqSum.Name = "btnStartSeqSum";
            this.btnStartSeqSum.Size = new System.Drawing.Size(467, 23);
            this.btnStartSeqSum.TabIndex = 4;
            this.btnStartSeqSum.Text = "Суммирование";
            this.btnStartSeqSum.UseVisualStyleBackColor = true;
            this.btnStartSeqSum.Click += new System.EventHandler(this.btnStartSeqSum_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 111);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(467, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 184);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnStartSeqSum);
            this.Controls.Add(this.lblParSum);
            this.Controls.Add(this.lblSeqSum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lblSeqSum;
        private Label lblParSum;
        private Button btnStartSeqSum;
        private ProgressBar progressBar1;
    }
}
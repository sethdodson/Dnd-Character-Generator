namespace FlashCards
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.statusLabel1 = new System.Windows.Forms.Label();
            this.resultLabel1 = new System.Windows.Forms.Label();
            this.numeratorLabel1 = new System.Windows.Forms.Label();
            this.denominatorLabel1 = new System.Windows.Forms.Label();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.viewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(186, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 67);
            this.label1.TabIndex = 1;
            this.label1.Text = "÷";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 67);
            this.label2.TabIndex = 3;
            this.label2.Text = "=";
            // 
            // btnAnswer
            // 
            this.btnAnswer.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.viewModelBindingSource, "CanAnswer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnAnswer.Enabled = false;
            this.btnAnswer.Location = new System.Drawing.Point(342, 102);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(102, 74);
            this.btnAnswer.TabIndex = 5;
            this.btnAnswer.Text = "Check Answer";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // statusLabel1
            // 
            this.statusLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "Status", true));
            this.statusLabel1.Location = new System.Drawing.Point(14, 265);
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(382, 23);
            this.statusLabel1.TabIndex = 10;
            this.statusLabel1.Text = "1 / 30 correct";
            // 
            // resultLabel1
            // 
            this.resultLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "Result", true));
            this.resultLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel1.Location = new System.Drawing.Point(13, 224);
            this.resultLabel1.Name = "resultLabel1";
            this.resultLabel1.Size = new System.Drawing.Size(465, 23);
            this.resultLabel1.TabIndex = 11;
            this.resultLabel1.Text = "Your answer was WRONG. Correct answer: 3";
            // 
            // numeratorLabel1
            // 
            this.numeratorLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "Numerator", true));
            this.numeratorLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeratorLabel1.Location = new System.Drawing.Point(47, 9);
            this.numeratorLabel1.Name = "numeratorLabel1";
            this.numeratorLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numeratorLabel1.Size = new System.Drawing.Size(146, 69);
            this.numeratorLabel1.TabIndex = 12;
            this.numeratorLabel1.Text = "100";
            // 
            // denominatorLabel1
            // 
            this.denominatorLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "Denominator", true));
            this.denominatorLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denominatorLabel1.Location = new System.Drawing.Point(255, 9);
            this.denominatorLabel1.Name = "denominatorLabel1";
            this.denominatorLabel1.Size = new System.Drawing.Size(116, 63);
            this.denominatorLabel1.TabIndex = 13;
            this.denominatorLabel1.Text = "10";
            // 
            // answerTextBox
            // 
            this.answerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "Answer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.answerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerTextBox.Location = new System.Drawing.Point(186, 99);
            this.answerTextBox.MaxLength = 3;
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(150, 80);
            this.answerTextBox.TabIndex = 14;
            // 
            // viewModelBindingSource
            // 
            this.viewModelBindingSource.DataSource = typeof(FlashCards.ViewModel);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 308);
            this.Controls.Add(this.answerTextBox);
            this.Controls.Add(this.denominatorLabel1);
            this.Controls.Add(this.numeratorLabel1);
            this.Controls.Add(this.resultLabel1);
            this.Controls.Add(this.statusLabel1);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.BindingSource viewModelBindingSource;
        private System.Windows.Forms.Label statusLabel1;
        private System.Windows.Forms.Label resultLabel1;
        private System.Windows.Forms.Label numeratorLabel1;
        private System.Windows.Forms.Label denominatorLabel1;
        private System.Windows.Forms.TextBox answerTextBox;
    }
}


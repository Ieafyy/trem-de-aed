namespace totem_1
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
        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            progressBar1 = new ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(229, 39);
            label1.Name = "label1";
            label1.Size = new Size(351, 50);
            label1.TabIndex = 0;
            label1.Text = "SEJA BEM VINDO(A)";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(570, 273);
            label2.Name = "label2";
            label2.Size = new Size(50, 8);
            label2.TabIndex = 0;
            label2.Text = "Criado por: Raphael, Matheus, Vinicius";
            // 
            // button1
            // 
            button1.Location = new Point(318, 119);
            button1.Name = "button1";
            button1.Size = new Size(169, 57);
            button1.TabIndex = 1;
            button1.Text = "GERAR TICKET";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(94, 201);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(627, 23);
            progressBar1.TabIndex = 2;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            ClientSize = new Size(793, 289);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
        private Label label2;
        private Button button1;
        private ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}
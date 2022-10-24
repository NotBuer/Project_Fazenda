namespace Pecuaria
{
    partial class Form3
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
            this.txt_animalName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_animalPrice = new System.Windows.Forms.TextBox();
            this.btnCadastrarAnimal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_animalName
            // 
            this.txt_animalName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_animalName.Location = new System.Drawing.Point(170, 78);
            this.txt_animalName.Name = "txt_animalName";
            this.txt_animalName.Size = new System.Drawing.Size(428, 29);
            this.txt_animalName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Animal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(104, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Preco";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nome do Animal";
            // 
            // txt_animalPrice
            // 
            this.txt_animalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_animalPrice.Location = new System.Drawing.Point(170, 139);
            this.txt_animalPrice.Name = "txt_animalPrice";
            this.txt_animalPrice.Size = new System.Drawing.Size(428, 29);
            this.txt_animalPrice.TabIndex = 4;
            // 
            // btnCadastrarAnimal
            // 
            this.btnCadastrarAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarAnimal.Location = new System.Drawing.Point(250, 312);
            this.btnCadastrarAnimal.Name = "btnCadastrarAnimal";
            this.btnCadastrarAnimal.Size = new System.Drawing.Size(152, 61);
            this.btnCadastrarAnimal.TabIndex = 7;
            this.btnCadastrarAnimal.Text = "Cadastrar";
            this.btnCadastrarAnimal.UseVisualStyleBackColor = true;
            this.btnCadastrarAnimal.Click += new System.EventHandler(this.btnCadastrarAnimal_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 385);
            this.Controls.Add(this.btnCadastrarAnimal);
            this.Controls.Add(this.txt_animalName);
            this.Controls.Add(this.txt_animalPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Cadastro Animal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_animalPrice;
        private System.Windows.Forms.Button btnCadastrarAnimal;
        private System.Windows.Forms.TextBox txt_animalName;
    }
}
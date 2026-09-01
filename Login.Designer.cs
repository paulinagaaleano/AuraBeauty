namespace AuraBeauty
{
    partial class Login
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
            label1 = new Label();
            label2 = new Label();
            txtCorreo = new TextBox();
            txtContraseña = new TextBox();
            btnIngresar = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.SeaShell;
            label1.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(60, 254);
            label1.Name = "label1";
            label1.Size = new Size(109, 23);
            label1.TabIndex = 0;
            label1.Text = "Contraseña:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.SeaShell;
            label2.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(60, 192);
            label2.Name = "label2";
            label2.Size = new Size(177, 23);
            label2.TabIndex = 1;
            label2.Text = "Correo Electrónico:";
            label2.Click += label2_Click;
            // 
            // txtCorreo
            // 
            txtCorreo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCorreo.Location = new Point(387, 192);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(232, 29);
            txtCorreo.TabIndex = 2;
            txtCorreo.TextChanged += txtCorreo_TextChanged;
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContraseña.Location = new Point(387, 254);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(232, 29);
            txtContraseña.TabIndex = 3;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.White;
            btnIngresar.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = SystemColors.ActiveCaptionText;
            btnIngresar.Location = new Point(243, 358);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(139, 45);
            btnIngresar.TabIndex = 4;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.SeaShell;
            label3.Font = new Font("Times New Roman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(170, 65);
            label3.Name = "label3";
            label3.Size = new Size(286, 55);
            label3.TabIndex = 5;
            label3.Text = "Aura Beauty";
            label3.TextAlign = ContentAlignment.TopCenter;
            label3.Click += label3_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaShell;
            ClientSize = new Size(684, 511);
            Controls.Add(label3);
            Controls.Add(btnIngresar);
            Controls.Add(txtContraseña);
            Controls.Add(txtCorreo);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            Text = "Login - Aura Beauty";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtCorreo;
        private TextBox txtContraseña;
        private Button btnIngresar;
        private Label label3;
    }
}

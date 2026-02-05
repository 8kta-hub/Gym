namespace Gym.V
{
    partial class frm_Login
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
            this.btn_Login_Acceder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Login_Contraseña = new System.Windows.Forms.TextBox();
            this.txt_login_Usuari = new System.Windows.Forms.TextBox();
            this.lbl_OlvidarContraseña_Login = new System.Windows.Forms.Label();
            this.btn_MostrarContraseña_Login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Login_Acceder
            // 
            this.btn_Login_Acceder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login_Acceder.Location = new System.Drawing.Point(216, 247);
            this.btn_Login_Acceder.Name = "btn_Login_Acceder";
            this.btn_Login_Acceder.Size = new System.Drawing.Size(75, 23);
            this.btn_Login_Acceder.TabIndex = 0;
            this.btn_Login_Acceder.Text = "Acceder";
            this.btn_Login_Acceder.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuario";
            // 
            // txt_Login_Contraseña
            // 
            this.txt_Login_Contraseña.Location = new System.Drawing.Point(154, 174);
            this.txt_Login_Contraseña.Multiline = true;
            this.txt_Login_Contraseña.Name = "txt_Login_Contraseña";
            this.txt_Login_Contraseña.PasswordChar = '*';
            this.txt_Login_Contraseña.Size = new System.Drawing.Size(199, 29);
            this.txt_Login_Contraseña.TabIndex = 4;
            // 
            // txt_login_Usuari
            // 
            this.txt_login_Usuari.Location = new System.Drawing.Point(154, 98);
            this.txt_login_Usuari.Multiline = true;
            this.txt_login_Usuari.Name = "txt_login_Usuari";
            this.txt_login_Usuari.Size = new System.Drawing.Size(199, 29);
            this.txt_login_Usuari.TabIndex = 5;
            // 
            // lbl_OlvidarContraseña_Login
            // 
            this.lbl_OlvidarContraseña_Login.AutoSize = true;
            this.lbl_OlvidarContraseña_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OlvidarContraseña_Login.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_OlvidarContraseña_Login.Location = new System.Drawing.Point(152, 209);
            this.lbl_OlvidarContraseña_Login.Name = "lbl_OlvidarContraseña_Login";
            this.lbl_OlvidarContraseña_Login.Size = new System.Drawing.Size(155, 16);
            this.lbl_OlvidarContraseña_Login.TabIndex = 6;
            this.lbl_OlvidarContraseña_Login.Text = "Olvidaste la contraseña?";
            // 
            // btn_MostrarContraseña_Login
            // 
            this.btn_MostrarContraseña_Login.BackgroundImage = global::Gym.Properties.Resources.show;
            this.btn_MostrarContraseña_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_MostrarContraseña_Login.Location = new System.Drawing.Point(359, 174);
            this.btn_MostrarContraseña_Login.Name = "btn_MostrarContraseña_Login";
            this.btn_MostrarContraseña_Login.Size = new System.Drawing.Size(28, 29);
            this.btn_MostrarContraseña_Login.TabIndex = 1;
            this.btn_MostrarContraseña_Login.UseVisualStyleBackColor = true;
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 301);
            this.Controls.Add(this.lbl_OlvidarContraseña_Login);
            this.Controls.Add(this.txt_login_Usuari);
            this.Controls.Add(this.txt_Login_Contraseña);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_MostrarContraseña_Login);
            this.Controls.Add(this.btn_Login_Acceder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_Login";
            this.Text = "frm_Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Login_Acceder;
        private System.Windows.Forms.Button btn_MostrarContraseña_Login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Login_Contraseña;
        private System.Windows.Forms.TextBox txt_login_Usuari;
        private System.Windows.Forms.Label lbl_OlvidarContraseña_Login;
    }
}
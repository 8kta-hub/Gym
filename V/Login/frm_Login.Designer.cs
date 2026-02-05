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
            this.pic_GimLogo_Login = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_GimLogo_Login)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Login_Acceder
            // 
            this.btn_Login_Acceder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login_Acceder.Location = new System.Drawing.Point(216, 376);
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
            this.label1.Location = new System.Drawing.Point(215, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuario";
            // 
            // txt_Login_Contraseña
            // 
            this.txt_Login_Contraseña.Location = new System.Drawing.Point(154, 303);
            this.txt_Login_Contraseña.Multiline = true;
            this.txt_Login_Contraseña.Name = "txt_Login_Contraseña";
            this.txt_Login_Contraseña.PasswordChar = '*';
            this.txt_Login_Contraseña.Size = new System.Drawing.Size(199, 29);
            this.txt_Login_Contraseña.TabIndex = 4;
            // 
            // txt_login_Usuari
            // 
            this.txt_login_Usuari.Location = new System.Drawing.Point(154, 227);
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
            this.lbl_OlvidarContraseña_Login.Location = new System.Drawing.Point(152, 338);
            this.lbl_OlvidarContraseña_Login.Name = "lbl_OlvidarContraseña_Login";
            this.lbl_OlvidarContraseña_Login.Size = new System.Drawing.Size(155, 16);
            this.lbl_OlvidarContraseña_Login.TabIndex = 6;
            this.lbl_OlvidarContraseña_Login.Text = "Olvidaste la contraseña?";
            // 
            // btn_MostrarContraseña_Login
            // 
            this.btn_MostrarContraseña_Login.BackgroundImage = global::Gym.Properties.Resources.show;
            this.btn_MostrarContraseña_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_MostrarContraseña_Login.Location = new System.Drawing.Point(360, 303);
            this.btn_MostrarContraseña_Login.Name = "btn_MostrarContraseña_Login";
            this.btn_MostrarContraseña_Login.Size = new System.Drawing.Size(28, 29);
            this.btn_MostrarContraseña_Login.TabIndex = 1;
            this.btn_MostrarContraseña_Login.UseVisualStyleBackColor = true;
            // 
            // pic_GimLogo_Login
            // 
            this.pic_GimLogo_Login.Image = global::Gym.Properties.Resources.barbell_12738426;
            this.pic_GimLogo_Login.Location = new System.Drawing.Point(155, 12);
            this.pic_GimLogo_Login.Name = "pic_GimLogo_Login";
            this.pic_GimLogo_Login.Size = new System.Drawing.Size(198, 180);
            this.pic_GimLogo_Login.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_GimLogo_Login.TabIndex = 7;
            this.pic_GimLogo_Login.TabStop = false;
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 411);
            this.Controls.Add(this.pic_GimLogo_Login);
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
            ((System.ComponentModel.ISupportInitialize)(this.pic_GimLogo_Login)).EndInit();
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
        private System.Windows.Forms.PictureBox pic_GimLogo_Login;
    }
}
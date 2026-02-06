namespace Gym.V.frmHijos.Usuarios
{
    partial class frm_Usuarios_Roles
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
            this.flp_Permisos_UsuariosRoles = new System.Windows.Forms.FlowLayoutPanel();
            this.cmb_Nombre_UsuariosRoles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Guardar_UsuariosRoles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flp_Permisos_UsuariosRoles
            // 
            this.flp_Permisos_UsuariosRoles.BackColor = System.Drawing.Color.White;
            this.flp_Permisos_UsuariosRoles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flp_Permisos_UsuariosRoles.Location = new System.Drawing.Point(12, 77);
            this.flp_Permisos_UsuariosRoles.Name = "flp_Permisos_UsuariosRoles";
            this.flp_Permisos_UsuariosRoles.Size = new System.Drawing.Size(267, 335);
            this.flp_Permisos_UsuariosRoles.TabIndex = 0;
            // 
            // cmb_Nombre_UsuariosRoles
            // 
            this.cmb_Nombre_UsuariosRoles.FormattingEnabled = true;
            this.cmb_Nombre_UsuariosRoles.Location = new System.Drawing.Point(74, 12);
            this.cmb_Nombre_UsuariosRoles.Name = "cmb_Nombre_UsuariosRoles";
            this.cmb_Nombre_UsuariosRoles.Size = new System.Drawing.Size(121, 21);
            this.cmb_Nombre_UsuariosRoles.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Permisos disponibles";
            // 
            // btn_Guardar_UsuariosRoles
            // 
            this.btn_Guardar_UsuariosRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Guardar_UsuariosRoles.Location = new System.Drawing.Point(204, 418);
            this.btn_Guardar_UsuariosRoles.Name = "btn_Guardar_UsuariosRoles";
            this.btn_Guardar_UsuariosRoles.Size = new System.Drawing.Size(75, 23);
            this.btn_Guardar_UsuariosRoles.TabIndex = 14;
            this.btn_Guardar_UsuariosRoles.Text = "Guardar";
            this.btn_Guardar_UsuariosRoles.UseVisualStyleBackColor = true;
            // 
            // frm_Usuarios_Roles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 445);
            this.Controls.Add(this.btn_Guardar_UsuariosRoles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_Nombre_UsuariosRoles);
            this.Controls.Add(this.flp_Permisos_UsuariosRoles);
            this.Name = "frm_Usuarios_Roles";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roles de usuarios";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_Permisos_UsuariosRoles;
        private System.Windows.Forms.ComboBox cmb_Nombre_UsuariosRoles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Guardar_UsuariosRoles;
    }
}
namespace Gym.V.frmHijos.Roles
{
    partial class frm_Roles_Nuevo
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
            this.btn_Guardar_RolesNuevo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Nombre_RolesNuevo = new System.Windows.Forms.TextBox();
            this.chk_RolActivo = new System.Windows.Forms.CheckBox();
            this.clb_Permisos_RolesNuevo = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Descripcion_RolesNuevo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Guardar_RolesNuevo
            // 
            this.btn_Guardar_RolesNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Guardar_RolesNuevo.Location = new System.Drawing.Point(205, 453);
            this.btn_Guardar_RolesNuevo.Name = "btn_Guardar_RolesNuevo";
            this.btn_Guardar_RolesNuevo.Size = new System.Drawing.Size(75, 23);
            this.btn_Guardar_RolesNuevo.TabIndex = 19;
            this.btn_Guardar_RolesNuevo.Text = "Guardar";
            this.btn_Guardar_RolesNuevo.UseVisualStyleBackColor = true;
            this.btn_Guardar_RolesNuevo.Click += new System.EventHandler(this.btn_Guardar_RolesNuevo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Permisos disponibles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nombre";
            // 
            // txt_Nombre_RolesNuevo
            // 
            this.txt_Nombre_RolesNuevo.Location = new System.Drawing.Point(104, 12);
            this.txt_Nombre_RolesNuevo.Name = "txt_Nombre_RolesNuevo";
            this.txt_Nombre_RolesNuevo.Size = new System.Drawing.Size(172, 20);
            this.txt_Nombre_RolesNuevo.TabIndex = 20;
            // 
            // chk_RolActivo
            // 
            this.chk_RolActivo.AutoSize = true;
            this.chk_RolActivo.Location = new System.Drawing.Point(12, 458);
            this.chk_RolActivo.Name = "chk_RolActivo";
            this.chk_RolActivo.Size = new System.Drawing.Size(75, 17);
            this.chk_RolActivo.TabIndex = 21;
            this.chk_RolActivo.Text = "Rol Activo";
            this.chk_RolActivo.UseVisualStyleBackColor = true;
            // 
            // clb_Permisos_RolesNuevo
            // 
            this.clb_Permisos_RolesNuevo.FormattingEnabled = true;
            this.clb_Permisos_RolesNuevo.Location = new System.Drawing.Point(13, 68);
            this.clb_Permisos_RolesNuevo.Name = "clb_Permisos_RolesNuevo";
            this.clb_Permisos_RolesNuevo.Size = new System.Drawing.Size(263, 289);
            this.clb_Permisos_RolesNuevo.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Descripcion";
            // 
            // txt_Descripcion_RolesNuevo
            // 
            this.txt_Descripcion_RolesNuevo.Location = new System.Drawing.Point(104, 371);
            this.txt_Descripcion_RolesNuevo.Multiline = true;
            this.txt_Descripcion_RolesNuevo.Name = "txt_Descripcion_RolesNuevo";
            this.txt_Descripcion_RolesNuevo.Size = new System.Drawing.Size(172, 52);
            this.txt_Descripcion_RolesNuevo.TabIndex = 24;
            // 
            // frm_Roles_Nuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 488);
            this.Controls.Add(this.txt_Descripcion_RolesNuevo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clb_Permisos_RolesNuevo);
            this.Controls.Add(this.chk_RolActivo);
            this.Controls.Add(this.txt_Nombre_RolesNuevo);
            this.Controls.Add(this.btn_Guardar_RolesNuevo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Roles_Nuevo";
            this.ShowIcon = false;
            this.Text = "Datos del rol";
            this.Load += new System.EventHandler(this.frm_Roles_Nuevo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Guardar_RolesNuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Nombre_RolesNuevo;
        private System.Windows.Forms.CheckBox chk_RolActivo;
        private System.Windows.Forms.CheckedListBox clb_Permisos_RolesNuevo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Descripcion_RolesNuevo;
    }
}
namespace Gym.V.frmHijos.Conceptos
{
    partial class frm_Conceptos_Nuevo
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
            this.txt_Nombre_ConceptosNuevo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Guardar_ConceptosNuevo = new System.Windows.Forms.Button();
            this.cmb_Tipo_ConceptosNuevo = new System.Windows.Forms.ComboBox();
            this.chk_ConceptoActivo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txt_Nombre_ConceptosNuevo
            // 
            this.txt_Nombre_ConceptosNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Nombre_ConceptosNuevo.Location = new System.Drawing.Point(82, 19);
            this.txt_Nombre_ConceptosNuevo.Name = "txt_Nombre_ConceptosNuevo";
            this.txt_Nombre_ConceptosNuevo.Size = new System.Drawing.Size(192, 24);
            this.txt_Nombre_ConceptosNuevo.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nombre";
            // 
            // btn_Guardar_ConceptosNuevo
            // 
            this.btn_Guardar_ConceptosNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Guardar_ConceptosNuevo.Location = new System.Drawing.Point(199, 139);
            this.btn_Guardar_ConceptosNuevo.Name = "btn_Guardar_ConceptosNuevo";
            this.btn_Guardar_ConceptosNuevo.Size = new System.Drawing.Size(75, 23);
            this.btn_Guardar_ConceptosNuevo.TabIndex = 16;
            this.btn_Guardar_ConceptosNuevo.Text = "Guardar";
            this.btn_Guardar_ConceptosNuevo.UseVisualStyleBackColor = true;
            this.btn_Guardar_ConceptosNuevo.Click += new System.EventHandler(this.btn_Guardar_ConceptosNuevo_Click);
            // 
            // cmb_Tipo_ConceptosNuevo
            // 
            this.cmb_Tipo_ConceptosNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Tipo_ConceptosNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Tipo_ConceptosNuevo.FormattingEnabled = true;
            this.cmb_Tipo_ConceptosNuevo.Location = new System.Drawing.Point(82, 59);
            this.cmb_Tipo_ConceptosNuevo.Name = "cmb_Tipo_ConceptosNuevo";
            this.cmb_Tipo_ConceptosNuevo.Size = new System.Drawing.Size(121, 26);
            this.cmb_Tipo_ConceptosNuevo.TabIndex = 17;
            // 
            // chk_ConceptoActivo
            // 
            this.chk_ConceptoActivo.AutoSize = true;
            this.chk_ConceptoActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_ConceptoActivo.Location = new System.Drawing.Point(19, 108);
            this.chk_ConceptoActivo.Name = "chk_ConceptoActivo";
            this.chk_ConceptoActivo.Size = new System.Drawing.Size(123, 20);
            this.chk_ConceptoActivo.TabIndex = 18;
            this.chk_ConceptoActivo.Text = "Concepto activo";
            this.chk_ConceptoActivo.UseVisualStyleBackColor = true;
            // 
            // frm_Conceptos_Nuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 174);
            this.Controls.Add(this.chk_ConceptoActivo);
            this.Controls.Add(this.cmb_Tipo_ConceptosNuevo);
            this.Controls.Add(this.btn_Guardar_ConceptosNuevo);
            this.Controls.Add(this.txt_Nombre_ConceptosNuevo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Conceptos_Nuevo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos del concepto";
            this.Load += new System.EventHandler(this.frm_Conceptos_Nuevo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Nombre_ConceptosNuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Guardar_ConceptosNuevo;
        private System.Windows.Forms.ComboBox cmb_Tipo_ConceptosNuevo;
        private System.Windows.Forms.CheckBox chk_ConceptoActivo;
    }
}
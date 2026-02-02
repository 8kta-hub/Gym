namespace Gym.V.frmHijos.Productos
{
    partial class frm_Productos
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Nuevo_Productos = new System.Windows.Forms.Button();
            this.btn_Modificar_Productos = new System.Windows.Forms.Button();
            this.btn_Deshabilitar_Productos = new System.Windows.Forms.Button();
            this.btn_Habilitar_Productos = new System.Windows.Forms.Button();
            this.btn_Eliminar_Productos = new System.Windows.Forms.Button();
            this.btn_Exportar_Productos = new System.Windows.Forms.Button();
            this.dgv_Productos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Productos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Productos";
            // 
            // btn_Nuevo_Productos
            // 
            this.btn_Nuevo_Productos.Location = new System.Drawing.Point(47, 55);
            this.btn_Nuevo_Productos.Name = "btn_Nuevo_Productos";
            this.btn_Nuevo_Productos.Size = new System.Drawing.Size(75, 23);
            this.btn_Nuevo_Productos.TabIndex = 1;
            this.btn_Nuevo_Productos.Text = "Nuevo";
            this.btn_Nuevo_Productos.UseVisualStyleBackColor = true;
            // 
            // btn_Modificar_Productos
            // 
            this.btn_Modificar_Productos.Location = new System.Drawing.Point(162, 55);
            this.btn_Modificar_Productos.Name = "btn_Modificar_Productos";
            this.btn_Modificar_Productos.Size = new System.Drawing.Size(75, 23);
            this.btn_Modificar_Productos.TabIndex = 2;
            this.btn_Modificar_Productos.Text = "Modificar";
            this.btn_Modificar_Productos.UseVisualStyleBackColor = true;
            // 
            // btn_Deshabilitar_Productos
            // 
            this.btn_Deshabilitar_Productos.Location = new System.Drawing.Point(278, 55);
            this.btn_Deshabilitar_Productos.Name = "btn_Deshabilitar_Productos";
            this.btn_Deshabilitar_Productos.Size = new System.Drawing.Size(75, 23);
            this.btn_Deshabilitar_Productos.TabIndex = 3;
            this.btn_Deshabilitar_Productos.Text = "Deshabilitar";
            this.btn_Deshabilitar_Productos.UseVisualStyleBackColor = true;
            // 
            // btn_Habilitar_Productos
            // 
            this.btn_Habilitar_Productos.Location = new System.Drawing.Point(398, 55);
            this.btn_Habilitar_Productos.Name = "btn_Habilitar_Productos";
            this.btn_Habilitar_Productos.Size = new System.Drawing.Size(75, 23);
            this.btn_Habilitar_Productos.TabIndex = 4;
            this.btn_Habilitar_Productos.Text = "Habilitar";
            this.btn_Habilitar_Productos.UseVisualStyleBackColor = true;
            // 
            // btn_Eliminar_Productos
            // 
            this.btn_Eliminar_Productos.Location = new System.Drawing.Point(516, 55);
            this.btn_Eliminar_Productos.Name = "btn_Eliminar_Productos";
            this.btn_Eliminar_Productos.Size = new System.Drawing.Size(75, 23);
            this.btn_Eliminar_Productos.TabIndex = 5;
            this.btn_Eliminar_Productos.Text = "Eliminar";
            this.btn_Eliminar_Productos.UseVisualStyleBackColor = true;
            // 
            // btn_Exportar_Productos
            // 
            this.btn_Exportar_Productos.Location = new System.Drawing.Point(637, 55);
            this.btn_Exportar_Productos.Name = "btn_Exportar_Productos";
            this.btn_Exportar_Productos.Size = new System.Drawing.Size(101, 23);
            this.btn_Exportar_Productos.TabIndex = 6;
            this.btn_Exportar_Productos.Text = "Exportar Excel";
            this.btn_Exportar_Productos.UseVisualStyleBackColor = true;
            // 
            // dgv_Productos
            // 
            this.dgv_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Productos.Location = new System.Drawing.Point(12, 94);
            this.dgv_Productos.Name = "dgv_Productos";
            this.dgv_Productos.Size = new System.Drawing.Size(776, 344);
            this.dgv_Productos.TabIndex = 7;
            // 
            // frm_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_Productos);
            this.Controls.Add(this.btn_Exportar_Productos);
            this.Controls.Add(this.btn_Eliminar_Productos);
            this.Controls.Add(this.btn_Habilitar_Productos);
            this.Controls.Add(this.btn_Deshabilitar_Productos);
            this.Controls.Add(this.btn_Modificar_Productos);
            this.Controls.Add(this.btn_Nuevo_Productos);
            this.Controls.Add(this.label1);
            this.Name = "frm_Productos";
            this.Text = "frm_Productos";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Productos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Nuevo_Productos;
        private System.Windows.Forms.Button btn_Modificar_Productos;
        private System.Windows.Forms.Button btn_Deshabilitar_Productos;
        private System.Windows.Forms.Button btn_Habilitar_Productos;
        private System.Windows.Forms.Button btn_Eliminar_Productos;
        private System.Windows.Forms.Button btn_Exportar_Productos;
        private System.Windows.Forms.DataGridView dgv_Productos;
    }
}
namespace Gym.V.frmHijos.Productos
{
    partial class frm_Productos_Proveedores
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
            this.btn_Agregar_Proveedor = new System.Windows.Forms.Button();
            this.cbm_Filtro_Proveedor = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Modificar_Proveedor = new System.Windows.Forms.Button();
            this.btn_Eliminar_Proveedor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Agregar_Proveedor
            // 
            this.btn_Agregar_Proveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Agregar_Proveedor.Location = new System.Drawing.Point(12, 12);
            this.btn_Agregar_Proveedor.Name = "btn_Agregar_Proveedor";
            this.btn_Agregar_Proveedor.Size = new System.Drawing.Size(66, 23);
            this.btn_Agregar_Proveedor.TabIndex = 0;
            this.btn_Agregar_Proveedor.Text = "Agregar";
            this.btn_Agregar_Proveedor.UseVisualStyleBackColor = true;
            // 
            // cbm_Filtro_Proveedor
            // 
            this.cbm_Filtro_Proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbm_Filtro_Proveedor.FormattingEnabled = true;
            this.cbm_Filtro_Proveedor.Location = new System.Drawing.Point(251, 14);
            this.cbm_Filtro_Proveedor.Name = "cbm_Filtro_Proveedor";
            this.cbm_Filtro_Proveedor.Size = new System.Drawing.Size(100, 21);
            this.cbm_Filtro_Proveedor.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(663, 311);
            this.dataGridView1.TabIndex = 4;
            // 
            // btn_Modificar_Proveedor
            // 
            this.btn_Modificar_Proveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Modificar_Proveedor.Location = new System.Drawing.Point(84, 12);
            this.btn_Modificar_Proveedor.Name = "btn_Modificar_Proveedor";
            this.btn_Modificar_Proveedor.Size = new System.Drawing.Size(81, 23);
            this.btn_Modificar_Proveedor.TabIndex = 5;
            this.btn_Modificar_Proveedor.Text = "Modificar";
            this.btn_Modificar_Proveedor.UseVisualStyleBackColor = true;
            // 
            // btn_Eliminar_Proveedor
            // 
            this.btn_Eliminar_Proveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar_Proveedor.Location = new System.Drawing.Point(171, 12);
            this.btn_Eliminar_Proveedor.Name = "btn_Eliminar_Proveedor";
            this.btn_Eliminar_Proveedor.Size = new System.Drawing.Size(74, 23);
            this.btn_Eliminar_Proveedor.TabIndex = 6;
            this.btn_Eliminar_Proveedor.Text = "Eliminar";
            this.btn_Eliminar_Proveedor.UseVisualStyleBackColor = true;
            // 
            // frm_Productos_Proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 364);
            this.Controls.Add(this.btn_Eliminar_Proveedor);
            this.Controls.Add(this.btn_Modificar_Proveedor);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbm_Filtro_Proveedor);
            this.Controls.Add(this.btn_Agregar_Proveedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Productos_Proveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Agregar_Proveedor;
        private System.Windows.Forms.ComboBox cbm_Filtro_Proveedor;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Modificar_Proveedor;
        private System.Windows.Forms.Button btn_Eliminar_Proveedor;
    }
}
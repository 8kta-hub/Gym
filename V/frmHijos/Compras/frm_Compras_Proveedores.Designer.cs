namespace Gym.V.frmHijos.Compras
{
    partial class frm_Compras_Proveedores
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
            this.dvg_Proveedores = new System.Windows.Forms.DataGridView();
            this.btn_Modificar_Proveedor = new System.Windows.Forms.Button();
            this.btn_Eliminar_Proveedor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_Proveedores)).BeginInit();
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
            this.btn_Agregar_Proveedor.Click += new System.EventHandler(this.btn_Agregar_Proveedor_Click);
            // 
            // cbm_Filtro_Proveedor
            // 
            this.cbm_Filtro_Proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbm_Filtro_Proveedor.FormattingEnabled = true;
            this.cbm_Filtro_Proveedor.Location = new System.Drawing.Point(251, 14);
            this.cbm_Filtro_Proveedor.Name = "cbm_Filtro_Proveedor";
            this.cbm_Filtro_Proveedor.Size = new System.Drawing.Size(100, 21);
            this.cbm_Filtro_Proveedor.TabIndex = 3;
            this.cbm_Filtro_Proveedor.SelectedIndexChanged += new System.EventHandler(this.cbm_Filtro_Proveedor_SelectedIndexChanged);
            // 
            // dvg_Proveedores
            // 
            this.dvg_Proveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvg_Proveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvg_Proveedores.Location = new System.Drawing.Point(12, 41);
            this.dvg_Proveedores.MultiSelect = false;
            this.dvg_Proveedores.Name = "dvg_Proveedores";
            this.dvg_Proveedores.ReadOnly = true;
            this.dvg_Proveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvg_Proveedores.Size = new System.Drawing.Size(663, 311);
            this.dvg_Proveedores.TabIndex = 4;
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
            this.btn_Modificar_Proveedor.Click += new System.EventHandler(this.btn_Modificar_Proveedor_Click);
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
            this.btn_Eliminar_Proveedor.Click += new System.EventHandler(this.btn_Eliminar_Proveedor_Click);
            // 
            // frm_Compras_Proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 364);
            this.Controls.Add(this.btn_Eliminar_Proveedor);
            this.Controls.Add(this.btn_Modificar_Proveedor);
            this.Controls.Add(this.dvg_Proveedores);
            this.Controls.Add(this.cbm_Filtro_Proveedor);
            this.Controls.Add(this.btn_Agregar_Proveedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Compras_Proveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.frm_Compras_Proveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvg_Proveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Agregar_Proveedor;
        private System.Windows.Forms.ComboBox cbm_Filtro_Proveedor;
        private System.Windows.Forms.DataGridView dvg_Proveedores;
        private System.Windows.Forms.Button btn_Modificar_Proveedor;
        private System.Windows.Forms.Button btn_Eliminar_Proveedor;
    }
}
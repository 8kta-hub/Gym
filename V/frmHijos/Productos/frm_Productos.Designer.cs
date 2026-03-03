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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Productos));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Nuevo_Productos = new System.Windows.Forms.Button();
            this.btn_Modificar_Productos = new System.Windows.Forms.Button();
            this.btn_Eliminar_Productos = new System.Windows.Forms.Button();
            this.dgv_Productos = new System.Windows.Forms.DataGridView();
            this.cbm_FiltroProducto = new System.Windows.Forms.ComboBox();
            this.btn_ExportarExcel_Productos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Productos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "PRODUCTOS";
            // 
            // btn_Nuevo_Productos
            // 
            this.btn_Nuevo_Productos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Nuevo_Productos.Location = new System.Drawing.Point(12, 50);
            this.btn_Nuevo_Productos.Name = "btn_Nuevo_Productos";
            this.btn_Nuevo_Productos.Size = new System.Drawing.Size(66, 23);
            this.btn_Nuevo_Productos.TabIndex = 1;
            this.btn_Nuevo_Productos.Text = "Nuevo";
            this.btn_Nuevo_Productos.UseVisualStyleBackColor = true;
            this.btn_Nuevo_Productos.Click += new System.EventHandler(this.btn_Nuevo_Productos_Click);
            // 
            // btn_Modificar_Productos
            // 
            this.btn_Modificar_Productos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Modificar_Productos.Location = new System.Drawing.Point(84, 50);
            this.btn_Modificar_Productos.Name = "btn_Modificar_Productos";
            this.btn_Modificar_Productos.Size = new System.Drawing.Size(75, 23);
            this.btn_Modificar_Productos.TabIndex = 2;
            this.btn_Modificar_Productos.Text = "Modificar";
            this.btn_Modificar_Productos.UseVisualStyleBackColor = true;
            this.btn_Modificar_Productos.Click += new System.EventHandler(this.btn_Modificar_Productos_Click);
            // 
            // btn_Eliminar_Productos
            // 
            this.btn_Eliminar_Productos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar_Productos.Location = new System.Drawing.Point(165, 50);
            this.btn_Eliminar_Productos.Name = "btn_Eliminar_Productos";
            this.btn_Eliminar_Productos.Size = new System.Drawing.Size(75, 23);
            this.btn_Eliminar_Productos.TabIndex = 5;
            this.btn_Eliminar_Productos.Text = "Eliminar";
            this.btn_Eliminar_Productos.UseVisualStyleBackColor = true;
            this.btn_Eliminar_Productos.Click += new System.EventHandler(this.btn_Eliminar_Productos_Click);
            // 
            // dgv_Productos
            // 
            this.dgv_Productos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Productos.Location = new System.Drawing.Point(12, 79);
            this.dgv_Productos.Name = "dgv_Productos";
            this.dgv_Productos.Size = new System.Drawing.Size(1004, 280);
            this.dgv_Productos.TabIndex = 7;
            this.dgv_Productos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_Productos_DataBindingComplete);
            // 
            // cbm_FiltroProducto
            // 
            this.cbm_FiltroProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbm_FiltroProducto.FormattingEnabled = true;
            this.cbm_FiltroProducto.Location = new System.Drawing.Point(289, 50);
            this.cbm_FiltroProducto.Name = "cbm_FiltroProducto";
            this.cbm_FiltroProducto.Size = new System.Drawing.Size(121, 21);
            this.cbm_FiltroProducto.TabIndex = 40;
            // 
            // btn_ExportarExcel_Productos
            // 
            this.btn_ExportarExcel_Productos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ExportarExcel_Productos.BackgroundImage")));
            this.btn_ExportarExcel_Productos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ExportarExcel_Productos.Location = new System.Drawing.Point(246, 41);
            this.btn_ExportarExcel_Productos.Name = "btn_ExportarExcel_Productos";
            this.btn_ExportarExcel_Productos.Size = new System.Drawing.Size(33, 32);
            this.btn_ExportarExcel_Productos.TabIndex = 38;
            this.btn_ExportarExcel_Productos.UseVisualStyleBackColor = true;
            // 
            // frm_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 366);
            this.Controls.Add(this.cbm_FiltroProducto);
            this.Controls.Add(this.btn_ExportarExcel_Productos);
            this.Controls.Add(this.dgv_Productos);
            this.Controls.Add(this.btn_Eliminar_Productos);
            this.Controls.Add(this.btn_Modificar_Productos);
            this.Controls.Add(this.btn_Nuevo_Productos);
            this.Controls.Add(this.label1);
            this.Name = "frm_Productos";
            this.Text = "frm_Productos";
            this.Load += new System.EventHandler(this.frm_Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Productos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Nuevo_Productos;
        private System.Windows.Forms.Button btn_Modificar_Productos;
        private System.Windows.Forms.Button btn_Eliminar_Productos;
        private System.Windows.Forms.DataGridView dgv_Productos;
        private System.Windows.Forms.Button btn_ExportarExcel_Productos;
        private System.Windows.Forms.ComboBox cbm_FiltroProducto;
    }
}
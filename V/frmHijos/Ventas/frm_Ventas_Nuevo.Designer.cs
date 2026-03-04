namespace Gym.V.frmHijos.Ventas
{
    partial class frm_Ventas_Nuevo
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
            this.btn_RealizarVentas_VentasNuevo = new System.Windows.Forms.Button();
            this.cmb_TipoPago_VentasNuevo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_Total_VentasNuevo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_VentasNuevo = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Limpiar_VentasNuevo = new System.Windows.Forms.Button();
            this.btn_Eliminar_VentasNuevo = new System.Windows.Forms.Button();
            this.cmb_Cliente_VentasNuevo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_Precio_VentasNuevo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_Costo_VentasNuevo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Agregar_VentasNuevo = new System.Windows.Forms.Button();
            this.txt_Cantidad_VentasNuevo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_Producto_VentasNuevo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Codigo_VentasNuevo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_VentasNuevo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_RealizarVentas_VentasNuevo
            // 
            this.btn_RealizarVentas_VentasNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RealizarVentas_VentasNuevo.Location = new System.Drawing.Point(669, 418);
            this.btn_RealizarVentas_VentasNuevo.Name = "btn_RealizarVentas_VentasNuevo";
            this.btn_RealizarVentas_VentasNuevo.Size = new System.Drawing.Size(119, 27);
            this.btn_RealizarVentas_VentasNuevo.TabIndex = 18;
            this.btn_RealizarVentas_VentasNuevo.Text = "Realizar Venta";
            this.btn_RealizarVentas_VentasNuevo.UseVisualStyleBackColor = true;
            this.btn_RealizarVentas_VentasNuevo.Click += new System.EventHandler(this.btn_RealizarVentas_VentasNuevo_Click);
            // 
            // cmb_TipoPago_VentasNuevo
            // 
            this.cmb_TipoPago_VentasNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TipoPago_VentasNuevo.FormattingEnabled = true;
            this.cmb_TipoPago_VentasNuevo.Location = new System.Drawing.Point(521, 422);
            this.cmb_TipoPago_VentasNuevo.Name = "cmb_TipoPago_VentasNuevo";
            this.cmb_TipoPago_VentasNuevo.Size = new System.Drawing.Size(106, 21);
            this.cmb_TipoPago_VentasNuevo.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(425, 423);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Tipo de Pago";
            // 
            // lbl_Total_VentasNuevo
            // 
            this.lbl_Total_VentasNuevo.AutoSize = true;
            this.lbl_Total_VentasNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Total_VentasNuevo.Location = new System.Drawing.Point(71, 420);
            this.lbl_Total_VentasNuevo.Name = "lbl_Total_VentasNuevo";
            this.lbl_Total_VentasNuevo.Size = new System.Drawing.Size(54, 24);
            this.lbl_Total_VentasNuevo.TabIndex = 16;
            this.lbl_Total_VentasNuevo.Text = "####";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 421);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Total";
            // 
            // dgv_VentasNuevo
            // 
            this.dgv_VentasNuevo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_VentasNuevo.Location = new System.Drawing.Point(16, 183);
            this.dgv_VentasNuevo.Name = "dgv_VentasNuevo";
            this.dgv_VentasNuevo.Size = new System.Drawing.Size(776, 229);
            this.dgv_VentasNuevo.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Limpiar_VentasNuevo);
            this.groupBox1.Controls.Add(this.btn_Eliminar_VentasNuevo);
            this.groupBox1.Controls.Add(this.cmb_Cliente_VentasNuevo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lbl_Precio_VentasNuevo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbl_Costo_VentasNuevo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btn_Agregar_VentasNuevo);
            this.groupBox1.Controls.Add(this.txt_Cantidad_VentasNuevo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_Producto_VentasNuevo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_Codigo_VentasNuevo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 153);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del producto";
            // 
            // btn_Limpiar_VentasNuevo
            // 
            this.btn_Limpiar_VentasNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Limpiar_VentasNuevo.Location = new System.Drawing.Point(657, 119);
            this.btn_Limpiar_VentasNuevo.Name = "btn_Limpiar_VentasNuevo";
            this.btn_Limpiar_VentasNuevo.Size = new System.Drawing.Size(107, 27);
            this.btn_Limpiar_VentasNuevo.TabIndex = 45;
            this.btn_Limpiar_VentasNuevo.Text = "Limpiar todo";
            this.btn_Limpiar_VentasNuevo.UseVisualStyleBackColor = true;
            this.btn_Limpiar_VentasNuevo.Click += new System.EventHandler(this.btn_Limpiar_VentasNuevo_Click);
            // 
            // btn_Eliminar_VentasNuevo
            // 
            this.btn_Eliminar_VentasNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar_VentasNuevo.Location = new System.Drawing.Point(523, 119);
            this.btn_Eliminar_VentasNuevo.Name = "btn_Eliminar_VentasNuevo";
            this.btn_Eliminar_VentasNuevo.Size = new System.Drawing.Size(131, 27);
            this.btn_Eliminar_VentasNuevo.TabIndex = 44;
            this.btn_Eliminar_VentasNuevo.Text = "Eliminar venta";
            this.btn_Eliminar_VentasNuevo.UseVisualStyleBackColor = true;
            this.btn_Eliminar_VentasNuevo.Click += new System.EventHandler(this.btn_Eliminar_VentasNuevo_Click);
            // 
            // cmb_Cliente_VentasNuevo
            // 
            this.cmb_Cliente_VentasNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Cliente_VentasNuevo.FormattingEnabled = true;
            this.cmb_Cliente_VentasNuevo.Location = new System.Drawing.Point(85, 21);
            this.cmb_Cliente_VentasNuevo.Name = "cmb_Cliente_VentasNuevo";
            this.cmb_Cliente_VentasNuevo.Size = new System.Drawing.Size(233, 21);
            this.cmb_Cliente_VentasNuevo.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 42;
            this.label7.Text = "Cliente";
            // 
            // lbl_Precio_VentasNuevo
            // 
            this.lbl_Precio_VentasNuevo.AutoSize = true;
            this.lbl_Precio_VentasNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Precio_VentasNuevo.Location = new System.Drawing.Point(522, 48);
            this.lbl_Precio_VentasNuevo.Name = "lbl_Precio_VentasNuevo";
            this.lbl_Precio_VentasNuevo.Size = new System.Drawing.Size(54, 24);
            this.lbl_Precio_VentasNuevo.TabIndex = 41;
            this.lbl_Precio_VentasNuevo.Text = "####";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(441, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 40;
            this.label6.Text = "Precio";
            // 
            // lbl_Costo_VentasNuevo
            // 
            this.lbl_Costo_VentasNuevo.AutoSize = true;
            this.lbl_Costo_VentasNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Costo_VentasNuevo.Location = new System.Drawing.Point(522, 17);
            this.lbl_Costo_VentasNuevo.Name = "lbl_Costo_VentasNuevo";
            this.lbl_Costo_VentasNuevo.Size = new System.Drawing.Size(54, 24);
            this.lbl_Costo_VentasNuevo.TabIndex = 39;
            this.lbl_Costo_VentasNuevo.Text = "####";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(441, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Costo";
            // 
            // btn_Agregar_VentasNuevo
            // 
            this.btn_Agregar_VentasNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Agregar_VentasNuevo.Location = new System.Drawing.Point(445, 119);
            this.btn_Agregar_VentasNuevo.Name = "btn_Agregar_VentasNuevo";
            this.btn_Agregar_VentasNuevo.Size = new System.Drawing.Size(72, 28);
            this.btn_Agregar_VentasNuevo.TabIndex = 37;
            this.btn_Agregar_VentasNuevo.Text = "Agregar";
            this.btn_Agregar_VentasNuevo.UseVisualStyleBackColor = true;
            this.btn_Agregar_VentasNuevo.Click += new System.EventHandler(this.btn_Agregar_VentasNuevo_Click);
            // 
            // txt_Cantidad_VentasNuevo
            // 
            this.txt_Cantidad_VentasNuevo.Location = new System.Drawing.Point(85, 114);
            this.txt_Cantidad_VentasNuevo.Name = "txt_Cantidad_VentasNuevo";
            this.txt_Cantidad_VentasNuevo.Size = new System.Drawing.Size(145, 20);
            this.txt_Cantidad_VentasNuevo.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "Cantidad";
            // 
            // cmb_Producto_VentasNuevo
            // 
            this.cmb_Producto_VentasNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Producto_VentasNuevo.FormattingEnabled = true;
            this.cmb_Producto_VentasNuevo.Location = new System.Drawing.Point(85, 49);
            this.cmb_Producto_VentasNuevo.Name = "cmb_Producto_VentasNuevo";
            this.cmb_Producto_VentasNuevo.Size = new System.Drawing.Size(233, 21);
            this.cmb_Producto_VentasNuevo.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Producto";
            // 
            // txt_Codigo_VentasNuevo
            // 
            this.txt_Codigo_VentasNuevo.Location = new System.Drawing.Point(85, 78);
            this.txt_Codigo_VentasNuevo.Name = "txt_Codigo_VentasNuevo";
            this.txt_Codigo_VentasNuevo.Size = new System.Drawing.Size(145, 20);
            this.txt_Codigo_VentasNuevo.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "Codigo";
            // 
            // frm_Ventas_Nuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 457);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_RealizarVentas_VentasNuevo);
            this.Controls.Add(this.cmb_TipoPago_VentasNuevo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_Total_VentasNuevo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgv_VentasNuevo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Ventas_Nuevo";
            this.ShowIcon = false;
            this.Text = "Nueva venta";
            this.Load += new System.EventHandler(this.frm_Ventas_Nuevo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_VentasNuevo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_RealizarVentas_VentasNuevo;
        private System.Windows.Forms.ComboBox cmb_TipoPago_VentasNuevo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_Total_VentasNuevo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_VentasNuevo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_Precio_VentasNuevo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_Costo_VentasNuevo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Agregar_VentasNuevo;
        private System.Windows.Forms.TextBox txt_Cantidad_VentasNuevo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_Producto_VentasNuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Codigo_VentasNuevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Cliente_VentasNuevo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Eliminar_VentasNuevo;
        private System.Windows.Forms.Button btn_Limpiar_VentasNuevo;
    }
}
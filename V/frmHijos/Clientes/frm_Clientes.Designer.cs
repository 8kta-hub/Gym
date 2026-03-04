namespace Gym.V.frmHijos.Clientes
{
    partial class frm_Clientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Clientes));
            this.txt_Buscar_Clientes = new System.Windows.Forms.TextBox();
            this.btn_Eliminar_Clientes = new System.Windows.Forms.Button();
            this.btn_Modificar_Clientes = new System.Windows.Forms.Button();
            this.btn_Nuevo_Clientes = new System.Windows.Forms.Button();
            this.dgv_Clientes = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_resultadosCantidad_Clientes = new System.Windows.Forms.Label();
            this.btn_VerUltimos_Clientes = new System.Windows.Forms.Button();
            this.btn_VerTodo_Clientes = new System.Windows.Forms.Button();
            this.btn_Membresias_Clientes = new System.Windows.Forms.Button();
            this.btn_ExportarExcel_Clientes = new System.Windows.Forms.Button();
            this.cbx_FiltroCliente = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Buscar_Clientes
            // 
            this.txt_Buscar_Clientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Buscar_Clientes.Location = new System.Drawing.Point(8, 69);
            this.txt_Buscar_Clientes.Name = "txt_Buscar_Clientes";
            this.txt_Buscar_Clientes.Size = new System.Drawing.Size(369, 24);
            this.txt_Buscar_Clientes.TabIndex = 31;
            this.txt_Buscar_Clientes.TextChanged += new System.EventHandler(this.txt_Buscar_Clientes_TextChanged);
            // 
            // btn_Eliminar_Clientes
            // 
            this.btn_Eliminar_Clientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar_Clientes.Location = new System.Drawing.Point(160, 45);
            this.btn_Eliminar_Clientes.Name = "btn_Eliminar_Clientes";
            this.btn_Eliminar_Clientes.Size = new System.Drawing.Size(75, 23);
            this.btn_Eliminar_Clientes.TabIndex = 29;
            this.btn_Eliminar_Clientes.Text = "Eliminar";
            this.btn_Eliminar_Clientes.UseVisualStyleBackColor = true;
            this.btn_Eliminar_Clientes.Click += new System.EventHandler(this.btn_Eliminar_Clientes_Click);
            // 
            // btn_Modificar_Clientes
            // 
            this.btn_Modificar_Clientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Modificar_Clientes.Location = new System.Drawing.Point(79, 45);
            this.btn_Modificar_Clientes.Name = "btn_Modificar_Clientes";
            this.btn_Modificar_Clientes.Size = new System.Drawing.Size(75, 23);
            this.btn_Modificar_Clientes.TabIndex = 26;
            this.btn_Modificar_Clientes.Text = "Modificar";
            this.btn_Modificar_Clientes.UseVisualStyleBackColor = true;
            this.btn_Modificar_Clientes.Click += new System.EventHandler(this.btn_Modificar_Clientes_Click);
            // 
            // btn_Nuevo_Clientes
            // 
            this.btn_Nuevo_Clientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Nuevo_Clientes.Location = new System.Drawing.Point(8, 45);
            this.btn_Nuevo_Clientes.Name = "btn_Nuevo_Clientes";
            this.btn_Nuevo_Clientes.Size = new System.Drawing.Size(65, 23);
            this.btn_Nuevo_Clientes.TabIndex = 25;
            this.btn_Nuevo_Clientes.Text = "Nuevo";
            this.btn_Nuevo_Clientes.UseVisualStyleBackColor = true;
            this.btn_Nuevo_Clientes.Click += new System.EventHandler(this.btn_Nuevo_Clientes_Click);
            // 
            // dgv_Clientes
            // 
            this.dgv_Clientes.AllowUserToResizeColumns = false;
            this.dgv_Clientes.AllowUserToResizeRows = false;
            this.dgv_Clientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Clientes.Location = new System.Drawing.Point(8, 100);
            this.dgv_Clientes.MultiSelect = false;
            this.dgv_Clientes.Name = "dgv_Clientes";
            this.dgv_Clientes.ReadOnly = true;
            this.dgv_Clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Clientes.Size = new System.Drawing.Size(1011, 259);
            this.dgv_Clientes.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "CLIENTES";
            // 
            // lbl_resultadosCantidad_Clientes
            // 
            this.lbl_resultadosCantidad_Clientes.AutoSize = true;
            this.lbl_resultadosCantidad_Clientes.Enabled = false;
            this.lbl_resultadosCantidad_Clientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_resultadosCantidad_Clientes.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_resultadosCantidad_Clientes.Location = new System.Drawing.Point(947, 76);
            this.lbl_resultadosCantidad_Clientes.Name = "lbl_resultadosCantidad_Clientes";
            this.lbl_resultadosCantidad_Clientes.Size = new System.Drawing.Size(56, 16);
            this.lbl_resultadosCantidad_Clientes.TabIndex = 32;
            this.lbl_resultadosCantidad_Clientes.Text = "#######";
            this.lbl_resultadosCantidad_Clientes.Visible = false;
            // 
            // btn_VerUltimos_Clientes
            // 
            this.btn_VerUltimos_Clientes.Enabled = false;
            this.btn_VerUltimos_Clientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_VerUltimos_Clientes.Location = new System.Drawing.Point(793, 71);
            this.btn_VerUltimos_Clientes.Name = "btn_VerUltimos_Clientes";
            this.btn_VerUltimos_Clientes.Size = new System.Drawing.Size(77, 25);
            this.btn_VerUltimos_Clientes.TabIndex = 33;
            this.btn_VerUltimos_Clientes.Text = "Ver ultimos";
            this.btn_VerUltimos_Clientes.UseVisualStyleBackColor = true;
            this.btn_VerUltimos_Clientes.Visible = false;
            // 
            // btn_VerTodo_Clientes
            // 
            this.btn_VerTodo_Clientes.Enabled = false;
            this.btn_VerTodo_Clientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_VerTodo_Clientes.Location = new System.Drawing.Point(876, 71);
            this.btn_VerTodo_Clientes.Name = "btn_VerTodo_Clientes";
            this.btn_VerTodo_Clientes.Size = new System.Drawing.Size(65, 25);
            this.btn_VerTodo_Clientes.TabIndex = 34;
            this.btn_VerTodo_Clientes.Text = "Ver todo";
            this.btn_VerTodo_Clientes.UseVisualStyleBackColor = true;
            this.btn_VerTodo_Clientes.Visible = false;
            // 
            // btn_Membresias_Clientes
            // 
            this.btn_Membresias_Clientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Membresias_Clientes.Location = new System.Drawing.Point(241, 45);
            this.btn_Membresias_Clientes.Name = "btn_Membresias_Clientes";
            this.btn_Membresias_Clientes.Size = new System.Drawing.Size(97, 23);
            this.btn_Membresias_Clientes.TabIndex = 35;
            this.btn_Membresias_Clientes.Text = "Membresias ";
            this.btn_Membresias_Clientes.UseVisualStyleBackColor = true;
            this.btn_Membresias_Clientes.Click += new System.EventHandler(this.btn_Membresias_Clientes_Click);
            // 
            // btn_ExportarExcel_Clientes
            // 
            this.btn_ExportarExcel_Clientes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ExportarExcel_Clientes.BackgroundImage")));
            this.btn_ExportarExcel_Clientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ExportarExcel_Clientes.Enabled = false;
            this.btn_ExportarExcel_Clientes.Location = new System.Drawing.Point(344, 36);
            this.btn_ExportarExcel_Clientes.Name = "btn_ExportarExcel_Clientes";
            this.btn_ExportarExcel_Clientes.Size = new System.Drawing.Size(33, 32);
            this.btn_ExportarExcel_Clientes.TabIndex = 45;
            this.btn_ExportarExcel_Clientes.UseVisualStyleBackColor = true;
            this.btn_ExportarExcel_Clientes.Visible = false;
            // 
            // cbx_FiltroCliente
            // 
            this.cbx_FiltroCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_FiltroCliente.FormattingEnabled = true;
            this.cbx_FiltroCliente.Location = new System.Drawing.Point(383, 71);
            this.cbx_FiltroCliente.Name = "cbx_FiltroCliente";
            this.cbx_FiltroCliente.Size = new System.Drawing.Size(121, 21);
            this.cbx_FiltroCliente.TabIndex = 46;
            this.cbx_FiltroCliente.SelectedIndexChanged += new System.EventHandler(this.cbx_FiltroCliente_SelectedIndexChanged);
            // 
            // frm_Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 366);
            this.Controls.Add(this.cbx_FiltroCliente);
            this.Controls.Add(this.btn_ExportarExcel_Clientes);
            this.Controls.Add(this.btn_Membresias_Clientes);
            this.Controls.Add(this.btn_VerTodo_Clientes);
            this.Controls.Add(this.btn_VerUltimos_Clientes);
            this.Controls.Add(this.lbl_resultadosCantidad_Clientes);
            this.Controls.Add(this.txt_Buscar_Clientes);
            this.Controls.Add(this.btn_Eliminar_Clientes);
            this.Controls.Add(this.btn_Modificar_Clientes);
            this.Controls.Add(this.btn_Nuevo_Clientes);
            this.Controls.Add(this.dgv_Clientes);
            this.Controls.Add(this.label2);
            this.Name = "frm_Clientes";
            this.Load += new System.EventHandler(this.frm_Clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Clientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Buscar_Clientes;
        private System.Windows.Forms.Button btn_Eliminar_Clientes;
        private System.Windows.Forms.Button btn_Modificar_Clientes;
        private System.Windows.Forms.Button btn_Nuevo_Clientes;
        private System.Windows.Forms.DataGridView dgv_Clientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_resultadosCantidad_Clientes;
        private System.Windows.Forms.Button btn_VerUltimos_Clientes;
        private System.Windows.Forms.Button btn_VerTodo_Clientes;
        private System.Windows.Forms.Button btn_Membresias_Clientes;
        private System.Windows.Forms.Button btn_ExportarExcel_Clientes;
        private System.Windows.Forms.ComboBox cbx_FiltroCliente;
    }
}
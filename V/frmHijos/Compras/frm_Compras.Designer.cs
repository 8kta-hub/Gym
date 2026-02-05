namespace Gym.V.frmHijos.Compras
{
    partial class frm_Compras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Compras));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Nuevo_Compras = new System.Windows.Forms.Button();
            this.btn_Detalle_Compras = new System.Windows.Forms.Button();
            this.btn_Eliminar_Compras = new System.Windows.Forms.Button();
            this.dgv_Compras = new System.Windows.Forms.DataGridView();
            this.dtp_FechaInicial_Compras = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_FechaFinal_Compras = new System.Windows.Forms.DateTimePicker();
            this.btn_Buscar_Compras = new System.Windows.Forms.Button();
            this.btn_ExportarExcel_Compras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Compras)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "COMPRAS";
            // 
            // btn_Nuevo_Compras
            // 
            this.btn_Nuevo_Compras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Nuevo_Compras.Location = new System.Drawing.Point(8, 46);
            this.btn_Nuevo_Compras.Name = "btn_Nuevo_Compras";
            this.btn_Nuevo_Compras.Size = new System.Drawing.Size(64, 23);
            this.btn_Nuevo_Compras.TabIndex = 1;
            this.btn_Nuevo_Compras.Text = "Nuevo";
            this.btn_Nuevo_Compras.UseVisualStyleBackColor = true;
            // 
            // btn_Detalle_Compras
            // 
            this.btn_Detalle_Compras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Detalle_Compras.Location = new System.Drawing.Point(78, 46);
            this.btn_Detalle_Compras.Name = "btn_Detalle_Compras";
            this.btn_Detalle_Compras.Size = new System.Drawing.Size(93, 23);
            this.btn_Detalle_Compras.TabIndex = 2;
            this.btn_Detalle_Compras.Text = "Ver Detalle";
            this.btn_Detalle_Compras.UseVisualStyleBackColor = true;
            // 
            // btn_Eliminar_Compras
            // 
            this.btn_Eliminar_Compras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar_Compras.Location = new System.Drawing.Point(177, 46);
            this.btn_Eliminar_Compras.Name = "btn_Eliminar_Compras";
            this.btn_Eliminar_Compras.Size = new System.Drawing.Size(75, 23);
            this.btn_Eliminar_Compras.TabIndex = 3;
            this.btn_Eliminar_Compras.Text = "Eliminar";
            this.btn_Eliminar_Compras.UseVisualStyleBackColor = true;
            // 
            // dgv_Compras
            // 
            this.dgv_Compras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Compras.Location = new System.Drawing.Point(8, 75);
            this.dgv_Compras.Name = "dgv_Compras";
            this.dgv_Compras.Size = new System.Drawing.Size(1011, 285);
            this.dgv_Compras.TabIndex = 5;
            // 
            // dtp_FechaInicial_Compras
            // 
            this.dtp_FechaInicial_Compras.Location = new System.Drawing.Point(444, 49);
            this.dtp_FechaInicial_Compras.Name = "dtp_FechaInicial_Compras";
            this.dtp_FechaInicial_Compras.Size = new System.Drawing.Size(200, 20);
            this.dtp_FechaInicial_Compras.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(356, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha Inicial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(656, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fecha Final";
            // 
            // dtp_FechaFinal_Compras
            // 
            this.dtp_FechaFinal_Compras.Location = new System.Drawing.Point(739, 49);
            this.dtp_FechaFinal_Compras.Name = "dtp_FechaFinal_Compras";
            this.dtp_FechaFinal_Compras.Size = new System.Drawing.Size(200, 20);
            this.dtp_FechaFinal_Compras.TabIndex = 9;
            // 
            // btn_Buscar_Compras
            // 
            this.btn_Buscar_Compras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Buscar_Compras.Location = new System.Drawing.Point(956, 46);
            this.btn_Buscar_Compras.Name = "btn_Buscar_Compras";
            this.btn_Buscar_Compras.Size = new System.Drawing.Size(63, 23);
            this.btn_Buscar_Compras.TabIndex = 10;
            this.btn_Buscar_Compras.Text = "Buscar";
            this.btn_Buscar_Compras.UseVisualStyleBackColor = true;
            // 
            // btn_ExportarExcel_Compras
            // 
            this.btn_ExportarExcel_Compras.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ExportarExcel_Compras.BackgroundImage")));
            this.btn_ExportarExcel_Compras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ExportarExcel_Compras.Location = new System.Drawing.Point(258, 37);
            this.btn_ExportarExcel_Compras.Name = "btn_ExportarExcel_Compras";
            this.btn_ExportarExcel_Compras.Size = new System.Drawing.Size(33, 32);
            this.btn_ExportarExcel_Compras.TabIndex = 44;
            this.btn_ExportarExcel_Compras.UseVisualStyleBackColor = true;
            // 
            // frm_Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 366);
            this.Controls.Add(this.btn_ExportarExcel_Compras);
            this.Controls.Add(this.btn_Buscar_Compras);
            this.Controls.Add(this.dtp_FechaFinal_Compras);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_FechaInicial_Compras);
            this.Controls.Add(this.dgv_Compras);
            this.Controls.Add(this.btn_Eliminar_Compras);
            this.Controls.Add(this.btn_Detalle_Compras);
            this.Controls.Add(this.btn_Nuevo_Compras);
            this.Controls.Add(this.label1);
            this.Name = "frm_Compras";
            this.Text = "frm_Compras";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Compras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Nuevo_Compras;
        private System.Windows.Forms.Button btn_Detalle_Compras;
        private System.Windows.Forms.Button btn_Eliminar_Compras;
        private System.Windows.Forms.DataGridView dgv_Compras;
        private System.Windows.Forms.DateTimePicker dtp_FechaInicial_Compras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_FechaFinal_Compras;
        private System.Windows.Forms.Button btn_Buscar_Compras;
        private System.Windows.Forms.Button btn_ExportarExcel_Compras;
    }
}
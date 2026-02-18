namespace Gym.V.frmHijos.Conceptos
{
    partial class frm_Conceptos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Conceptos));
            this.btn_Eliminar_Conceptos = new System.Windows.Forms.Button();
            this.btn_Modificar_Conceptos = new System.Windows.Forms.Button();
            this.btn_Nuevo_Conceptos = new System.Windows.Forms.Button();
            this.dgv_Conceptos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ExportarExcel_Conceptos = new System.Windows.Forms.Button();
            this.cbx_FiltroConcepto = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Conceptos)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Eliminar_Conceptos
            // 
            this.btn_Eliminar_Conceptos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar_Conceptos.Location = new System.Drawing.Point(159, 50);
            this.btn_Eliminar_Conceptos.Name = "btn_Eliminar_Conceptos";
            this.btn_Eliminar_Conceptos.Size = new System.Drawing.Size(75, 23);
            this.btn_Eliminar_Conceptos.TabIndex = 42;
            this.btn_Eliminar_Conceptos.Text = "Eliminar";
            this.btn_Eliminar_Conceptos.UseVisualStyleBackColor = true;
            this.btn_Eliminar_Conceptos.Click += new System.EventHandler(this.btn_Eliminar_Conceptos_Click);
            // 
            // btn_Modificar_Conceptos
            // 
            this.btn_Modificar_Conceptos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Modificar_Conceptos.Location = new System.Drawing.Point(78, 50);
            this.btn_Modificar_Conceptos.Name = "btn_Modificar_Conceptos";
            this.btn_Modificar_Conceptos.Size = new System.Drawing.Size(75, 23);
            this.btn_Modificar_Conceptos.TabIndex = 39;
            this.btn_Modificar_Conceptos.Text = "Modificar";
            this.btn_Modificar_Conceptos.UseVisualStyleBackColor = true;
            this.btn_Modificar_Conceptos.Click += new System.EventHandler(this.btn_Modificar_Conceptos_Click);
            // 
            // btn_Nuevo_Conceptos
            // 
            this.btn_Nuevo_Conceptos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Nuevo_Conceptos.Location = new System.Drawing.Point(9, 50);
            this.btn_Nuevo_Conceptos.Name = "btn_Nuevo_Conceptos";
            this.btn_Nuevo_Conceptos.Size = new System.Drawing.Size(63, 23);
            this.btn_Nuevo_Conceptos.TabIndex = 38;
            this.btn_Nuevo_Conceptos.Text = "Nuevo";
            this.btn_Nuevo_Conceptos.UseVisualStyleBackColor = true;
            this.btn_Nuevo_Conceptos.Click += new System.EventHandler(this.btn_Nuevo_Conceptos_Click);
            // 
            // dgv_Conceptos
            // 
            this.dgv_Conceptos.AllowUserToResizeColumns = false;
            this.dgv_Conceptos.AllowUserToResizeRows = false;
            this.dgv_Conceptos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Conceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Conceptos.Location = new System.Drawing.Point(12, 79);
            this.dgv_Conceptos.Name = "dgv_Conceptos";
            this.dgv_Conceptos.ReadOnly = true;
            this.dgv_Conceptos.Size = new System.Drawing.Size(1004, 280);
            this.dgv_Conceptos.TabIndex = 37;
            this.dgv_Conceptos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_Conceptos_DataBindingComplete);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "CONCEPTOS";
            // 
            // btn_ExportarExcel_Conceptos
            // 
            this.btn_ExportarExcel_Conceptos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ExportarExcel_Conceptos.BackgroundImage")));
            this.btn_ExportarExcel_Conceptos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ExportarExcel_Conceptos.Location = new System.Drawing.Point(240, 41);
            this.btn_ExportarExcel_Conceptos.Name = "btn_ExportarExcel_Conceptos";
            this.btn_ExportarExcel_Conceptos.Size = new System.Drawing.Size(33, 32);
            this.btn_ExportarExcel_Conceptos.TabIndex = 43;
            this.btn_ExportarExcel_Conceptos.UseVisualStyleBackColor = true;
            // 
            // cbx_FiltroConcepto
            // 
            this.cbx_FiltroConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_FiltroConcepto.FormattingEnabled = true;
            this.cbx_FiltroConcepto.Location = new System.Drawing.Point(289, 52);
            this.cbx_FiltroConcepto.Name = "cbx_FiltroConcepto";
            this.cbx_FiltroConcepto.Size = new System.Drawing.Size(121, 21);
            this.cbx_FiltroConcepto.TabIndex = 47;
            // 
            // frm_Conceptos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 366);
            this.Controls.Add(this.cbx_FiltroConcepto);
            this.Controls.Add(this.btn_ExportarExcel_Conceptos);
            this.Controls.Add(this.btn_Eliminar_Conceptos);
            this.Controls.Add(this.btn_Modificar_Conceptos);
            this.Controls.Add(this.btn_Nuevo_Conceptos);
            this.Controls.Add(this.dgv_Conceptos);
            this.Controls.Add(this.label2);
            this.Name = "frm_Conceptos";
            this.Text = "frm_Conceptos";
            this.Load += new System.EventHandler(this.frm_Conceptos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Conceptos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Eliminar_Conceptos;
        private System.Windows.Forms.Button btn_Modificar_Conceptos;
        private System.Windows.Forms.Button btn_Nuevo_Conceptos;
        private System.Windows.Forms.DataGridView dgv_Conceptos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ExportarExcel_Conceptos;
        private System.Windows.Forms.ComboBox cbx_FiltroConcepto;
    }
}
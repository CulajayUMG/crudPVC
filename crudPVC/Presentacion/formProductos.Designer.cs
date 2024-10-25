namespace crudPVC.Presentacion
{
    partial class formProductos
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
            this.titulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTareas = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.Reportebtn = new System.Windows.Forms.Button();
            this.Eliminarbtn = new System.Windows.Forms.Button();
            this.Modificarbtn = new System.Windows.Forms.Button();
            this.nuevoBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.anchoTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.categoriabox = new System.Windows.Forms.ComboBox();
            this.guardarbtn = new System.Windows.Forms.Button();
            this.cancelarbtn = new System.Windows.Forms.Button();
            this.buscarbtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.buscartxt = new System.Windows.Forms.TextBox();
            this.DGVListadoProd = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.altoTxt = new System.Windows.Forms.TextBox();
            this.stocktxt = new System.Windows.Forms.TextBox();
            this.marcatxt = new System.Windows.Forms.TextBox();
            this.productotxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.boxMedida = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.titulo.SuspendLayout();
            this.panelTareas.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVListadoProd)).BeginInit();
            this.SuspendLayout();
            // 
            // titulo
            // 
            this.titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.titulo.Controls.Add(this.label1);
            this.titulo.Location = new System.Drawing.Point(1, 2);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(1169, 65);
            this.titulo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 7);
            this.label1.MaximumSize = new System.Drawing.Size(850, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mantenimiento de Productos";
            // 
            // panelTareas
            // 
            this.panelTareas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelTareas.Controls.Add(this.btnSalir);
            this.panelTareas.Controls.Add(this.Reportebtn);
            this.panelTareas.Controls.Add(this.Eliminarbtn);
            this.panelTareas.Controls.Add(this.Modificarbtn);
            this.panelTareas.Controls.Add(this.nuevoBtn);
            this.panelTareas.Location = new System.Drawing.Point(1060, 73);
            this.panelTareas.Name = "panelTareas";
            this.panelTareas.Size = new System.Drawing.Size(110, 489);
            this.panelTareas.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(26, 376);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // Reportebtn
            // 
            this.Reportebtn.Location = new System.Drawing.Point(26, 183);
            this.Reportebtn.Name = "Reportebtn";
            this.Reportebtn.Size = new System.Drawing.Size(75, 23);
            this.Reportebtn.TabIndex = 3;
            this.Reportebtn.Text = "Reporte";
            this.Reportebtn.UseVisualStyleBackColor = true;
            this.Reportebtn.Click += new System.EventHandler(this.Reportebtn_Click);
            // 
            // Eliminarbtn
            // 
            this.Eliminarbtn.Location = new System.Drawing.Point(26, 115);
            this.Eliminarbtn.Name = "Eliminarbtn";
            this.Eliminarbtn.Size = new System.Drawing.Size(75, 23);
            this.Eliminarbtn.TabIndex = 2;
            this.Eliminarbtn.Text = "Eliminar";
            this.Eliminarbtn.UseVisualStyleBackColor = true;
            this.Eliminarbtn.Click += new System.EventHandler(this.Eliminarbtn_Click);
            // 
            // Modificarbtn
            // 
            this.Modificarbtn.Location = new System.Drawing.Point(26, 66);
            this.Modificarbtn.Name = "Modificarbtn";
            this.Modificarbtn.Size = new System.Drawing.Size(75, 23);
            this.Modificarbtn.TabIndex = 1;
            this.Modificarbtn.Text = "Modificar";
            this.Modificarbtn.UseVisualStyleBackColor = true;
            this.Modificarbtn.Click += new System.EventHandler(this.Modificarbtn_Click);
            // 
            // nuevoBtn
            // 
            this.nuevoBtn.Location = new System.Drawing.Point(26, 13);
            this.nuevoBtn.Name = "nuevoBtn";
            this.nuevoBtn.Size = new System.Drawing.Size(75, 23);
            this.nuevoBtn.TabIndex = 0;
            this.nuevoBtn.Text = "Nuevo";
            this.nuevoBtn.UseVisualStyleBackColor = true;
            this.nuevoBtn.Click += new System.EventHandler(this.nuevoBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.boxMedida);
            this.panel1.Controls.Add(this.anchoTxt);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.categoriabox);
            this.panel1.Controls.Add(this.guardarbtn);
            this.panel1.Controls.Add(this.cancelarbtn);
            this.panel1.Controls.Add(this.buscarbtn);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.buscartxt);
            this.panel1.Controls.Add(this.DGVListadoProd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.altoTxt);
            this.panel1.Controls.Add(this.stocktxt);
            this.panel1.Controls.Add(this.marcatxt);
            this.panel1.Controls.Add(this.productotxt);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(1, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 489);
            this.panel1.TabIndex = 2;
            // 
            // anchoTxt
            // 
            this.anchoTxt.Enabled = false;
            this.anchoTxt.Location = new System.Drawing.Point(219, 160);
            this.anchoTxt.Name = "anchoTxt";
            this.anchoTxt.Size = new System.Drawing.Size(100, 22);
            this.anchoTxt.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(168, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Ancho";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Categoria";
            // 
            // categoriabox
            // 
            this.categoriabox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoriabox.Enabled = false;
            this.categoriabox.FormattingEnabled = true;
            this.categoriabox.Location = new System.Drawing.Point(102, 205);
            this.categoriabox.Name = "categoriabox";
            this.categoriabox.Size = new System.Drawing.Size(220, 24);
            this.categoriabox.TabIndex = 16;
            // 
            // guardarbtn
            // 
            this.guardarbtn.Location = new System.Drawing.Point(255, 263);
            this.guardarbtn.Name = "guardarbtn";
            this.guardarbtn.Size = new System.Drawing.Size(75, 23);
            this.guardarbtn.TabIndex = 15;
            this.guardarbtn.Text = "Guardar";
            this.guardarbtn.UseVisualStyleBackColor = true;
            this.guardarbtn.Visible = false;
            this.guardarbtn.Click += new System.EventHandler(this.guardarbtn_Click);
            // 
            // cancelarbtn
            // 
            this.cancelarbtn.Location = new System.Drawing.Point(22, 263);
            this.cancelarbtn.Name = "cancelarbtn";
            this.cancelarbtn.Size = new System.Drawing.Size(75, 23);
            this.cancelarbtn.TabIndex = 14;
            this.cancelarbtn.Text = "Cancelar";
            this.cancelarbtn.UseVisualStyleBackColor = true;
            this.cancelarbtn.Visible = false;
            this.cancelarbtn.Click += new System.EventHandler(this.cancelarbtn_Click);
            // 
            // buscarbtn
            // 
            this.buscarbtn.Location = new System.Drawing.Point(283, 415);
            this.buscarbtn.Name = "buscarbtn";
            this.buscarbtn.Size = new System.Drawing.Size(75, 23);
            this.buscarbtn.TabIndex = 13;
            this.buscarbtn.Text = "Buscar";
            this.buscarbtn.UseVisualStyleBackColor = true;
            this.buscarbtn.Click += new System.EventHandler(this.buscarbtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Nombre Producto";
            // 
            // buscartxt
            // 
            this.buscartxt.Location = new System.Drawing.Point(130, 372);
            this.buscartxt.Name = "buscartxt";
            this.buscartxt.Size = new System.Drawing.Size(228, 22);
            this.buscartxt.TabIndex = 11;
            // 
            // DGVListadoProd
            // 
            this.DGVListadoProd.ColumnHeadersHeight = 25;
            this.DGVListadoProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVListadoProd.Location = new System.Drawing.Point(373, 13);
            this.DGVListadoProd.Name = "DGVListadoProd";
            this.DGVListadoProd.RowHeadersWidth = 51;
            this.DGVListadoProd.RowTemplate.Height = 24;
            this.DGVListadoProd.Size = new System.Drawing.Size(680, 459);
            this.DGVListadoProd.TabIndex = 10;
            this.DGVListadoProd.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVListadoProd_CellEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Producto";
            // 
            // altoTxt
            // 
            this.altoTxt.Enabled = false;
            this.altoTxt.Location = new System.Drawing.Point(76, 160);
            this.altoTxt.Name = "altoTxt";
            this.altoTxt.Size = new System.Drawing.Size(72, 22);
            this.altoTxt.TabIndex = 8;
            // 
            // stocktxt
            // 
            this.stocktxt.Enabled = false;
            this.stocktxt.Location = new System.Drawing.Point(102, 112);
            this.stocktxt.Name = "stocktxt";
            this.stocktxt.Size = new System.Drawing.Size(100, 22);
            this.stocktxt.TabIndex = 6;
            // 
            // marcatxt
            // 
            this.marcatxt.Enabled = false;
            this.marcatxt.Location = new System.Drawing.Point(102, 61);
            this.marcatxt.Name = "marcatxt";
            this.marcatxt.Size = new System.Drawing.Size(157, 22);
            this.marcatxt.TabIndex = 5;
            // 
            // productotxt
            // 
            this.productotxt.Enabled = false;
            this.productotxt.Location = new System.Drawing.Point(102, 13);
            this.productotxt.Name = "productotxt";
            this.productotxt.Size = new System.Drawing.Size(228, 22);
            this.productotxt.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Stock";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Alto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Marca";
            // 
            // boxMedida
            // 
            this.boxMedida.Enabled = false;
            this.boxMedida.FormattingEnabled = true;
            this.boxMedida.Location = new System.Drawing.Point(237, 112);
            this.boxMedida.Name = "boxMedida";
            this.boxMedida.Size = new System.Drawing.Size(121, 24);
            this.boxMedida.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(270, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "uMedida";
            // 
            // formProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 563);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTareas);
            this.Controls.Add(this.titulo);
            this.Name = "formProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formProductos";
            this.Load += new System.EventHandler(this.formProductos_Load);
            this.titulo.ResumeLayout(false);
            this.titulo.PerformLayout();
            this.panelTareas.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVListadoProd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel titulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTareas;
        private System.Windows.Forms.Button Reportebtn;
        private System.Windows.Forms.Button Eliminarbtn;
        private System.Windows.Forms.Button Modificarbtn;
        private System.Windows.Forms.Button nuevoBtn;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox altoTxt;
        private System.Windows.Forms.TextBox stocktxt;
        private System.Windows.Forms.TextBox marcatxt;
        private System.Windows.Forms.TextBox productotxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buscarbtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox buscartxt;
        private System.Windows.Forms.DataGridView DGVListadoProd;
        private System.Windows.Forms.Button guardarbtn;
        private System.Windows.Forms.Button cancelarbtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox categoriabox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox anchoTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox boxMedida;
    }
}
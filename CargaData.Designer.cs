namespace ImportaExcell_IC
{
    partial class CargaData
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
            this.components = new System.ComponentModel.Container();
            this.cmdArchivo = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkFirsColumName = new System.Windows.Forms.CheckBox();
            this.GridMapeo = new System.Windows.Forms.DataGridView();
            this.sprLista = new System.Windows.Forms.DataGridView();
            this.cmdDestino = new System.Windows.Forms.Button();
            this.cmdOrigen = new System.Windows.Forms.Button();
            this.cmdCargar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlOrigen = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.rbtCargar = new System.Windows.Forms.RadioButton();
            this.pnlDestino = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTabla = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTolReg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFecAlt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumEmpleado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.lblPreocesandoInf = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sprListaResponse = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GridMapeo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sprLista)).BeginInit();
            this.pnlOrigen.SuspendLayout();
            this.pnlDestino.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sprListaResponse)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdArchivo
            // 
            this.cmdArchivo.Location = new System.Drawing.Point(487, 41);
            this.cmdArchivo.Name = "cmdArchivo";
            this.cmdArchivo.Size = new System.Drawing.Size(73, 20);
            this.cmdArchivo.TabIndex = 1;
            this.cmdArchivo.Text = "Examinar";
            this.cmdArchivo.UseVisualStyleBackColor = true;
            this.cmdArchivo.Click += new System.EventHandler(this.cmdArchivo_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.AllowDrop = true;
            this.txtArchivo.Location = new System.Drawing.Point(91, 41);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(392, 20);
            this.txtArchivo.TabIndex = 4;
            this.txtArchivo.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtArchivo_DragDrop);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ruta de acceso:";
            // 
            // chkFirsColumName
            // 
            this.chkFirsColumName.AutoSize = true;
            this.chkFirsColumName.Checked = true;
            this.chkFirsColumName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFirsColumName.Location = new System.Drawing.Point(6, 69);
            this.chkFirsColumName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkFirsColumName.Name = "chkFirsColumName";
            this.chkFirsColumName.Size = new System.Drawing.Size(218, 17);
            this.chkFirsColumName.TabIndex = 8;
            this.chkFirsColumName.Text = "La primera fila tiene nombres de columna";
            this.chkFirsColumName.UseVisualStyleBackColor = true;
            // 
            // GridMapeo
            // 
            this.GridMapeo.AllowUserToAddRows = false;
            this.GridMapeo.AllowUserToDeleteRows = false;
            this.GridMapeo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridMapeo.Location = new System.Drawing.Point(6, 30);
            this.GridMapeo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GridMapeo.MultiSelect = false;
            this.GridMapeo.Name = "GridMapeo";
            this.GridMapeo.RowHeadersVisible = false;
            this.GridMapeo.RowTemplate.Height = 24;
            this.GridMapeo.Size = new System.Drawing.Size(566, 270);
            this.GridMapeo.TabIndex = 9;
            this.GridMapeo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridMapeo_CellContentClick);
            // 
            // sprLista
            // 
            this.sprLista.AllowUserToAddRows = false;
            this.sprLista.AllowUserToDeleteRows = false;
            this.sprLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sprLista.Location = new System.Drawing.Point(6, 93);
            this.sprLista.MultiSelect = false;
            this.sprLista.Name = "sprLista";
            this.sprLista.ReadOnly = true;
            this.sprLista.Size = new System.Drawing.Size(566, 270);
            this.sprLista.TabIndex = 10;
            // 
            // cmdDestino
            // 
            this.cmdDestino.Enabled = false;
            this.cmdDestino.Location = new System.Drawing.Point(82, 384);
            this.cmdDestino.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdDestino.Name = "cmdDestino";
            this.cmdDestino.Size = new System.Drawing.Size(71, 22);
            this.cmdDestino.TabIndex = 11;
            this.cmdDestino.Text = "Destino";
            this.cmdDestino.UseVisualStyleBackColor = true;
            this.cmdDestino.Click += new System.EventHandler(this.cmdSiguiente_Click);
            // 
            // cmdOrigen
            // 
            this.cmdOrigen.Location = new System.Drawing.Point(10, 384);
            this.cmdOrigen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdOrigen.Name = "cmdOrigen";
            this.cmdOrigen.Size = new System.Drawing.Size(71, 22);
            this.cmdOrigen.TabIndex = 12;
            this.cmdOrigen.Text = "Origen";
            this.cmdOrigen.UseVisualStyleBackColor = true;
            this.cmdOrigen.Click += new System.EventHandler(this.cmdAtras_Click);
            // 
            // cmdCargar
            // 
            this.cmdCargar.Location = new System.Drawing.Point(508, 384);
            this.cmdCargar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdCargar.Name = "cmdCargar";
            this.cmdCargar.Size = new System.Drawing.Size(71, 22);
            this.cmdCargar.TabIndex = 13;
            this.cmdCargar.Text = "Cargar";
            this.cmdCargar.UseVisualStyleBackColor = true;
            this.cmdCargar.Visible = false;
            this.cmdCargar.Click += new System.EventHandler(this.cmdFinalizar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(111, 343);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDescripcion.MaxLength = 150;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(261, 20);
            this.txtDescripcion.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 345);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Descripción carga :";
            // 
            // pnlOrigen
            // 
            this.pnlOrigen.BackColor = System.Drawing.Color.White;
            this.pnlOrigen.Controls.Add(this.label7);
            this.pnlOrigen.Controls.Add(this.rbtCargar);
            this.pnlOrigen.Controls.Add(this.label1);
            this.pnlOrigen.Controls.Add(this.txtArchivo);
            this.pnlOrigen.Controls.Add(this.cmdArchivo);
            this.pnlOrigen.Controls.Add(this.chkFirsColumName);
            this.pnlOrigen.Controls.Add(this.sprLista);
            this.pnlOrigen.Location = new System.Drawing.Point(6, 7);
            this.pnlOrigen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlOrigen.Name = "pnlOrigen";
            this.pnlOrigen.Size = new System.Drawing.Size(580, 369);
            this.pnlOrigen.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Proceso:";
            // 
            // rbtCargar
            // 
            this.rbtCargar.AutoSize = true;
            this.rbtCargar.Checked = true;
            this.rbtCargar.Location = new System.Drawing.Point(91, 12);
            this.rbtCargar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtCargar.Name = "rbtCargar";
            this.rbtCargar.Size = new System.Drawing.Size(56, 17);
            this.rbtCargar.TabIndex = 11;
            this.rbtCargar.TabStop = true;
            this.rbtCargar.Tag = "";
            this.rbtCargar.Text = "Cargar";
            this.rbtCargar.UseVisualStyleBackColor = true;
            // 
            // pnlDestino
            // 
            this.pnlDestino.BackColor = System.Drawing.Color.White;
            this.pnlDestino.Controls.Add(this.label8);
            this.pnlDestino.Controls.Add(this.txtTabla);
            this.pnlDestino.Controls.Add(this.label6);
            this.pnlDestino.Controls.Add(this.txtTolReg);
            this.pnlDestino.Controls.Add(this.label5);
            this.pnlDestino.Controls.Add(this.txtFecAlt);
            this.pnlDestino.Controls.Add(this.label4);
            this.pnlDestino.Controls.Add(this.txtNumEmpleado);
            this.pnlDestino.Controls.Add(this.label3);
            this.pnlDestino.Controls.Add(this.label2);
            this.pnlDestino.Controls.Add(this.txtDescripcion);
            this.pnlDestino.Controls.Add(this.GridMapeo);
            this.pnlDestino.Location = new System.Drawing.Point(593, 7);
            this.pnlDestino.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlDestino.Name = "pnlDestino";
            this.pnlDestino.Size = new System.Drawing.Size(580, 369);
            this.pnlDestino.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(287, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Tabla :";
            // 
            // txtTabla
            // 
            this.txtTabla.Enabled = false;
            this.txtTabla.Location = new System.Drawing.Point(334, 313);
            this.txtTabla.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTabla.MaxLength = 150;
            this.txtTabla.Name = "txtTabla";
            this.txtTabla.Size = new System.Drawing.Size(99, 20);
            this.txtTabla.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(449, 315);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Total a enviar :";
            // 
            // txtTolReg
            // 
            this.txtTolReg.Enabled = false;
            this.txtTolReg.Location = new System.Drawing.Point(532, 313);
            this.txtTolReg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTolReg.MaxLength = 150;
            this.txtTolReg.Name = "txtTolReg";
            this.txtTolReg.Size = new System.Drawing.Size(42, 20);
            this.txtTolReg.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Fecha :";
            // 
            // txtFecAlt
            // 
            this.txtFecAlt.Enabled = false;
            this.txtFecAlt.Location = new System.Drawing.Point(209, 313);
            this.txtFecAlt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFecAlt.MaxLength = 150;
            this.txtFecAlt.Name = "txtFecAlt";
            this.txtFecAlt.Size = new System.Drawing.Size(71, 20);
            this.txtFecAlt.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Núm. Empleado :";
            // 
            // txtNumEmpleado
            // 
            this.txtNumEmpleado.Enabled = false;
            this.txtNumEmpleado.Location = new System.Drawing.Point(111, 313);
            this.txtNumEmpleado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNumEmpleado.MaxLength = 150;
            this.txtNumEmpleado.Name = "txtNumEmpleado";
            this.txtNumEmpleado.Size = new System.Drawing.Size(47, 20);
            this.txtNumEmpleado.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Mapeo de datos :";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Location = new System.Drawing.Point(436, 384);
            this.cmdCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(71, 22);
            this.cmdCancelar.TabIndex = 18;
            this.cmdCancelar.Text = "Cerrar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Visible = false;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // lblPreocesandoInf
            // 
            this.lblPreocesandoInf.AutoSize = true;
            this.lblPreocesandoInf.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreocesandoInf.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPreocesandoInf.Location = new System.Drawing.Point(222, 388);
            this.lblPreocesandoInf.Name = "lblPreocesandoInf";
            this.lblPreocesandoInf.Size = new System.Drawing.Size(155, 17);
            this.lblPreocesandoInf.TabIndex = 19;
            this.lblPreocesandoInf.Text = "Procesando Información .....";
            this.lblPreocesandoInf.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // sprListaResponse
            // 
            this.sprListaResponse.AllowUserToAddRows = false;
            this.sprListaResponse.AllowUserToDeleteRows = false;
            this.sprListaResponse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sprListaResponse.Location = new System.Drawing.Point(599, 381);
            this.sprListaResponse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sprListaResponse.Name = "sprListaResponse";
            this.sprListaResponse.RowTemplate.Height = 24;
            this.sprListaResponse.Size = new System.Drawing.Size(234, 28);
            this.sprListaResponse.TabIndex = 20;
            // 
            // CargaData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(592, 411);
            this.Controls.Add(this.sprListaResponse);
            this.Controls.Add(this.lblPreocesandoInf);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.pnlDestino);
            this.Controls.Add(this.pnlOrigen);
            this.Controls.Add(this.cmdCargar);
            this.Controls.Add(this.cmdOrigen);
            this.Controls.Add(this.cmdDestino);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CargaData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CargaData";
            this.Load += new System.EventHandler(this.CargaData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridMapeo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sprLista)).EndInit();
            this.pnlOrigen.ResumeLayout(false);
            this.pnlOrigen.PerformLayout();
            this.pnlDestino.ResumeLayout(false);
            this.pnlDestino.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sprListaResponse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cmdArchivo;
    private System.Windows.Forms.TextBox txtArchivo;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox chkFirsColumName;
    private System.Windows.Forms.DataGridView GridMapeo;
    private System.Windows.Forms.DataGridView sprLista;
    private System.Windows.Forms.Button cmdDestino;
    private System.Windows.Forms.Button cmdOrigen;
    private System.Windows.Forms.Button cmdCargar;
    private System.Windows.Forms.TextBox txtDescripcion;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Panel pnlOrigen;
    private System.Windows.Forms.Panel pnlDestino;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button cmdCancelar;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtTolReg;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtFecAlt;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtNumEmpleado;
    private System.Windows.Forms.RadioButton rbtCargar;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtTabla;
    private System.Windows.Forms.Label lblPreocesandoInf;
    private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView sprListaResponse;
    }
}


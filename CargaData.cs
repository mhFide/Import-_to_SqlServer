using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel;
using System.Data.SqlClient;
using System.Configuration;
using Funciones.ADONET;

namespace ImportaExcell_IC
{
    public partial class CargaData : Form
    {


        public string cadenaConexion = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public DataSet dsTabla = new DataSet();
        public string Ruta = "";
        public string NameTabla = ConfigurationManager.AppSettings["TablaTEMP"].ToString();
        Code.Empleado miEmp = new Code.Empleado();
        Random r = new Random();

        delegate void SetComboBoxCellType(int iRowIndex);
        bool bIsComboBox = false;

        public CargaData()
        {
            InitializeComponent();
        }
        private bool CargaEmpl(string UserNameBrittel)
        {
            bool AuxReturn = true;
            try
            {
                miEmp = Code.Empleado.GetEmpleado(UserNameBrittel);
                if (Convert.ToInt32(miEmp.NoEmpl) == 0) AuxReturn = false;
                return AuxReturn;
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Carga Data ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void CargaData_Load(object sender, EventArgs e)
        {
            string Usr_Win = ConfigurationManager.AppSettings["UserWin"].ToString();
            if (Usr_Win == "") Usr_Win = Environment.UserName;

            if (CargaEmpl(Usr_Win))
            {
                cmdArchivo.Focus();
                txtNumEmpleado.Text = miEmp.NoEmpl.ToString();
                txtFecAlt.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                MessageBox.Show("El usuario no existe en el SMART", "Carga Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }
        private void LoadTemplate()
        {
            DataSet ds;
            try
            {
                ds = SqlHelper.ExecuteDataset(cadenaConexion, CommandType.Text, "SELECT COLUMN_NAME as Destino, IS_NULLABLE as AdmiteNulos, DATA_TYPE as TipoDatos, CHARACTER_MAXIMUM_LENGTH as MaxChar,ORDINAL_POSITION as Posicion FROM Information_Schema.COLUMNS where TABLE_NAME='" + NameTabla + "'");
                GridMapeo.DataSource = ds.Tables[0];
                ds.Dispose();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void cmdArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                txtDescripcion.Text = "";
                txtTabla.Text = NameTabla;

                //Blanquear en caso de que se cargue otro en el mismo objeto
                dsTabla.Clear();
                dsTabla.Dispose();
                GridMapeo.DataSource = null;
                GridMapeo.Rows.Clear();
                GridMapeo.Columns.Clear();
                cmdCargar.Visible = false;

                OpenFileDialog Archivo = new OpenFileDialog();

                //Archivo.Filter = "Archivos Excel (*.xlsx)|*.xlsx*|(*.xls)|*.xls*|(*.csv)|*.csv*";
                Archivo.Filter = "Archivos Excel (*.xlsx)|*.xlsx*|(*.xls)|*.xls*";
                Archivo.FilterIndex = 1;
                Archivo.Multiselect = false;
                Archivo.ShowDialog().ToString();
                txtArchivo.Text = Archivo.FileName;
                this.Cursor = Cursors.WaitCursor;
                if (txtArchivo.Text != "")
                {
                    Ruta = Path.GetDirectoryName(txtArchivo.Text);
                    FileStream FStTabla = File.Open(txtArchivo.Text, FileMode.Open);
                    
                    IExcelDataReader IExcTabla = null;
                    switch (Path.GetExtension(txtArchivo.Text).ToUpper())
                    {
                        case ".XLS":
                            IExcTabla = ExcelReaderFactory.CreateBinaryReader(FStTabla);
                            IExcTabla.IsFirstRowAsColumnNames = chkFirsColumName.Checked;
                            dsTabla = IExcTabla.AsDataSet();
                            IExcTabla.Close();
                            break;

                        case ".XLSX":
                            IExcTabla = ExcelReaderFactory.CreateOpenXmlReader(FStTabla);
                            IExcTabla.IsFirstRowAsColumnNames = chkFirsColumName.Checked;
                            dsTabla = IExcTabla.AsDataSet();
                            IExcTabla.Close();
                            break;

                            //case ".CSV":
                            //    DataTable tmpTabla = new DataTable();
                            //    tmpTabla = CargaCSV(FStTabla);
                            //    dsTabla.Tables.Add(tmpTabla);
                            //    break;
                    }
                    FStTabla.Close();

                    DataGridViewTextBoxColumn AuxTxtVal = new DataGridViewTextBoxColumn();

                    AuxTxtVal.Name = "Origen";
                    AuxTxtVal.HeaderText = "Origen";
                    AuxTxtVal.DataPropertyName = "CboOrigen";
                    AuxTxtVal.Width = 200;
                    GridMapeo.Columns.Add(AuxTxtVal);
                    GridMapeo.Columns[0].DataPropertyName = "CboOrigen";

                    sprLista.DataSource = dsTabla.Tables[0];
                    txtTolReg.Text = dsTabla.Tables[0].Rows.Count.ToString();

                    LoadTemplate();
                    MapeaData();
                    cmdDestino.Enabled = true;
                }
                txtDescripcion.Text = Path.GetFileName(txtArchivo.Text).Replace(Path.GetExtension(txtArchivo.Text),"_") + DateTime.Now.ToString("yyyyMMdd");
                this.Cursor = Cursors.Default;
            }
            catch (Exception Err)
            {
                MessageBox.Show("Al tratar de cargar la información ocurrio el siguiente error:" + Err.ToString());
                txtArchivo.Text ="";
                this.Cursor = Cursors.Default;
            }
        }

        private void MapeaData()
        {
            foreach (DataColumn column in dsTabla.Tables[0].Columns)
            {
                for (int i = 0; i < GridMapeo.RowCount; i++)
                {
                    if (column.ColumnName.ToString().ToUpper() == GridMapeo.Rows[i].Cells[1].Value.ToString().ToUpper())
                    {
                        GridMapeo.Rows[i].Cells[0].Value = column.ColumnName.ToString();
                        GridMapeo.Rows[i].ReadOnly = true;
                        break;
                    }
                }
            }
        }

        private void GridMapeo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == GridMapeo.Columns["Origen"].Index && GridMapeo.CurrentCell.Value == null)
                {
                    SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
                    GridMapeo.BeginInvoke(objChangeCellType, e.RowIndex);
                    bIsComboBox = false;
                }
            }
            catch (Exception Err) { MessageBox.Show(Err.ToString()); }

        }

        private void ChangeCellToComboBox(int iRowIndex)
        {
            if (bIsComboBox == false)
            {
                DataGridViewComboBoxCell comboboxColumnCopy = new DataGridViewComboBoxCell();
                bool Existe = false;
                foreach (DataColumn column in dsTabla.Tables[0].Columns)
                {
                    Existe = false;
                    for (int i = 0; i < GridMapeo.RowCount; i++)
                    {
                        if (column.ColumnName.ToString() == (GridMapeo.Rows[i].Cells[0].Value == null ? "" : GridMapeo.Rows[i].Cells[0].Value.ToString()))
                        {
                            Existe = true;
                            break;
                        }
                    }
                    if (!Existe) comboboxColumnCopy.Items.Add(column.ColumnName.ToString());
                }
                comboboxColumnCopy.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
                comboboxColumnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                GridMapeo.Rows[iRowIndex].Cells[GridMapeo.CurrentCell.ColumnIndex] = comboboxColumnCopy;
                bIsComboBox = true;
            }
        }

        private void GridMapeo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdSiguiente_Click(object sender, EventArgs e)
        {
            this.GridMapeo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridMapeo_CellEnter);

            pnlDestino.BringToFront();
            pnlDestino.Size = pnlOrigen.Size;
            pnlDestino.Location = pnlOrigen.Location;

            cmdCargar.Visible = true;
            //txtDescripcion.Text=
            txtDescripcion.Focus();
        }

        private void cmdAtras_Click(object sender, EventArgs e)
        {
            pnlOrigen.BringToFront();
            sprListaResponse.Visible = false;
        }

        private void cmdFinalizar_Click(object sender, EventArgs e)
        {

            if (txtDescripcion.Text.Length < 3) { MessageBox.Show("Debe ingresar una descripción valida", "Carga Data ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else
            {
                Application.DoEvents();
                try
                {
                    if (MessageBox.Show("Realmente desea cargar la información ", "Carga Data  ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK)
                    {

                        timer1.Enabled = true;
                        Application.UseWaitCursor = true;
                        lblPreocesandoInf.Visible = true;
                        Application.DoEvents();

                        int AuxDummy = SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, "Delete FROM " + NameTabla);

                        SqlBulkCopy SubeTabla = new SqlBulkCopy(cadenaConexion);
                        SubeTabla.BulkCopyTimeout = 40;
                        SubeTabla.DestinationTableName = NameTabla;
                        SubeTabla.NotifyAfter = 1;

                        for (int i = 0; i < GridMapeo.RowCount; i++)
                        {
                            if (GridMapeo.Rows[i].Cells[0].Value != null)
                                SubeTabla.ColumnMappings.Add(GridMapeo.Rows[i].Cells[0].Value.ToString(), GridMapeo.Rows[i].Cells[1].Value.ToString());
                        }

                        SubeTabla.WriteToServer(dsTabla.Tables[0]);

                        string NombreSP = ConfigurationManager.AppSettings["NombreSP"].ToString();
                        if (NombreSP != "")
                        {
                            using (SqlConnection cn = new SqlConnection(cadenaConexion))
                            {
                                cn.Open();
                                SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["NombreSP"].ToString(), cn);
                                cmd.CommandType = CommandType.StoredProcedure;

                                if (ConfigurationManager.AppSettings["Parametro1_SP"].ToString()!="") cmd.Parameters.AddWithValue(ConfigurationManager.AppSettings["Parametro1_SP"].ToString(), txtDescripcion.Text);
                                if (ConfigurationManager.AppSettings["Parametro2_SP"].ToString()!= "") cmd.Parameters.AddWithValue(ConfigurationManager.AppSettings["Parametro2_SP"].ToString(), txtNumEmpleado.Text); 

                                cmd.CommandTimeout = 0;

                                SqlDataReader reader = cmd.ExecuteReader();

                                if (reader.HasRows)
                                {
                                    sprListaResponse.Visible = true;
                                    sprListaResponse.BringToFront();
                                    sprListaResponse.Size = pnlOrigen.Size;
                                    sprListaResponse.Location = pnlOrigen.Location;
                                    sprListaResponse.Dock = DockStyle.Fill;
                                    DataTable dt = new DataTable();
                                    dt.Load(reader);
                                    sprListaResponse.DataSource = dt;
                                    MessageBox.Show("Se obtuvo respuesta del servidor", "Carga Data ", MessageBoxButtons.OK, MessageBoxIcon.None);
                                }
                                else
                                {
                                    MessageBox.Show("La información se envió con éxito", "Carga Data ", MessageBoxButtons.OK, MessageBoxIcon.None);
                                    this.Close();
                                }
                                //reader.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("La información se envió con éxito", "Carga Data ", MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Close();
                        }

                    }
                }
                catch (Exception Err)
                {
                    MessageBox.Show(Err.ToString(), "Carga Data ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    lblPreocesandoInf.Visible = false;
                    Application.UseWaitCursor = false;
                    lblPreocesandoInf.Visible = false;
                    timer1.Enabled = false;
                }
                Application.UseWaitCursor = false;
            }


        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Realmente deseas cerrar", "Carga Data  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblPreocesandoInf.ForeColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            Application.DoEvents();
        }

        private void txtArchivo_DragDrop(object sender, DragEventArgs e)
        {
            string[] Auxfile= (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (Auxfile.Length > 0) txtArchivo.Text = Auxfile[0];

        }
    }
}

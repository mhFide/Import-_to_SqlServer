using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using Funciones.ADONET;

namespace Code
{
    public class Empleado
    {
        private int _NoEmpl;

        private int _IdJefeInmediato;
        private string _DisplayName;
        private string _Jefe;
        private string _UserWin;
        private string _Email;
        public int nivel = 0;
        private int _IdArea;
        private string _Area;
        private string _Horario;
        private string _Proyecto;
        private string _Puesto;
        private string _Departamento;
        private string _Fec_Baja;

        public int IdArea
        {
            get { return (this._IdArea); }
        }

        public string Area { get { return (this._Area); } }
        public string Horario { get { return (this._Horario); } }
        public string Proyecto { get { return (this._Proyecto); } }
        public string Puesto { get { return (this._Puesto); } }
        public string Departamento { get { return (this._Departamento); } }
        public string Fec_Baja { get { return (this._Fec_Baja); } }

        public string DisplayName
        {
            get { return (this._DisplayName); }
            set { this._DisplayName = value; }
        }

        public string Jefe
        {
            get { return (this._Jefe); }
            set { this._Jefe = value; }
        }
        public string UserWin
        {
            get { return (this._UserWin); }
            set { this._UserWin = value; }
        }
        public string Email
        {
            get { return (this._Email); }
            set { this._Email = value; }
        }


        public int IdJefeInmediato
        {
            get { return (this._IdJefeInmediato); }
            set { this._IdJefeInmediato = value; }
        }



        public int NoEmpl
        {
            get { return (this._NoEmpl); }
            set { this._NoEmpl = value; }
        }

        /// <summary>
        /// Inicializa las propiedades de la clase Empleado
        /// </summary>
        /// <param name="NoEmpl"></param>
        /// <param name="pIdJefeInmediato"></param>
        /// <param name="pDisplayName"></param>
        /// <param name="pEmail"></param>
        /// <param name="pJefe"></param>
        /// <param name="pUserWin"></param>
        /// <returns></returns>
        public static Empleado Inicializa(int pNoEmpl, int pIdJefeInmediato, string pDisplayName, string pEmail, string pJefe, string pUserWin, string pHorario, int pIdArea, string pArea, string pProyecto, string pDepartamento, string pPuesto, string pFec_Baja)
        {
            Empleado miEmp = new Empleado();

            miEmp._NoEmpl = pNoEmpl;
            miEmp._IdJefeInmediato = pIdJefeInmediato;
            miEmp._DisplayName = pDisplayName;
            miEmp._Email = pEmail;

            miEmp._Jefe = pJefe;
            miEmp._UserWin = pUserWin;
            miEmp._Horario = pHorario;

            miEmp._Area = pArea;
            miEmp._IdArea = pIdArea;

            miEmp._Proyecto = pProyecto;
            miEmp._Departamento = pDepartamento;
            miEmp._Puesto = pPuesto;
            miEmp._Fec_Baja = pFec_Baja;
            return miEmp;
        }


        public static int ObtenAccceso(int IdApp, string UserWin)
        {
            int AuxReturn = 0;

            SqlParameter[] Par = new SqlParameter[2];
            SqlDataReader reader;

            Par[0] = new SqlParameter("@IdApp", IdApp);
            Par[1] = new SqlParameter("@UserWin", UserWin);


            reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "AdminEmp..ObtenAcceso", Par);

            if (reader.Read())
            {

                AuxReturn = int.Parse(reader["NivelAcceso"].ToString());
            }

            reader.Close();

            return AuxReturn;
        }

        public static int ObtenAccceso(int IdApp, int NoEmpl)
        {
            int AuxReturn = 0;

            SqlParameter[] Par = new SqlParameter[2];
            SqlDataReader reader;

            Par[0] = new SqlParameter("@IdApp", IdApp);
            Par[1] = new SqlParameter("@IdAgente", NoEmpl);


            reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "AdminEmp..ObtenAcceso", Par);

            if (reader.Read())
            {

                //AuxReturn = int.Parse(reader["IdGrupo"].ToString());
                AuxReturn = int.Parse(reader["NivelAcceso"].ToString());
            }

            reader.Close();

            return AuxReturn;
        }

        public static string ObtenMail(int pNoEmpl)
        {
            string mail = string.Empty;

            string sql = "SELECT  EMail  FROM AdminEmp.dbo.TComplementaAgente WHERE  OperatorId=" + pNoEmpl.ToString();


            SqlConnection sqlCnn;
            SqlCommand sqlCmd;

            sqlCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            sqlCnn.Open();
            sqlCmd = new SqlCommand(sql, sqlCnn);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            if (sqlReader.Read())
            {
                mail = sqlReader.GetValue(0).ToString();
            }

            sqlReader.Close();
            sqlCmd.Dispose();
            sqlCnn.Close();

            return mail;
        }


        /// <summary>
        /// Busca empleado por UserWin
        /// </summary>
        /// <param name="Usuario windows"></param>        
        /// <returns></returns>

        public static Empleado GetEmpleado(string UserWin)
        {

            Empleado miEmp = new Empleado();
            SqlDataReader reader;

            SqlParameter[] Par = new SqlParameter[1];

            Par[0] = new SqlParameter("@UserWin", UserWin);


            reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "AdminEmp..ListaDatosAgente", Par);

            if (reader.Read())
            {
                miEmp = Inicializa(int.Parse(reader["NoEmpl"].ToString()), int.Parse(reader["NoEmplJefe"].ToString()), reader["DisplayName"].ToString(), reader["Correo_ElectronicoCia"].ToString(), reader["Jefe"].ToString(), reader["UserWin"].ToString(), reader["Horario"].ToString(), int.Parse(reader["IdArea"].ToString()), reader["Area"].ToString(), reader["Proyecto"].ToString(), reader["Departamento"].ToString(), reader["Puesto"].ToString(), reader["Fec_Baja"].ToString());
            }

            reader.Close();

            return miEmp;

        }
        /// <summary>
        /// Busca empleado por UserWin o NoEmpl
        /// </summary>
        /// <param name="NoEmpl"></param>
        /// <returns></returns>

        public static Empleado GetEmpleado(int NoEmpl)
        {

            Empleado miEmp = new Empleado();
            SqlDataReader reader;

            SqlParameter[] Par = new SqlParameter[1];

            Par[0] = new SqlParameter("@NoEmpl", NoEmpl);



            reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "AdminEmp..ListaDatosAgente", Par);

            if (reader.Read())
            {

                miEmp = Inicializa(int.Parse(reader["NoEmpl"].ToString()), int.Parse(reader["NoEmplJefe"].ToString()), reader["DisplayName"].ToString(), reader["Correo_ElectronicoCia"].ToString(), reader["Jefe"].ToString(), reader["UserWin"].ToString(), reader["Horario"].ToString(), int.Parse(reader["IdArea"].ToString()), reader["Area"].ToString(), reader["Proyecto"].ToString(), reader["Departamento"].ToString(), reader["Puesto"].ToString(), reader["Fec_Baja"].ToString());
            }

            reader.Close();

            return miEmp;

        }

        /// <summary>
        /// Busca IT para atención
        /// </summary>
        /// <param name="IdIT"></param>
        /// <returns></returns>

        public static int GetAtiende(int IdTipoServicio)
        {

            int miEmp = 0;
            SqlDataReader reader;

            int AuxHr = DateTime.Now.Hour;

            SqlParameter[] Par = new SqlParameter[1];

            Par[0] = new SqlParameter("@IdTipoServicio", IdTipoServicio);


            reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "AdminEmp..GetAtiende", Par);

            if (reader.Read())
            {

                miEmp = int.Parse(reader["IdUsuIndicado"].ToString());

                if (AuxHr >= 13 && reader["IdUsuIndicado2"] != DBNull.Value)
                {
                    miEmp = int.Parse(reader["IdUsuIndicado2"].ToString());
                }

            }

            reader.Close();

            return miEmp;

        }

        /// <summary>
        /// Busca IT para atención
        /// </summary>
        /// <param name="IdIT"></param>
        /// <returns></returns>

        public static int GetAtiende(int IdTipoServicio, ref int HrsAprox)
        {

            int miEmp = 0;
            SqlDataReader reader;

            int AuxHr = DateTime.Now.Hour;

            SqlParameter[] Par = new SqlParameter[1];

            Par[0] = new SqlParameter("@IdTipoServicio", IdTipoServicio);


            reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "AdminEmp..GetAtiende", Par);

            if (reader.Read())
            {

                miEmp = int.Parse(reader["IdUsuIndicado"].ToString());
                HrsAprox = int.Parse(reader["Hrs"].ToString());
                if (AuxHr >= 13 && reader["IdUsuIndicado2"] != DBNull.Value)
                {
                    miEmp = int.Parse(reader["IdUsuIndicado2"].ToString());
                }

            }

            reader.Close();

            return miEmp;

        }

        /// <summary>
        /// Trae todos los empleados like el Nombre introducido
        /// </summary>        
        /// <returns></returns>

        public static List<Empleado> ListaEmpleados(string Nombre)
        {

            Empleado miEmp = new Empleado();
            SqlDataReader reader;

            List<Empleado> empleados = new List<Empleado>();
            SqlParameter[] Par = new SqlParameter[1];
            Par[0] = new SqlParameter("@DisplayName", Nombre);

            reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "AdminEmp..ListaDatosAgente", Par);
            while (reader.Read())
            {
                miEmp = Inicializa(int.Parse(reader["NoEmpl"].ToString()), int.Parse(reader["NoEmplJefe"].ToString()), reader["DisplayName"].ToString(), reader["Correo_ElectronicoCia"].ToString(), reader["Jefe"].ToString(), reader["UserWin"].ToString(), reader["Horario"].ToString(), int.Parse(reader["IdArea"].ToString()), reader["Area"].ToString(), reader["Proyecto"].ToString(), reader["Departamento"].ToString(), reader["Puesto"].ToString(), reader["Fec_Baja"].ToString());
                empleados.Add(miEmp);
            }

            reader.Close();
            return empleados;

        }

        public static Int32 ValidaNoEmpl(int NoEmpl)
        {
            Int32 resp = 0;
            SqlDataReader reader;
            SqlParameter[] Par = new SqlParameter[1];
            Par[0] = new SqlParameter("@NoEmpl", NoEmpl);
            reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "AdminEmp..ValidaIdAgent", Par);

            if (reader.Read()) resp = Convert.ToInt32(reader["Total"].ToString());

            reader.Close();

            return resp;

        }

        public static string ValidaNoEmplVSUserWin(int NoEmpl)
        {
            string resp = "";
            SqlDataReader reader;
            SqlParameter[] Par = new SqlParameter[1];
            Par[0] = new SqlParameter("@NoEmpl", NoEmpl);
            reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "AdminEmp..ValidaIdAgentUserWin", Par);

            if (reader.Read()) resp = reader["UserWin"].ToString();

            reader.Close();

            return resp;

        }

        /// <summary>
        /// Registra datos complementarios
        /// </summary>
        /// <param name="NoEmpl, IdJefeInmediato, UserWin,email"></param>
        /// <param name="IdJefeInmediato"></param>
        /// <param name="UserWin"></param>
        /// <param name="email"></param>

        /// <returns>Campaña</returns>

        public static Empleado Complementa(string UserWin, int NoEmpl)//int NoEmpl,int IdJefeInmediato , string UserWin, string Email)
        {

            SqlParameter[] Par = new SqlParameter[2];

            Par[0] = new SqlParameter("@UserWin", UserWin);
            Par[1] = new SqlParameter("@NoEmpl", NoEmpl);
            //Par[2] = new SqlParameter("@Area", "");
            //Par[2].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "AdminEmp..AsignaUserWinMsgBrittel", Par);

            Empleado miEmp = new Empleado();
            miEmp = Empleado.GetEmpleado(UserWin);

            return miEmp;

        }

    }


}

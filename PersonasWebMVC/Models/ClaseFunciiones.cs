using Microsoft.Data.SqlClient;
using System.Data;
namespace PersonasWebMVC.Models
{
    public class ClaseFunciiones
    {

        public static string cadena = "Server=DESKTOP-IVF5GP5\\SQLEXPRESS;Database=BD_API;User Id=ADSO3234082;Password=12345;TrustServerCertificate=true;";
        public static string excepcion = "";

        public static List<PersonasModel> Func_TraerDatos()
        {
           List<PersonasModel> list = new List<PersonasModel>();
            try
            {
                SqlConnection cnn = new SqlConnection(cadena);
                SqlCommand cmd = new SqlCommand("PA_TRAERPERSONA", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    PersonasModel model = new PersonasModel();
                    model.id = Convert.ToInt64(dr["ID"].ToString());
                    model.Nombre = dr["Nombre"].ToString();
                    model.Telefono = dr["Telefono"].ToString();
                    list.Add(model);
                }
                cnn.Close();
                return list;
            }
            catch (Exception e)
            {
                excepcion = e.ToString();
                return list;
            }
        }
        public static bool Func_Insertar(string name, string tel)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(cadena);
                SqlCommand cmd = new SqlCommand("PA_InsertarPersona", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nom", name);
                cmd.Parameters.AddWithValue("@tel", tel);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch (Exception e)
            {
                excepcion = e.ToString();
                return false;
            }
        }
    }
}

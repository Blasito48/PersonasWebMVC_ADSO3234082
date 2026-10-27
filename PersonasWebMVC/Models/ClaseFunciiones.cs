using Microsoft.Data.SqlClient;
using System.Data;
namespace PersonasWebMVC.Models
{
    public class ClaseFunciiones
    {

        public static string cadena = "Server=DESKTOP-IVF5GP5\\SQLEXPRESS;Database=BD_API;User Id=ADSO3234082;Password=12345;TrustServerCertificate=true;";
        public static string excepcion = "";

        public static bool Func_TraerDatos()
        {
            try
            {
                SqlConnection cnn = new SqlConnection(cadena);
                SqlCommand cmd = new SqlCommand("PA_TraerTodo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
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

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Backend_Mascota.Models
{
    public class gestorMascota
    {

        public List<mascota> getMascotas()
        {
            List<mascota> lista = new List<mascota>();
            string strConn = ConfigurationManager.ConnectionStrings["dblocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "mascota_all";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    int edad = dr.GetInt32(2);
                    string descripcion = dr.GetString(3).Trim();

                    mascota Mascota = new mascota(id, nombre, edad, descripcion);

                    lista.Add(Mascota);
                }

                dr.Close();
                conn.Close();
            }

            return lista;
        }


        public bool addMascota(mascota Mascota)
        {
            bool response = false;
            string strConn = ConfigurationManager.ConnectionStrings["dblocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "mascota_add";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", Mascota.nombre);
                cmd.Parameters.AddWithValue("@edad", Mascota.edad);
                cmd.Parameters.AddWithValue("@descripcion", Mascota.descripcion);

                try
                {

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    response = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    response = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }
                return response;
            }
        }
        public bool updateMascota(int id, mascota Mascota)
        {
            bool response = false;
            string strConn = ConfigurationManager.ConnectionStrings["dblocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "mascota_update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", Mascota.nombre);
                cmd.Parameters.AddWithValue("@edad", Mascota.edad);
                cmd.Parameters.AddWithValue("@descripcion", Mascota.descripcion);

                try
                {

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    response = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    response = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }
                return response;
            }
        }
        public bool deleteMascota(int id)
        {
            bool response = false;
            string strConn = ConfigurationManager.ConnectionStrings["dblocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "mascota_delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                try
                {

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    response = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    response = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }
                return response;
            }
        }
    }
}
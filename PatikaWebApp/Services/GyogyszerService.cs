using MySql.Data.MySqlClient;
using PatikaWebApp.DataManager;
using PatikaWebApp.Models;

namespace PatikaWebApp.Services
{
    public class GyogyszerService
    {
        public List<Gyogyszer> GetAll()
        {
            List<Gyogyszer> result = new List<Gyogyszer>();
            using (MySqlConnection conn = new DBManager().CreateConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM gyogyszer;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Gyogyszer gyogyszer = new Gyogyszer();
                    gyogyszer.Id = reader.GetInt32("Id");
                    gyogyszer.Nev = reader.GetString("Nev");
                    gyogyszer.Hatoanyag = reader.GetString("Hatoanyag");
                    gyogyszer.Venykoteles = reader.GetBoolean("Venykoteles");
                    gyogyszer.kepnev = reader.GetString("kepnev");
                    result.Add(gyogyszer);
                }
            }
            return result;
        }

        public Gyogyszer? GetById(int id)
        {
            Gyogyszer? result = null;
            using (MySqlConnection conn = new DBManager().CreateConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM gyogyszer WHERE Id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = new Gyogyszer();
                    result.Id = reader.GetInt32("Id");
                    result.Nev = reader.GetString("Nev");
                    result.Hatoanyag = reader.GetString("Hatoanyag");
                    result.Venykoteles = reader.GetBoolean("Venykoteles");
                    result.kepnev = reader.GetString("kepnev");
                }
            }
            return result;
        }
    }
}

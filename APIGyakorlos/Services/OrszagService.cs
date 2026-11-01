using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIGyakorlos.Models;
using APIGyakorlos.Interfaces;
using MySql.Data.MySqlClient;
namespace APIGyakorlos.Services
{
    public class OrszagService : ICRUD
    {

        public static MySqlConnection conn = new MySqlConnection();
        public static MySqlCommand cmd = new MySqlCommand();

        public OrszagService()
        {
            conn.ConnectionString = "SERVER = localhost;" +
                                    "DATABASE = olimpikonok;" +
                                    "UID = root;" +
                                    "PORT = 3307;" +
                                    "PASSWORD= ;";

            cmd.Connection = conn;
        }

        public List<Orszag> GetAll()
        {
            conn.Open();

            List<Orszag> orszagok=new List<Orszag>();
            cmd.CommandText = "SELECT * FROM orszag";

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {
                Orszag orszag = new Orszag();

                orszag.Id = reader.GetInt32("Id");
                orszag.Nev = reader.GetString("Nev");
                orszag.Fovaros = reader.GetString("Fovaros");

                orszag.Nepesseg = reader.GetInt32("Nepesseg");

                orszagok.Add(orszag);

            }
            conn.Close();

            if (orszagok.Count > 0) return orszagok;
            else throw new Exception("Hiba történt");

        }

        public Orszag GetById(int id)
        {
            conn.Open();
            cmd.CommandText = "SELECT * FROM orszag Where Id=@id";

            cmd.Parameters.AddWithValue("@id", id);


            Orszag orszag = null;

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                orszag = new Orszag();
                orszag.Id = reader.GetInt32("Id");
                orszag.Nev = reader.GetString("Nev");
                orszag.Fovaros = reader.GetString("Fovaros");

                orszag.Nepesseg = reader.GetInt32("Nepesseg");
            }
            conn.Close();

            if (orszag is not null) return orszag;
            else throw new Exception("Nincs a keresett id-val rendelkező ország");


        }
      
      

        public string Insert(Orszag orszag)
        {
            cmd.Parameters.Clear();
            conn.Open();
            cmd.CommandText = "INSERT INTO Orszag(nev, fovaros, nepesseg) VALUES(@m1, @m2, @m3);";

            cmd.Parameters.AddWithValue("@m1", orszag.Nev);
            cmd.Parameters.AddWithValue("@m2", orszag.Fovaros);
            cmd.Parameters.AddWithValue("@m3", orszag.Nepesseg);


            int sorok = cmd.ExecuteNonQuery();

            conn.Close();

            if (sorok > 0) return "Sikeres ország insert";
            else return "Sikertelen ország insert";


        }

        public string Update(Orszag orszag)
        {
            cmd.Parameters.Clear();
            conn.Open();
            cmd.CommandText = "UPDATE  Orszag SET Nev=@m1, Fovaros=@m2, Nepesseg=@m3 WHERE Id=@m4;";

            cmd.Parameters.AddWithValue("@m1", orszag.Nev);
            cmd.Parameters.AddWithValue("@m2", orszag.Fovaros);
            cmd.Parameters.AddWithValue("@m3", orszag.Nepesseg);
            cmd.Parameters.AddWithValue("@m4", orszag.Id);


            int sorok = cmd.ExecuteNonQuery();

            conn.Close();

            if (sorok > 0) return "Sikeres ország update";
            else return "Sikertelen ország update";


        }

        public string Delete(int id)
        {
            cmd.Parameters.Clear();
            conn.Open();
            cmd.CommandText = "DELETE FROM   Orszag WHERE Id=@m1;";

            cmd.Parameters.AddWithValue("@m1", id);
          
            int sorok = cmd.ExecuteNonQuery();

            conn.Close();

            if (sorok > 0) return "Sikeres ország törlés";
            else return "Sikertelen ország törlés";
        }

    }
}

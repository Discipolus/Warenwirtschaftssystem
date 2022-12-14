using Engine.Konstrukte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Engine.Logik.Warenlogistik
{
    internal static class SpeichernLaden
    {
        private static readonly string DateinameKatalog = "Katalog.xml";
        private static readonly string DateinameLagerhäuser = "Lagerhäuser.xml";
        //private static readonly string connectionString = @"Data Source=BIGGREEN;Initial Catalog=WWSystem;User ID=WWSystemZugriff;Password=AbC12Test";
        private static readonly string connectionString = @"Data Source=FVTOGNB0146\SQLEXPRESS;Initial Catalog=WWSystem; Integrated Security=true"; //FVTOGNB0146\SQLEXPRESS
        private static SqlConnection conn = new SqlConnection(connectionString);

        static SpeichernLaden()
        {
        }
        internal static void KatalogSpeichern(List<KatalogItem> katalog)
        {
            try
            {
                string sqlvalues = katalog[0].ToSqlValue();
                for (int i = 1; i < katalog.Count; i++)
                {
                    sqlvalues += ", " + katalog[i].ToSqlValue();
                }
                string sql = "Insert into Produkte (Name, MaßeX, MaßeY, MaßeZ, Guid, Lagerhäuser) values " + sqlvalues + ";";
                SqlDataAdapter adapter = new SqlDataAdapter();
                conn.Open();
                adapter.InsertCommand = new SqlCommand(sql, conn);
                adapter.InsertCommand.ExecuteNonQuery();
                conn.Close();
                adapter.Dispose();
            }
            catch
            {
                string message = "Katalog konnte nicht in SQL Datenbank gespeichert werden. Speichere lokal.";
                Console.WriteLine(message);
                Speichern<List<KatalogItem>>(katalog, DateinameKatalog);
            }
        }
        internal static void LagerhäuserSpeichern(List<Lagerhaus> lagerhäuser)
        {
            Speichern<List<Lagerhaus>>(lagerhäuser, DateinameLagerhäuser);
        }
        internal static void Speichern<T>(T item, string name)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            FileStream file = File.Create(Environment.CurrentDirectory + "//" + name);
            xmlSerializer.Serialize(file, item);
            file.Close();
        }
        internal static void Speichern<T>(T item, string name, string table)
        {

        }
        internal static List<KatalogItem>? KatalogLaden()
        {
            //try
            //{
                string sql = "Select * from Produkte";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                List<KatalogItem> list = new List<KatalogItem>();
                //(Name, MaßeX, MaßeY, MaßeZ, Guid, Lagerhäuser)
                while (reader.Read())
                {
                    string name = (string)reader.GetValue(0);
                    MaßeTemplate maße = new MaßeTemplate((double)reader.GetValue(1), (double)reader.GetValue(2), (double)reader.GetValue(3));
                    Guid GUID = (Guid)reader.GetValue(4);
                    List<int> lagerhäuser = new List<int>();
                    foreach (string s in ((string)reader.GetValue(5)).Split(";"))
                    {
                        int item;
                        if (int.TryParse(s, out item))
                        {
                            lagerhäuser.Add(item);
                        }
                    }

                    list.Add(new KatalogItem(name, maße, lagerhäuser, GUID));
                }
                return list;
            //}
            //catch
            //{
            //    string message = "Katalog konnte nicht aus SQL Datenbank geladen werden. Versuche lokale Datei zu laden.";
            //    Console.WriteLine(message);
            //    return Laden<List<KatalogItem>>(DateinameKatalog);
            //}
        }
        internal static List<Lagerhaus>? LagerhäuserLaden()
        {
            return Laden<List<Lagerhaus>>(DateinameLagerhäuser);
        }
        internal static T? Laden<T>(string name)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            FileStream file;
            try
            {
                file = File.Open(Environment.CurrentDirectory + "//" + name, FileMode.Open);
                try
                {
                    T? tmp = ((T?)xmlSerializer.Deserialize(file));
                    file.Close();
                    return tmp;
                }
                catch (Exception ex)
                {
                    file.Close();
                    Console.WriteLine("File konnte nicht korrekt gelesen werden: " + ex.Message);
                    return default(T);
                }
            }
            catch
            {                
                Console.WriteLine("File konnte nicht gefunden werden.");
                return default(T);
            }            
        }

    }
}

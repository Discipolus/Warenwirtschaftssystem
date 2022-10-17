using Engine.Konstrukte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Engine.Logik.Warenlogistik
{
    internal static class KatalogSpeichernLaden
    {
        private static readonly string DateinameKatalog = "Katalog.xml";
        private static readonly string DateinameLagerhäuser = "Lagerhäuser.xml";

        internal static void KatalogSpeichern(List<KatalogItem> katalog)
        {
            Speichern<List<KatalogItem>>(katalog, DateinameKatalog);
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
        internal static List<KatalogItem>? KatalogLaden()
        {
            return Laden<List<KatalogItem>>(DateinameKatalog);
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

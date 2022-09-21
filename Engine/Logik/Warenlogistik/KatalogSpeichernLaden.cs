using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Engine.Logik.Warenlogistik
{
    internal static class KatalogSpeichernLaden
    {
        private static readonly string pfad = Environment.CurrentDirectory + "//Katalog.xml";
        public static void KatalogSpeichern(SortedList<Guid, Produkt> katalog)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Produkt>));
            FileStream file = File.Create(pfad);
            xmlSerializer.Serialize(file, ConvertToList(katalog));
            file.Close();            
        }
        private static List<Produkt>? ConvertToList(SortedList<Guid, Produkt>? katalog)
        {
            if (katalog != null)
            {
                List<Produkt> list = new List<Produkt>();
                foreach (KeyValuePair<Guid, Produkt> kv in katalog)
                {
                    list.Add(kv.Value);
                }
                return list;
            }
            else
            {
                return null;
            }
        }
        private static SortedList<Guid, Produkt>? ConvertToSortedList(List<Produkt>? katalog)
        {
            if (katalog != null)
            {
                SortedList<Guid, Produkt> list = new SortedList<Guid, Produkt>();
                foreach (Produkt p in katalog)
                {
                    list.Add(p.GUID, p);
                }
                return list;
            }
            else
            {
                return null;
            }
        }
        public static SortedList<Guid, Produkt>? KatalogLaden()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Produkt>));
            FileStream file = File.Open(pfad, FileMode.Open);
            if (file != null)
            {
                List<Produkt>? templist;
                try
                {
                    templist = (List<Produkt>?)xmlSerializer.Deserialize(file);
                    return ConvertToSortedList(templist);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("File konnte nicht korrekt gelesen werden: " + ex.Message);
                    return null;
                }                
            }
            else
            {
                return null;
            }


        }
    }
}

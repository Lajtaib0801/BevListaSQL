using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BevListaSQL
{
    public class Termek
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }
        public string Nev { get; set; }
        public int Db { get; set; }
        public string Kategoria { get; set; }
        public string ImgURL { get; set; }

        public Termek(string nev, int db, string kategoria)
        {
            Nev = nev;
            Db = db;
            Kategoria = kategoria;
            SetImgUrl();
        }

        public Termek()
        {
            
        }

        private void SetImgUrl()
        {
            if (Kategoria == "")
                ImgURL = "none";
            Dictionary<char, char> betuKeszlet = new Dictionary<char, char>() { { 'á', 'a' }, { 'é', 'e' }, { 'í', 'i' }, { 'ó', 'o' }, { 'ö', 'o' }, { 'ő', 'o' }, { 'ú', 'u' }, { 'ű', 'u' }, { 'ü', 'u' } };
            foreach (var betu in Kategoria)
            {
                ImgURL += betuKeszlet.ContainsKey(betu) ? betuKeszlet[betu] : betu;
            }
            ImgURL += ".png";
        }
    }
}

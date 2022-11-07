using System;
using SQLite;

namespace RuokaArpojaApp.Models
{
    public class Ruoka
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string RuuanNimi { get; set; }

    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using RuokaArpojaApp.Models;

namespace RuokaArpojaApp.Data
{
    public class RuokaArpojaDatabase
    {
        readonly SQLiteAsyncConnection database;

        public RuokaArpojaDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Ruoka>().Wait();
        }

        public Task<List<Ruoka>> HaeRuuatAsync()
        {
            //Tuo kaikki ruuat.
            return database.Table<Ruoka>().ToListAsync();
        }

        public Task<Ruoka> HaeRuuatAsync(int id)
        {
            // Tuo tietyn ruuan.
            return database.Table<Ruoka>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> TallennaRuokaAsync(Ruoka ruoka)
        {
            if (ruoka.ID != 0)
            {
                // Muokkaa olemassa olevaa ruokaa.
                return database.UpdateAsync(ruoka);
            }
            else
            {
                // Tallenna uusi ruoka.
                return database.InsertAsync(ruoka);
            }
        }

        public Task<int> DeleteNoteAsync(Ruoka ruoka)
        {
            // Poista ruoka.
            return database.DeleteAsync(ruoka);
        }
    }
}

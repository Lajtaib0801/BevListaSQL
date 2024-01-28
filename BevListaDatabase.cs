using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BevListaSQL
{
    public class BevListaDatabase
    {
        SQLiteAsyncConnection Database;

        public BevListaDatabase()
        {

        }

        async Task Init()
        {
            if (Database is not null)
                return;
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.CreateTableAsync<Termek>();
        }

        public async Task<List<Termek>> GetItemsAsync()
        {
            Init();
            return Database.Table<Termek>().ToListAsync().Result;
        }

        public async Task<int> SaveItemAsync(Termek termek)
        {
            await Init();
            return await Database.InsertAsync(termek);
        }

        public async Task<int> DeleteItemAsync(Termek termek)
        {
            await Init();
            return await Database.DeleteAsync(termek);
        }
    }
}

using DayCounter.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DayCounter
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath,true);
            _database.CreateTableAsync<Interval>().Wait();
        }

        public Task<List<Interval>> GetIntervalAsync()
        {
            return _database.Table<Interval>().ToListAsync();
        }

        public Task<int> SaveIntervalAsync(Interval interval)
        {
            return _database.InsertAsync(interval);
        }

        public Task<int> ModifyIntervalAsync(Interval interval)
        {
            return _database.UpdateAsync(interval);
        }


    }

    
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace AvaloniaApplication6.Models;

public class PeopleViaSQLite : IAccessToPeople
{
    private SQLiteConnection _connection;
    
    public PeopleViaSQLite()
    {
        _connection = new SQLiteConnection();
        _connection.ConnectionString = @"Data Source=d:\sqlite\database.db;Version=3;";    
    }
    
    public bool Connect()
    {
        _connection.Open();
        return true;
    }

    public void Disconnect()
    {
        _connection.Close();
    }

    public async Task<int> FillTheCollectionAsync(ObservableCollection<Person> people, DateTime date)
    {
        string query = $"SELECT * FROM reser_cond WHERE dtLastModified LIKE '{date:yyyy-MM-dd}%'";
        IEnumerable<Person> result = await _connection.QueryAsync<Person>(query);
        people.Clear();
        foreach (var p in result)
        {
            people.Add(p);
        }
        return people.Count;
    }
}
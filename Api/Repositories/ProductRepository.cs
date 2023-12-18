using System.Data;
using Api.Entities;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Api.Repositories;

public class ProductRepository : IDisposable
{
    private readonly IDbConnection _connection;
    private readonly string _tempFile;

    public ProductRepository()
    {
        _tempFile = Path.GetTempFileName();

        _connection = new SqliteConnection($"Data Source={_tempFile};Pooling=False");
        _connection.Open();

        _connection.Execute("CREATE TABLE Products (Name TEXT, Price REAL)");

        _connection.Execute("INSERT INTO Products (Name, Price) VALUES (@Name, @Price)", new { Name = "Borstel", Price = 10.0m });
        _connection.Execute("INSERT INTO Products (Name, Price) VALUES (@Name, @Price)", new { Name = "Stofzuiger", Price = 100.0m });
        _connection.Execute("INSERT INTO Products (Name, Price) VALUES (@Name, @Price)", new { Name = "Stofzuigerzak", Price = 5.0m });
        _connection.Execute("INSERT INTO Products (Name, Price) VALUES (@Name, @Price)", new { Name = "Dweil", Price = 2.0m });
        _connection.Execute("INSERT INTO Products (Name, Price) VALUES (@Name, @Price)", new { Name = "Dweilstok", Price = 5.0m });
        _connection.Execute("INSERT INTO Products (Name, Price) VALUES (@Name, @Price)", new { Name = "Dweilbak", Price = 10.0m });
    }

    public Task<IEnumerable<ProductEntity>> GetAll()
    {
        return _connection.QueryAsync<ProductEntity>("SELECT * FROM Products");
    }

    public Task<IEnumerable<ProductEntity>> Search(string name)
    {
        return _connection.QueryAsync<ProductEntity>("SELECT * FROM Products WHERE Name LIKE @Name", new { Name = $"%{name}%" });
    }

    public Task<IEnumerable<ProductEntity>> Search2(string name)
    {
        return _connection.QueryAsync<ProductEntity>($"SELECT * FROM Products WHERE Name LIKE '%{name}%'");
    }

    public void Dispose()
    {
        _connection.Close();

        File.Delete(_tempFile);
    }
}
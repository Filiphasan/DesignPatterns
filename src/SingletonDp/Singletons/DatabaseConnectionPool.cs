using System.Collections.Concurrent;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SingletonDp.Singletons;

public class DatabaseConnectionPool
{
    public static string? ConnectionString;
    public static int MaxPoolSize;
    
    private static readonly Lazy<DatabaseConnectionPool> _instance = new(() => new DatabaseConnectionPool());
    public static DatabaseConnectionPool Instance => _instance.Value;

    private readonly ConcurrentBag<IDbConnection> _connectionPool;

    private DatabaseConnectionPool()
    {
        _connectionPool = new ConcurrentBag<IDbConnection>();

        for (int i = 0; i < MaxPoolSize; i++)
        {
            var connection = new SqlConnection(ConnectionString);
            // connection.Open();
            _connectionPool.Add(connection);
        }
    }
    
    public IDbConnection Get()
    {
        if (_connectionPool.TryTake(out var connection))
        {
            return connection;
        }

        var newConnection = new SqlConnection(ConnectionString);
        newConnection.Open();
        if (_connectionPool.Count < MaxPoolSize)
        {
            _connectionPool.Add(newConnection);
        }
        return newConnection;
    }

    public void Return(IDbConnection connection)
    {
        if (connection.State == ConnectionState.Open && _connectionPool.Count < MaxPoolSize)
        {
            _connectionPool.Add(connection);
        }
        else
        {
            connection.Dispose();
        }
    }
}
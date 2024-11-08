using System.Reflection;

namespace DisposableDp.Helpers;

public sealed class CsvReaderHelper : IDisposable
{
    private bool _disposed;

    private StreamReader? _streamReader;

    public CsvReaderHelper(string filePath)
    {
        _streamReader = new StreamReader(filePath);
    }

    public CsvReaderHelper(Stream stream)
    {
        _streamReader = new StreamReader(stream);
    }

    public List<T> ReadAll<T>(bool hasHeader = true) where T : class
    {
        ArgumentNullException.ThrowIfNull(_streamReader);

        if (hasHeader)
        {
            _streamReader.ReadLine();
        }

        var list = new List<T>();
        var properties = GetProperties<T>();
        while (!_streamReader.EndOfStream)
        {
            var line = _streamReader.ReadLine();
            if (line is null)
            {
                continue;
            }

            var instance = GetInstance<T>(properties, line);
            list.Add(instance);
        }

        return list;
    }

    public async Task<List<T>> ReadAllAsync<T>(bool hasHeader = true, CancellationToken cancellationToken = default) where T : class
    {
        ArgumentNullException.ThrowIfNull(_streamReader);

        if (hasHeader)
        {
            await _streamReader.ReadLineAsync(cancellationToken);
        }

        var list = new List<T>();
        var properties = GetProperties<T>();
        while (!_streamReader.EndOfStream)
        {
            var line = await _streamReader.ReadLineAsync(cancellationToken);
            if (line is null)
            {
                continue;
            }

            var instance = GetInstance<T>(properties, line);
            list.Add(instance);
        }

        return list;
    }

    private static T GetInstance<T>(PropertyInfo[] properties, string line) where T : class
    {
        var instance = Activator.CreateInstance<T>();

        int index = 0;
        Console.WriteLine(line);
        var values = line.Split(',');
        foreach (var property in properties)
        {
            property.SetValue(instance, Convert.ChangeType(values[index], property.PropertyType));
            index++;
        }

        return instance;
    }

    private static PropertyInfo[] GetProperties<T>()
    {
        return typeof(T).GetProperties();
    }


    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            _streamReader?.Close();
            _streamReader?.Dispose();
            _streamReader = null;
        }

        // Release unmanaged objects here.
        _disposed = true;
    }

    ~CsvReaderHelper()
    {
        Dispose(false);
    }
}
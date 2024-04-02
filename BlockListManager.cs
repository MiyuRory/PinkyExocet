using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class BlockListManager
{
    private readonly string _filePath;

    public BlockListManager(CancellationToken cancellationToken = default)
    {
        _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "already_blocked.txt");
        InitializeAsync(cancellationToken).Wait(); // Espera de manera sincrónica la inicialización. Considera manejar esto de otra manera dependiendo de tu flujo de aplicación.
    }

    private async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        if (!File.Exists(_filePath))
        {
            using (var stream = File.Create(_filePath))
            {
                await stream.FlushAsync(cancellationToken); // Asegura que todo el contenido sea escrito al disco.
            }
        }
    }

    public async Task<bool> IsInTheListAsync(string text, CancellationToken cancellationToken = default)
    {
        var lines = await File.ReadAllLinesAsync(_filePath, cancellationToken);
        return lines.Any(line => line.Equals(text, StringComparison.OrdinalIgnoreCase));
    }

    public async Task SaveInTheListAsync(string text)
    {
        using StreamWriter streamWriter = File.AppendText(_filePath);

        await streamWriter.WriteLineAsync(text);

    }
}

using NAudio.Wave;
using System;
using System.IO;
using System.Threading.Tasks;

public class Mp3Player : IDisposable
{
    private IWavePlayer waveOutDevice;
    private AudioFileReader audioFileReader;

    public Mp3Player()
    {
    }

    public async Task PlayAsync(string fileName)
    {
        await Task.Run(() =>
        {
            // Asegúrate de detener y limpiar cualquier reproducción anterior
            Stop();

            // Obtiene la ruta del directorio donde se está ejecutando la aplicación.
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            // Construye la ruta completa al archivo MP3.
            var fullPath = Path.Combine(directory, fileName);

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("El archivo no fue encontrado", fullPath);
            }

            // Inicializa el reproductor de audio y el lector de archivos
            waveOutDevice = new WaveOutEvent();
            audioFileReader = new AudioFileReader(fullPath);

            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();
        });
    }

    public void Stop()
    {
        waveOutDevice?.Stop();
        DisposeWaveOutDevice();
    }

    private void DisposeWaveOutDevice()
    {
        if (waveOutDevice != null)
        {
            waveOutDevice.Dispose();
            waveOutDevice = null;
        }

        if (audioFileReader != null)
        {
            audioFileReader.Dispose();
            audioFileReader = null;
        }
    }

    public void Dispose()
    {
        DisposeWaveOutDevice();
    }
}

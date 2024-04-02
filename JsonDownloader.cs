using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkyExocet
{
    public static class JsonDownloader
    {
        public static async Task<Dictionary<string, long>> DownloadAndParseJsonAsync(string url, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                throw new OperationCanceledException(cancellationToken);
            using var httpClient = new HttpClient();

            try
            {
                // Realiza una solicitud GET sincrónica
                var response = await httpClient.GetAsync(url, cancellationToken); // Nota: .Result bloquea hasta que la tarea asincrónica completa
                if (response.IsSuccessStatusCode)
                {
                    // Lee el contenido de la respuesta como un string de manera sincrónica
                    var jsonString = await response.Content.ReadAsStringAsync(cancellationToken); // Uso de .Result aquí también
                                                                                 // Deserializa el string JSON en un diccionario
                    var result = JsonConvert.DeserializeObject<Dictionary<string, long>>(jsonString);
                    return result ?? new Dictionary<string, long>();
                }
                else
                {
                    throw new HttpRequestException($"Error al realizar la solicitud: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                return null ?? new Dictionary<string, long>();
            }

        }
    }
}

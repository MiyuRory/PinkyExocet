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
        public static Dictionary<string, long> DownloadAndParseJson(string url)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    // Realiza una solicitud GET sincrónica
                    var response = httpClient.GetAsync(url).Result; // Nota: .Result bloquea hasta que la tarea asincrónica completa
                    if (response.IsSuccessStatusCode)
                    {
                        // Lee el contenido de la respuesta como un string de manera sincrónica
                        var jsonString = response.Content.ReadAsStringAsync().Result; // Uso de .Result aquí también
                                                                                      // Deserializa el string JSON en un diccionario
                        var result = JsonConvert.DeserializeObject<Dictionary<string, long>>(jsonString);
                        return result;
                    }
                    else
                    {
                        throw new HttpRequestException($"Error al realizar la solicitud: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocurrió un error: {ex.Message}");
                    return null;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkyExocet
{
    using System;
    using System.IO;
    using System.Linq;

    public class BlockListManager
    {
        private readonly string _filePath;

        public BlockListManager()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "already_blocked.txt");
            Initialize();
        }

        private void Initialize()
        {
            // Verifica si el archivo ya existe; si no, lo crea.
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Dispose(); // Crea el archivo y luego cierra el flujo.
            }
        }

        public bool IsInTheList(string text)
        {
            // Lee todas las líneas del archivo y verifica si alguna contiene el texto proporcionado.
            return File.ReadLines(_filePath).Any(line => line.Equals(text, StringComparison.OrdinalIgnoreCase));
        }

        public void SaveInTheList(string text)
        {
            // Añade el texto proporcionado como una nueva línea al final del archivo.
            using (StreamWriter streamWriter = File.AppendText(_filePath))
            {
                streamWriter.WriteLine(text);
            }
        }
    }
}

namespace PinkyExocet;

internal static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static async Task Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        // Realiza alguna inicialización asíncrona aquí antes de mostrar el formulario principal.
        await InitializeAsync();

        Application.Run(new Launcher());
    }

    private static async Task InitializeAsync()
    {
        // Ejemplo de inicialización asíncrona
        await Task.Delay(1000); // Simula un trabajo asíncrono, como cargar configuraciones o realizar la inicialización de la red.
                                // Agrega aquí cualquier otro código de inicialización asíncrona necesario.
    }
}
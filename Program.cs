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

        // Realiza alguna inicializaci�n as�ncrona aqu� antes de mostrar el formulario principal.
        await InitializeAsync();

        Application.Run(new Launcher());
    }

    private static async Task InitializeAsync()
    {
        // Ejemplo de inicializaci�n as�ncrona
        await Task.Delay(1000); // Simula un trabajo as�ncrono, como cargar configuraciones o realizar la inicializaci�n de la red.
                                // Agrega aqu� cualquier otro c�digo de inicializaci�n as�ncrona necesario.
    }
}
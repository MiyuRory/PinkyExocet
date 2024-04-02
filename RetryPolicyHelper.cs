using OpenQA.Selenium;
using Polly;
using System;
using System.Threading.Tasks;

public static class RetryPolicyHelper
{
    // Define una política de reintentos estática para configurarla solo una vez
    private static readonly AsyncPolicy RetryPolicy = Policy
        .Handle<ElementNotInteractableException>()
        .Or<Exception>()
        .Or<NoSuchElementException>()
        .RetryAsync(10);

    // Este método acepta un delegado Func<Task> y lo ejecuta bajo la política de reintentos
    public static async Task ExecuteWithRetryAsync(Func<Task> actionToExecuteAsync)
    {
        await RetryPolicy.ExecuteAsync(actionToExecuteAsync);
    }
}

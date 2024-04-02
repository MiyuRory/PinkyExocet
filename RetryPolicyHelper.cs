using OpenQA.Selenium;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkyExocet
{
    public static class RetryPolicyHelper
    {
        // Define a retry policy that is static so it's only set up once
        private static readonly Policy RetryPolicy = Policy
            .Handle<ElementNotInteractableException>()
            .Or<Exception>()
            .Or<NoSuchElementException>()
            .Retry(10, onRetry: (exception, retryCount, context) =>
            {
                
            });

        // This method accepts an Action delegate and executes it under the retry policy
        public static void ExecuteWithRetry(Action actionToExecute)
        {
            RetryPolicy.Execute(actionToExecute);
        }
    }
}

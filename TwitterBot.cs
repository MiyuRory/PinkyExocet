using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Microsoft.VisualBasic;

namespace PinkyExocet
{
    public class TwitterBot
    {
        private IWebDriver bot;

        private string user;
        private string password;
        private bool hasAuthenticator;

        public TwitterBot(string email, string password, bool hasAuthenticator)
        {
            this.user = email;
            this.password = password;
            this.hasAuthenticator = hasAuthenticator;
            bot = new ChromeDriver(); // Initialize ChromeDriver. Make sure chromedriver is in your PATH or specify its location.

        }

        public void Stop() => bot.Quit();

        public async Task LoginAsync(CancellationToken cancellationToken = default)
        {
            await Task.Run(async () =>
            {
                // Fetches the login page
                bot.Navigate().GoToUrl("https://twitter.com/login");

                // Adjust the sleep time according to your internet speed
                //RetryPolicyHelper.ExecuteWithRetry(() => { });

                await RetryPolicyHelper.ExecuteWithRetryAsync(async () =>
                {
                    await Task.Delay(GenerateRandomNumber() + 2000);
                    var emailField = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[5]/label[1]/div[1]/div[2]/div[1]/input[1]"));
                    emailField.SendKeys(user);
                });

                await RetryPolicyHelper.ExecuteWithRetryAsync(async () =>
                {
                    IWebElement nextButton = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[6]/div[1]/span[1]/span[1]"));
                    await Task.Delay(GenerateRandomNumber());
                    nextButton.Click();
                });

                await RetryPolicyHelper.ExecuteWithRetryAsync(async () =>
                {
                    await Task.Delay(GenerateRandomNumber());
                    var passwordField = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/label[1]/div[1]/div[2]/div[1]/input[1]"));
                    passwordField.SendKeys(password);
                });

                await RetryPolicyHelper.ExecuteWithRetryAsync(async () =>
                {
                    await Task.Delay(GenerateRandomNumber());
                    var loginButton = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/span[1]/span[1]"));
                    loginButton.Click();
                });


                if (hasAuthenticator)
                {
                    await RetryPolicyHelper.ExecuteWithRetryAsync(async () =>
                    {
                        await Task.Delay(GenerateRandomNumber() + 2000);
                        var codeField = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/label[1]/div[1]/div[2]/div[1]/input[1]"));
                        codeField.SendKeys(Interaction.InputBox("Authenticator code"));
                        await Task.Delay(GenerateRandomNumber() + 20000);
                    });

                    await RetryPolicyHelper.ExecuteWithRetryAsync(async () =>
                    {
                        await Task.Delay(GenerateRandomNumber());
                        var nextButton2 = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/span[1]/span[1]"));
                        nextButton2.Click();
                    });

                }
            });


        }

        public async Task BlockUserAsync(string user, CancellationToken cancellationToken = default)
        {
            await Task.Run(async () =>
            {
                //RetryPolicyHelper.ExecuteWithRetry(() => { });

                await RetryPolicyHelper.ExecuteWithRetryAsync(async () =>
                {
                    await Task.Delay(GenerateRandomNumber());
                    var searchBox = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/div[1]/label[1]/div[2]/div[1]/input[1]"));
                    searchBox.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                    searchBox.SendKeys(OpenQA.Selenium.Keys.Delete);
                    searchBox.SendKeys(user);
                });

                ///html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/div[2]/div[1]/div[4]/div[1]/div[1]/span[1]
                try
                {
                    IReadOnlyList<IWebElement> realMatch = new List<IWebElement>();
                    IWebElement firstResult = null;
                    await RetryPolicyHelper.ExecuteWithRetryAsync(async () =>
                    {
                        await Task.Delay(GenerateRandomNumber() + 1000);
                        firstResult = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/div[2]/div[1]/div[4]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/span[1]"));
                        
                        try
                        {
                            // Asume que ExecuteWithRetry es un método asíncrono o ajusta tu implementación para que lo sea.
                            // Es importante manejar las operaciones de espera de manera asíncrona en lugar de usar Thread.Sleep,
                            // lo cual bloquearía el hilo de ejecución.
                            await RetryPolicyHelper.ExecuteWithRetryAsync(async () =>
                            {
                                // Usa Task.Delay para la espera asíncrona.
                                await Task.Delay(GenerateRandomNumber() + 1000);
                                realMatch = bot.FindElements(By.XPath($"//*[text()='@{user}']"));
                            });
                        }
                        catch (NoSuchElementException)
                        {
                            // Manejo opcional de la excepción
                        }
                    });
                    if (realMatch.Count > 0 && firstResult != null && firstResult.Text == "@" + user)
                    {
                        firstResult.Click();
                    }
                    else
                    {
                        return Task.CompletedTask;
                    }
                }
                catch (Exception)
                {
                    return Task.CompletedTask;
                }


                // Inicializa elementsContainingText con una lista vacía en lugar de null.
                IReadOnlyList<IWebElement> elementsContainingText = new List<IWebElement>();

                try
                {
                    // Asume que ExecuteWithRetry es un método asíncrono o ajusta tu implementación para que lo sea.
                    // Es importante manejar las operaciones de espera de manera asíncrona en lugar de usar Thread.Sleep,
                    // lo cual bloquearía el hilo de ejecución.
                    await RetryPolicyHelper.ExecuteWithRetryAsync(async () =>
                    {
                        // Usa Task.Delay para la espera asíncrona.
                        await Task.Delay(GenerateRandomNumber() + 1000);
                        elementsContainingText = bot.FindElements(By.XPath($"//*[contains(text(), '{"está bloqueado"}')]"));
                    });
                }
                catch (NoSuchElementException)
                {
                    // Manejo opcional de la excepción
                }

                // Verifica si algún elemento fue encontrado y si el primer elemento está visible.
                if (elementsContainingText.Count > 0 && elementsContainingText[0].Displayed)
                {
                    return Task.CompletedTask;
                }
                ///html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/*[name()='svg'][1]
                ///html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/*[name()='svg'][1]
                ///html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]
                ///html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/*[name()='svg'][1]/*[name()='g'][1]/*[name()='path'][1]

                try
                {
                    await RetryPolicyHelper.ExecuteWithRetryAsync(async () =>
                    {
                        await Task.Delay(GenerateRandomNumber());
                        var threeDots = bot.FindElement(By.XPath("html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/*[name()='svg'][1]"));
                        threeDots.Click();
                    });
                }
                catch (Exception)
                {
                    try
                    {
                        await RetryPolicyHelper.ExecuteWithRetryAsync(async () =>
                        {
                            await Task.Delay(GenerateRandomNumber());
                            IWebElement? threeDots = null;
                            try
                            {
                                threeDots = bot.FindElement(By.XPath("html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]"));
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    threeDots = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/*[name()='svg'][1]/*[name()='g'][1]/*[name()='path'][1]"));
                                }
                                catch (Exception)
                                {
                                    threeDots = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/*[name()='svg'][1]"));
                                    throw;
                                }
                            }
                            threeDots.Click();
                        });

                    }
                    catch (Exception)
                    {
                        return Task.CompletedTask;

                    }

                }

                ///html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/span[1]
                try
                {
                    await RetryPolicyHelper.ExecuteWithRetryAsync(async () =>
                    {
                        await Task.Delay(GenerateRandomNumber());
                        var blockButton = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[3]/div[1]/div[1]/div[1]/div[4]/div[2]/div[1]/span[1]"));
                        blockButton.Click();
                    });
                }
                catch (Exception)
                {
                    await RetryPolicyHelper.ExecuteWithRetryAsync(async () =>
                    {
                        await Task.Delay(GenerateRandomNumber());
                        var blockButton = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/span[1]"));
                        blockButton.Click();
                    });
                }


                await RetryPolicyHelper.ExecuteWithRetryAsync(async () =>
                {
                    await Task.Delay(GenerateRandomNumber());
                    var confirmBlockButton = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/span[1]/span[1]"));
                    confirmBlockButton.Click();
                });


                return Task.CompletedTask;
            });


        }

        public string GetHtml() => bot.PageSource;



        private int GenerateRandomNumber()
        {
            // Create an instance of the Random class
            Random random = new Random();

            // Generate and return a random number between 1000 and 3000
            return random.Next(300, 700); // Note: Upper bound is exclusive
        }
    }
}

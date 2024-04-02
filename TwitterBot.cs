﻿using OpenQA.Selenium.Chrome;
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

        public void Login()
        {
            // Fetches the login page
            bot.Navigate().GoToUrl("https://twitter.com/login");

            // Adjust the sleep time according to your internet speed
            //RetryPolicyHelper.ExecuteWithRetry(() => { });

            RetryPolicyHelper.ExecuteWithRetry(() => {
                Thread.Sleep(GenerateRandomNumber()+2000);
                var emailField = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[5]/label[1]/div[1]/div[2]/div[1]/input[1]"));
                emailField.SendKeys(user);
            });

            RetryPolicyHelper.ExecuteWithRetry(() => {
                IWebElement nextButton = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[6]/div[1]/span[1]/span[1]"));
                Thread.Sleep(GenerateRandomNumber());
                nextButton.Click();
            });

            RetryPolicyHelper.ExecuteWithRetry(() => {
                Thread.Sleep(GenerateRandomNumber());
                var passwordField = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[3]/div[1]/label[1]/div[1]/div[2]/div[1]/input[1]"));
                passwordField.SendKeys(password);
            });

            RetryPolicyHelper.ExecuteWithRetry(() => {
                Thread.Sleep(GenerateRandomNumber());
                var loginButton = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/span[1]/span[1]"));
                loginButton.Click();
            });


            if (hasAuthenticator)
            {
                RetryPolicyHelper.ExecuteWithRetry(() => {
                    Thread.Sleep(GenerateRandomNumber() +2000);
                    var codeField = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/label[1]/div[1]/div[2]/div[1]/input[1]"));
                    codeField.SendKeys(Interaction.InputBox("Authenticator code"));
                    Thread.Sleep(GenerateRandomNumber() + 2000);
                });

                RetryPolicyHelper.ExecuteWithRetry(() => {
                    Thread.Sleep(GenerateRandomNumber());
                    var nextButton2 = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/span[1]/span[1]"));
                    nextButton2.Click();
                });

            }

        }

        public void BlockUser(string user)
        {


            //RetryPolicyHelper.ExecuteWithRetry(() => { });

            RetryPolicyHelper.ExecuteWithRetry(() => {
                Thread.Sleep(GenerateRandomNumber());
                var searchBox = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/div[1]/label[1]/div[2]/div[1]/input[1]"));
                searchBox.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                searchBox.SendKeys(OpenQA.Selenium.Keys.Delete);
                searchBox.SendKeys(user);
            });

            ///html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/div[2]/div[1]/div[4]/div[1]/div[1]/span[1]
            try
            {
                RetryPolicyHelper.ExecuteWithRetry(() => {
                    Thread.Sleep(GenerateRandomNumber() + 1000);
                    var firstResult = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/div[2]/div[1]/div[4]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/span[1]"));
                    firstResult.Click();
                });
            }
            catch (Exception)
            {
                return;
            }
            

            IReadOnlyList<IWebElement> elementsContainingText = null;

            try
            {
                RetryPolicyHelper.ExecuteWithRetry(() =>
                {
                    Thread.Sleep(GenerateRandomNumber()+1000);
                    elementsContainingText = bot.FindElements(By.XPath($"//*[contains(text(), '{"está bloqueado"}')]"));

                });

            }
            catch (NoSuchElementException)
            {

            }

            if (elementsContainingText.Count > 0 && elementsContainingText.FirstOrDefault().Displayed)
            {
                return;
            }
            ///html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/*[name()='svg'][1]
            ///html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/*[name()='svg'][1]
            ///html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]
            ///html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/*[name()='svg'][1]/*[name()='g'][1]/*[name()='path'][1]

            try
            {
                RetryPolicyHelper.ExecuteWithRetry(() => {
                    Thread.Sleep(GenerateRandomNumber());
                    var threeDots = bot.FindElement(By.XPath("html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/*[name()='svg'][1]"));
                    threeDots.Click();
                });
            }
            catch (Exception ex)
            {
                try
                {
                    RetryPolicyHelper.ExecuteWithRetry(() => {
                        Thread.Sleep(GenerateRandomNumber());
                        IWebElement threeDots = null;
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
                    return;
                    
                }
                
            }

            ///html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/span[1]
            try
            {
                RetryPolicyHelper.ExecuteWithRetry(() => {
                    Thread.Sleep(GenerateRandomNumber());
                    var blockButton = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[3]/div[1]/div[1]/div[1]/div[4]/div[2]/div[1]/span[1]"));
                    blockButton.Click();
                });
            }
            catch (Exception)
            {
                RetryPolicyHelper.ExecuteWithRetry(() => {
                    Thread.Sleep(GenerateRandomNumber());
                    var blockButton = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/span[1]"));
                    blockButton.Click();
                });
            }
            

            RetryPolicyHelper.ExecuteWithRetry(() => {
                Thread.Sleep(GenerateRandomNumber());
                var confirmBlockButton = bot.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/span[1]/span[1]"));
                confirmBlockButton.Click();
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
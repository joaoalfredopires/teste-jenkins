using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gboex_automationtest_portalintegracao.Support
{
    internal class Utils
    {
        public Utils() { }

        public static string BaseUrl()
        {
            string baseUrl = "https://srvhapl01.gboex.com.br:8101/";
            return baseUrl;
        }

        public void EsperaTituloAparecerEmTela(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("h2")));
        }
        public void EsperaElementoAparecerEmTela(IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        public string User(string tipo)
        {
            string user = "";
            switch (tipo)
            {
                case "valido":
                    user = "carlinhos";
                    break;

                case "invalido":
                    user = "invalido";
                    break;
                default:
                    break;
            }
            return user;
        }
        public string Senha(string tipo)
        {
            string senha = "";
            switch (tipo)
            {
                case "valida":
                    senha = "PaT3t@2023";
                    break;

                case "invalida":
                    senha = "0000000000";
                    break;
                default:
                    break;
            }
            return senha;
        }
    }
}

using gboex_automationtest_portalintegracao.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gboex_automationtest_portalintegracao.Pages
{
    internal class LoginPage
    {
        private IWebDriver driver;
        Utils utils = new Utils();

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Elementos:----------------------------------------------------------
        private IWebElement InputTextUsuario()
        {
            return driver.FindElement(By.Id("username"));
        }
        private IWebElement InputTextSenha()
        {
            return driver.FindElement(By.Id("password"));
        }
        private IWebElement BotaoSubmit()
        {
            return driver.FindElement(By.CssSelector("button[type='submit']"));
        }
        private IWebElement ToastFalhaLogin()
        {
            return driver.FindElement(By.CssSelector("div[role='alert']"));
        }

        //Ações:--------------------------------------------------------------
        public void AcessarPortalIntegracao(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void PreencherDadosLogin(string user, string senha)
        {
            utils.EsperaElementoAparecerEmTela(driver, By.TagName("h3"));

            InputTextUsuario().SendKeys(user);
            InputTextSenha().SendKeys(senha);
        }

        public void ClicarBotaoSubmit()
        {
            BotaoSubmit().Click();
        }

        //Asserts:------------------------------------------------------------
        public void AssertToastFalhaLogin()
        {
            utils.EsperaElementoAparecerEmTela(driver, By.CssSelector("div[role='alert']"));

            Assert.That(ToastFalhaLogin().Text.Contains("Username or Password is not correct"));
        }
    }
}

using gboex_automationtest_portalintegracao.Support;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gboex_automationtest_portalintegracao.Pages
{
    internal class HomePage
    {
        private IWebDriver driver;
        private Utils utils = new Utils();

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Elementos:----------------------------------------------------------
        
        private IWebElement CardLeadHomePage()
        {
            return driver.FindElement(By.CssSelector("div[class='lead'] > p > b"));
        }

        //Ações:--------------------------------------------------------------

        //Asserts:------------------------------------------------------------
        public void AssertLoginSucesso()
        {
            utils.EsperaTituloAparecerEmTela(driver);

            Assert.That(CardLeadHomePage().Text.ToLower().Contains("carlinhos"));
        }
    }
}

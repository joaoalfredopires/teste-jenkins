using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Allure.Net.Commons;

namespace gboex_automationtest_portalintegracao.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        //Cria container para armazenar o driver a ser utilizado nos steps        
        private readonly IObjectContainer _container;
        private IWebDriver driver;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-application-cache");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();

            _container.RegisterInstanceAs<IWebDriver>(driver);
        }


        [AfterScenario]
        public void AfterScenario(IWebDriver driver)
        {
            driver = _container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
            }
        }

        [AfterStep()]
        public void TakeScreenshotAfterStep(IWebDriver driver, ScenarioContext context)
        {
            if (context.TestError != null)
            {
                byte[] conteudo = CapturaDeTela(driver);

                AllureApi.AddAttachment("Falha - Screenshot.png", "application/png", conteudo, "png");
            }
        }

        public static byte[] CapturaDeTela(IWebDriver driver)
        {
            return ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
        }
    }
}
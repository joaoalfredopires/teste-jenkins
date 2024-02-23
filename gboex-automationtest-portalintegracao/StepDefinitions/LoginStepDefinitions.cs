using gboex_automationtest_portalintegracao.Pages;
using gboex_automationtest_portalintegracao.Support;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace gboex_automationtest_portalintegracao.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        //Inicia variáveis utilizadas nos testes
        Utils utils = new Utils();
        string baseUrl = Utils.BaseUrl();
        public IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;

        public LoginStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Login SUCESSO
        [Given(@"que estou na página de login do Portal de integração")]
        public void GivenQueEstouNaPaginaDeLoginDoPortalDeIntegracao()
        {
            loginPage = new LoginPage(driver);

            loginPage.AcessarPortalIntegracao(baseUrl);
        }

        [When(@"insiro usuário e senha VÁLIDOS")]
        public void WhenInsiroUsuarioESenhaVALIDOS()
        {
            loginPage.PreencherDadosLogin(utils.User("valido"), utils.Senha("valida"));

            loginPage.ClicarBotaoSubmit();
        }

        [Then(@"o login deve ocorrer com sucesso, direcionando para página inicial")]
        public void ThenOLoginDeveOcorrerComSucessoDirecionandoParaPaginaInicial()
        {
            homePage = new HomePage(driver);

            homePage.AssertLoginSucesso();
        }

        //Login FALHA
        [When(@"insiro usuário ou senha INVÁLIDOS")]
        public void WhenInsiroUsuarioOuSenhaINVALIDOS()
        {
            loginPage.PreencherDadosLogin(utils.User("valido"), utils.Senha("invalida"));

            loginPage.ClicarBotaoSubmit();
        }

        [Then(@"o login deve falhar, exibindo um Toast que informa o erro deve ser exibida em tela")]
        public void ThenOLoginDeveFalharExibindoUmToastQueInformaOErroDeveSerExibidaEmTela()
        {
            loginPage.AssertToastFalhaLogin();
        }
    }
}

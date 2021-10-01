using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using Xunit;

namespace TesteSelenium
{
    public class TesteAutomatizado
    {
        private IWebDriver _driver;
        public TesteAutomatizado()
        {
            ChromeOptions options = new ChromeOptions();
            _driver = new ChromeDriver("C:\\Selenium\\ChromeDriver\\", options);
        }

        [Fact]
        public void Buscar_Site_VerificarSeCorreto()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _driver.Navigate().GoToUrl("https://www.google.com.br/");

            IWebElement campo_pesquisa = _driver.FindElement(By.Name("q"));
            campo_pesquisa.SendKeys("magazine luiza");

            Thread.Sleep(3000);

            IWebElement pesquisa = _driver.FindElement(By.Name("btnI"));
            pesquisa.Click();

            Thread.Sleep(3000);

            Assert.Equal("https://www.magazineluiza.com.br/", _driver.Url);
        }
    }
}

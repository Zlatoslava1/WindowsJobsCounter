using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JobCounter.pages;
using Xunit;
namespace JobsCounter.Tests
{
    public class UnitTest1
    {
        static IWebDriver driverGC;
        
        [Theory]
        [InlineData("ROMANIA","English", 6)]
        [InlineData("ROMANIA","Hungarian", 2)]

//This test checks numbers of jobs for specified country and language
        public void JobsCountTest(string country, string language, int expectedResult)
        {
            driverGC = new ChromeDriver();
            String siteUrl = "https://careers.veeam.com";
            int actualResult = 0;
            driverGC.Navigate().GoToUrl(siteUrl);
            driverGC.Manage().Window.Maximize();
            CareerPage careerPage = new CareerPage(driverGC);
            careerPage.FindByXpathAndClick("//a [contains (text(),'GLOBAL')]");
            careerPage.FindByXpathAndClick($"//a [contains(text(),'{country}')]");
            careerPage.FindByXpathAndClick("//select [@name='language']");
            careerPage.FindByXpathAndClick($"//option [contains(text(),'{language}')]");
            careerPage.FindByXpathAndOpenNewPage("//a[(@name='SubmitForm')]");
            actualResult = careerPage.FindByXpathAndCountElements("//div[contains(@class,'vacancies-blocks-item-description-more mt10-md-up')]");
            Assert.Equal(expectedResult, actualResult);
            driverGC.Quit();
        }
    }
}

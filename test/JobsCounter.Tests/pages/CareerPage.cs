using OpenQA.Selenium;
using System.Linq;

namespace JobCounter.pages
{
   public class CareerPage
    {
        private IWebDriver driverGC;
        public CareerPage(IWebDriver driverGC)
        {
            this.driverGC = driverGC;
        }

        protected IWebDriver GetDriverGC()
        {
            return driverGC;
        }

        public void FindByXpathAndClick(string xpath)
        {
            GetDriverGC().FindElement(By.XPath(xpath)).Click();
        }

        public CareerPage FindByXpathAndOpenNewPage(string xpath)
        {
            GetDriverGC().FindElement(By.XPath(xpath)).Click();
            GetDriverGC().SwitchTo().Window(GetDriverGC().WindowHandles.Last());
            return new CareerPage(GetDriverGC());
        }

        public int FindByXpathAndCountElements(string xpath)
        {
            int count = 0;
            count = GetDriverGC().FindElements(By.XPath(xpath)).Count;
            return count;
        }

    }
}

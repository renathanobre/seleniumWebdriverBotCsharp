using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webdriver_Example
{
    class Program
    {
        static void Main(string[] args)
        {
           
            IWebDriver driver = new ChromeDriver();
            String newemail = DateTime.Now.ToString("yyyyMMddHHmmss") + "@resumeteste.com";

            String currentDirectory = System.IO.Directory.GetCurrentDirectory();

            driver.Url = "https://www.resume.com/builder#Step1";

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.LinkText("Details")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.FindElement(By.Id("skipConnections")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(16);
            Console.WriteLine("------Start to fill Personal Information------");
            driver.FindElement(By.Id("first_name")).SendKeys("Joana Hellena");
            driver.FindElement(By.Id("last_name")).SendKeys("Dark Smith");
            driver.FindElement(By.Id("submitCreateNewAccount1")).Click();
            Console.WriteLine("------Finish to fill Personal Information------");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(18);
            Console.WriteLine("------Start to fill Email------"); 
            driver.FindElement(By.Id("email")).SendKeys(newemail);
            driver.FindElement(By.Id("submitCreateNewAccount2")).Click();
            Console.WriteLine("------your email: " + newemail);
            Console.WriteLine("------Finish to fill Email------");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(22);
            Console.WriteLine("------Start to fill Job Category------");
            driver.FindElement(By.Id("job_category")).SendKeys(" Accounting & Finance");
            driver.FindElement(By.Id("submitCreateNewAccount")).Click();
            Console.WriteLine("------Finish to fill Job Category------");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(45);
            Console.WriteLine("------Start to fill Upload Resume------");
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div/div[4]/button")).Click();
            Console.WriteLine("------Finish to fill Upload Resume------");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            Console.WriteLine("------Start to fill Set File------");
            driver.FindElement(By.Id("resumeParse2")).Clear();
            driver.FindElement(By.Id("resumeParse2")).SendKeys(currentDirectory + "\\resume\\sampleresume.doc");
            driver.FindElement(By.Id("uploadResumeBtn")).Click();
            Console.WriteLine("------Finish to fill Set File------");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Console.WriteLine("------Start to Publish------");
            driver.FindElement(By.XPath("//*[@id='uploadResumeBtn']/span")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            Console.WriteLine("------Published------");

         
            Console.WriteLine("------Start to Change Password------");
            driver.Url = "https://www.resume.com/passupdate";
            driver.FindElement(By.Id("forgotPassword")).SendKeys("123456");
            driver.FindElement(By.Id("confirmPassword")).SendKeys("123456");
            driver.FindElement(By.Id("resetPasswordBtn")).Click();
            Console.WriteLine("------Finish to Change Password------");


            Console.WriteLine("success -- Profile created with succeed-- ");
           // driver.Close();



        }
    }
}

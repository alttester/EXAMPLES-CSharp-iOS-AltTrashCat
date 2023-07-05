using alttrashcat_tests_csharp.pages;
using alttrashcat_tests_csharp.tests;
using System;
using System.IO;
using System.Threading;
using Altom.AltDriver;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;

namespace alttrashcat_tests_csharp.tests
{
    public class BaseTest
    {
        AltDriver altDriver;

        private AppiumDriver<IOSElement> _driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var  driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, Environment.GetEnvironmentVariable("APPIUM_PLATFORM"));
            driverOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, Environment.GetEnvironmentVariable("APPIUM_DEVICE"));
            driverOptions.AddAdditionalCapability(MobileCapabilityType.App, Environment.GetEnvironmentVariable("APPIUM_APPFILE"));
            driverOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, Environment.GetEnvironmentVariable("APPIUM_AUTOMATION"));
            driverOptions.AddAdditionalCapability("xcodeOrgId", Environment.GetEnvironmentVariable("APPIUM_XCODEORGID"));
            driverOptions.AddAdditionalCapability("xcodeSigningId", Environment.GetEnvironmentVariable("APPIUM_XCODESIGNID"));

            Uri url = new Uri(Environment.GetEnvironmentVariable("APPIUM_URL"));
            _driver = new IOSDriver<IOSElement>(url, driverOptions);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Thread.Sleep(30000);
            Console.WriteLine("Appium driver started");
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            Console.WriteLine("Ending");
            _driver.Quit();
        }

    }
}
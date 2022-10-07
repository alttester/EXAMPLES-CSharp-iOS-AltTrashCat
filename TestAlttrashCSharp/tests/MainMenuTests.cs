using alttrashcat_tests_csharp.pages;
using System;
using System.Threading;
using Altom.AltUnityDriver;
using NUnit.Framework;
namespace alttrashcat_tests_csharp.tests
{
    public class MainMenuTests: BaseTest
    {
        AltUnityDriver altUnityDriver;
        MainMenuPage mainMenuPage;

        [SetUp]
        public void Setup()
        {
            altUnityDriver = new AltUnityDriver(port: 13000);
            mainMenuPage = new MainMenuPage(altUnityDriver);
            mainMenuPage.LoadScene();
        }
        
        [TearDown]
        public void Dispose()
        {
            altUnityDriver.Stop();
            Thread.Sleep(1000);
        }

        [Test]
        public void TestMainMenuPageLoadedCorrectly(){
            Assert.True(mainMenuPage.IsDisplayed());
        }
    }
}
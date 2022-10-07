using alttrashcat_tests_csharp.pages;
using System;
using System.Threading;
using Altom.AltUnityDriver;
using NUnit.Framework;

namespace alttrashcat_tests_csharp.tests
{
    public class StartPageTests: BaseTest
    {
        private AltUnityDriver altUnityDriver;
        private MainMenuPage mainMenuPage;
        private StartPage startPage;


       [SetUp]
       public void Setup()
       {
            altUnityDriver=new AltUnityDriver();
            startPage=new StartPage(altUnityDriver);
            startPage.Load();
            mainMenuPage=new MainMenuPage(altUnityDriver);

        }
        [Test]
        public void TestStartPageLoadedCorrectly(){
            Assert.True(startPage.IsDisplayed());
        }
        [Test]
        public void TestStartButtonLoadMainMenu(){
            startPage.PressStart();
            Assert.True(mainMenuPage.IsDisplayed());
        }

        [TearDown]
        public void Dispose()
        {
            altUnityDriver.Stop();
            Thread.Sleep(1000);
        }
    }
}
namespace alttrashcat_tests_csharp.pages
{
    public class StartPage:BasePage
    {
        public StartPage(AltUnityDriver driver) : base(driver)
        {
        }
    
        public void Load(){
            Driver.LoadScene("Start");
        }
        public AltUnityObject StartButton { get => Driver.WaitForElement("StartButton",timeout:2); }
        public AltUnityObject StartText{get => Driver.WaitForElement("StartText",timeout:2);}
        public AltUnityObject LogoImage{get => Driver.WaitForElement("LogoImage",timeout:2);}
        public AltUnityObject UnityUrlButton{get => Driver.WaitForElement("UnityURLButton",timeout:2);}
        public bool IsDisplayed(){
            if(StartButton!=null && StartText!=null && LogoImage!=null && UnityUrlButton!=null)
                return true;
            return false;
        }
        public void PressStart(){
            StartButton.Tap();
        }
        public string GetStartButtonText(){
            return StartButton.GetText();
        }
    }
}
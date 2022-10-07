namespace alttrashcat_tests_csharp.pages
{
    public class MainMenuPage : BasePage
    {
        public MainMenuPage(AltUnityDriver driver) : base(driver)
        {
        }
        public void LoadScene(){
            Driver.LoadScene("Main");
        }

        public AltUnityObject StoreButton { get => Driver.WaitForElement("UICamera/Loadout/StoreButton",timeout:10); }
        public AltUnityObject LeaderBoardButton{get => Driver.WaitForElement("UICamera/Loadout/OpenLeaderboard",timeout:10);}
        public AltUnityObject SettingsButton{get => Driver.WaitForElement("UICamera/Loadout/SettingButton",timeout:10);}
        public AltUnityObject MissionButton{get => Driver.WaitForElement("UICamera/Loadout/MissionButton",timeout:10);}
        public AltUnityObject RunButton{get => Driver.WaitForElement("UICamera/Loadout/StartButton",timeout:10);}
        public AltUnityObject CharacterName{get=> Driver.WaitForElement("CharName",timeout:10);}
        public AltUnityObject ThemeName{get=> Driver.WaitForElement("UICamera/Loadout/ThemeZone",timeout:10);}
        public bool IsDisplayed(){
            if(StoreButton!=null && LeaderBoardButton!=null && SettingsButton!=null && MissionButton!=null && RunButton!=null && CharacterName!=null && ThemeName!=null)
                return true;
            return false;
        }
        public void PressRun(){
            RunButton.Tap();
        }

    }
}
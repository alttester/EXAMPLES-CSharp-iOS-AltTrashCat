using AltTester.AltDriver;
namespace alttrashcat_tests_csharp.pages
{
    public class StartPage:BasePage
    {
        public StartPage(AltDriver driver) : base(driver)
        {
        }
        public void Load()
        {
            Driver.LoadScene("Start");
        }
        public AltObject StartButton { get => Driver.WaitForObject(By.NAME, "StartButton", timeout: 2); }
        public AltObject StartText { get => Driver.WaitForObject(By.NAME, "StartText", timeout: 2); }
        public AltObject LogoImage { get => Driver.WaitForObject(By.NAME, "LogoImage", timeout: 2); }
        public AltObject UnityUrlButton { get => Driver.WaitForObject(By.NAME, "UnityURLButton", timeout: 2); }
        public bool IsDisplayed()
        {
            if (StartButton != null && StartText != null && LogoImage != null && UnityUrlButton != null)
                return true;
            return false;
        }
        public void PressStart()
        {
            StartButton.Tap();
        }
        public string GetStartButtonText()
        {
            return StartButton.GetText();
        }
    }
}
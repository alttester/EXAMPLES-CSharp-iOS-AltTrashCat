using Altom.AltUnityDriver;
using System;
using System.Linq;

namespace alttrashcat_tests_csharp.pages
{
    public class GamePlay : BasePage
    {
        public GamePlay(AltUnityDriver driver) : base(driver)
        {
        }

        public AltUnityObject PauseButton { get => Driver.WaitForObject(By.NAME, "Game/WholeUI/pauseButton", timeout: 2); }
        public AltUnityObject Character { get => Driver.WaitForObject(By.NAME, "PlayerPivot"); }

        public bool IsDisplayed(){
            if(PauseButton!=null && Character!=null){
                return true;
            }
            return false;
        }
        public void PressPause(){
            PauseButton.Tap();
        }
        public int GetCurrentLife(){
            return Character.CallComponentMethod<int>("CharacterInputController", "get_currentLife", new object[] { });
        }
        public void AvoidObstacles(int numberOfObstacles)
        {
            var character = Character;
            bool movedLeft = false;
            bool movedRight = false;
            for (int i = 0; i < numberOfObstacles; i++)
            {
                var allObstacles = Driver.FindObjectsWhichContain(By.NAME, "Obstacle");
                allObstacles.Sort((x, y) => x.worldZ.CompareTo(y.worldZ));
                allObstacles.RemoveAll(obs => obs.worldZ < character.worldZ);
                var obstacle = allObstacles[0];

                System.Console.WriteLine("Obstacle: " + obstacle.name + ", z:" + obstacle.worldZ + ", x:" + obstacle.worldX);
                System.Console.WriteLine("Next: " + allObstacles[1].name + ", z:" + allObstacles[1].worldZ + ", x:" + allObstacles[1].worldX);

                while (obstacle.worldZ - character.worldZ > 5)
                {
                    obstacle = Driver.FindObject(By.ID, obstacle.id.ToString());
                    character = Driver.FindObject(By.NAME, "PlayerPivot");
                }
                if (obstacle.name.Contains("ObstacleHighBarrier"))
                {
                    Driver.Swipe(new AltUnityVector2(character.x, character.y), new AltUnityVector2(character.x, character.y - 50));
                }
                else
                if (obstacle.name.Contains("ObstacleLowBarrier") || obstacle.name.Contains("Rat"))
                {
                    Driver.Swipe(new AltUnityVector2(character.x, character.y), new AltUnityVector2(character.x, character.y + 50));
                }
                else
                {
                    if (obstacle.worldZ == allObstacles[1].worldZ)
                    {
                        if (obstacle.worldX == character.worldX)
                        {
                            if (allObstacles[1].worldX == -1.5f)
                            {
                                Driver.Swipe(new AltUnityVector2(character.x, character.y), new AltUnityVector2(character.x + 50, character.y));
                                movedRight = true;
                            }
                            else
                            {
                                Driver.Swipe(new AltUnityVector2(character.x, character.y), new AltUnityVector2(character.x - 50, character.y));
                                movedLeft = true;
                            }
                        }
                        else
                        {
                            if (allObstacles[1].worldX == character.worldX)
                            {
                                if (obstacle.worldX == -1.5f)
                                {   
                                    Driver.Swipe(new AltUnityVector2(character.x, character.y), new AltUnityVector2(character.x + 50, character.y));
                                    movedRight = true;
                                }
                                else
                                {
                                    Driver.Swipe(new AltUnityVector2(character.x, character.y), new AltUnityVector2(character.x - 50, character.y));
                                    movedLeft = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (obstacle.worldX == character.worldX)
                        {
                            Driver.Swipe(new AltUnityVector2(character.x, character.y), new AltUnityVector2(character.x + 50, character.y));
                            movedRight = true;
                        }
                    }
                }
                while (character.worldZ - 3 < obstacle.worldZ && character.worldX < 99)
                {
                    obstacle = Driver.FindObject(By.ID, obstacle.id.ToString());
                    character = Driver.FindObject(By.NAME, "PlayerPivot");
                }
                if (movedRight)
                {
                    Driver.Swipe(new AltUnityVector2(character.x, character.y), new AltUnityVector2(character.x - 50, character.y));
                    movedRight = false;
                }
                if (movedLeft)
                {
                    Driver.Swipe(new AltUnityVector2(character.x, character.y), new AltUnityVector2(character.x + 50, character.y));
                    movedRight = false;
                }
            }
        }
    }
}
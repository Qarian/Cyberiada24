using UnityEngine;

namespace Presentation
{
    [CreateAssetMenu(menuName = "Cyberiada/GameplayRuntime")]
    public class GameplayRuntime : ScriptableObject
    {
        public int points;
        public int points2;
        public int points3;
        public int points4;
        public int points5;
        public int points6;

        public void Quit()
        {
            Application.Quit();
        }
        
    }
}
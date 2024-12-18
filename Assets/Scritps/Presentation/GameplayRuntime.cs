using UnityEngine;

namespace Presentation
{
    [CreateAssetMenu(menuName = "Cyberiada/GameplayRuntime")]
    public class GameplayRuntime : ScriptableObject
    {
        public int points;

        public void Quit()
        {
            Application.Quit();
        }
        
    }
}
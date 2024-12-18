using UnityEngine;

namespace Presentation
{
    [CreateAssetMenu(menuName = "Cyberiada/AgentData")]
    public class AgentData : ScriptableObject
    {
        public float speed;
        public int health;
    }
}
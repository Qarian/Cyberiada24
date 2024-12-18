using UnityEngine;
using UnityEngine.AI;

namespace Presentation
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private AgentData data;
        [SerializeField] private int  count;
        
        [SerializeField] private NavControler t;

        private void Start()
        {
            var level = PlayerPrefs.GetInt(Consts.USER_MAX_LEVEL);
            InvokeRepeating(nameof(Spawn), 0f, 5f);
            PlayerPrefs.SetInt(Consts.USER_MAX_LEVEL, 5);

            PlayerPrefs.Save();
        }

        public void Spawn()
        {
            var go = Instantiate(t, transform.position, Quaternion.identity, transform);
            go.Init(data);
        }
    }
}
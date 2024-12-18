using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Presentation
{
    public class NavControler : MonoBehaviour, IPicker, IUnit
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private MainMenu menu;
        
        [SerializeField]
        private InputAction input;

        private Coroutine pickupCoroutine;

        private float speed;

        private float pickupTime;

        public void Init(AgentData data)
        {
            speed = data.speed;
            input.performed += InputOnperformed;
        }

        private void InputOnperformed(InputAction.CallbackContext obj)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.destination = hit.point;
            }
        }

        private void Update()
        {
            agent.speed = speed;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                InputOnperformed(new InputAction.CallbackContext());
                StopCoroutine(pickupCoroutine);
            }
        }

        public void Pick()
        {
            pickupCoroutine = StartCoroutine(Pickup());
            speed *= 5;
            menu?.Run(this);
            Invoke(nameof(Test), 5f);
            Destroy(gameObject);
        }

        private void Test()
        {
            speed /= 5f;
        }

        public IEnumerator Pickup()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(5);
                speed /= 5f;
            }
        }

        public void CustomUpdate(float deltaTime)
        {
            // AI Logic
        }
    }
}
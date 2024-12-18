using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Presentation
{
    public class NavControler : MonoBehaviour, IPicker
    {
        [SerializeField] private AgentData data;
        
        [SerializeField] private NavMeshAgent agent;

        [SerializeField]
        private InputAction input;

        private float speed;

        private void Start()
        {
            input.performed += InputOnperformed;
            speed = data.speed;
            
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
            }
        }

        public void Pick()
        {
            speed *= 5f;
        }
    }
}
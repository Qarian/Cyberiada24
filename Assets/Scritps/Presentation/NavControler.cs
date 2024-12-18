using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Presentation
{
    public class NavControler : MonoBehaviour
    {
        [SerializeField] private AgentData data;
        
        [SerializeField] private NavMeshAgent agent;

        [SerializeField]
        private InputAction input;

        public float Speed
        {
            get => speed;
            set => speed = value;
        }

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
    }
}
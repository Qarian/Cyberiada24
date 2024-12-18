using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Presentation
{
    public class PlayerPhysics : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;

        private new Rigidbody rigidbody;
        [SerializeField]
        private InputAction input;
        [SerializeField]
        private InputAction jumpInput;

        private Vector2 inputMovement;
        
        public UnityEvent onJump;
        
        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            input.Enable();
            jumpInput.performed += InputOnperformed;
            jumpInput.Enable();
        }

        private void InputOnperformed(InputAction.CallbackContext obj)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onJump.Invoke();
        }

        private void Update()
        {
            // float axis = Input.GetAxis("Horizontal");
            // float axisRaw = Input.GetAxisRaw("Horizontal");
            // bool buttonPressed = Input.GetKey(KeyCode.D);
            inputMovement = input.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            Vector3 movement = GetDirection() * (speed * Time.fixedDeltaTime);
            rigidbody.MovePosition(transform.position + movement);
        }

        private Vector3 GetDirection()
        {
            var cameraTransform = Camera.main.transform;

            Vector3 forward = cameraTransform.forward;
            forward.y = 0;
            forward.Normalize();
            
            Vector3 right = cameraTransform.right;
            right.y = 0;
            right.Normalize();
            
            return forward * inputMovement.y + right * inputMovement.x;
        }
    }
}
using System;
using UnityEngine;
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
        }

        private void Update()
        {
            // float axis = Input.GetAxis("Horizontal");
            // float axisRaw = Input.GetAxisRaw("Horizontal");
            // bool buttonPressed = Input.GetKey(KeyCode.D);
            inputMovement = input.ReadValue<Vector2>();
            Debug.Log(inputMovement);
        }

        private void FixedUpdate()
        {
            Vector3 movement = new Vector3(inputMovement.x, 0, inputMovement.y) * (speed * Time.fixedDeltaTime);
            rigidbody.MovePosition(transform.position + movement);
        }
    }
}
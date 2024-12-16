using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Presentation
{
    public class PlayerPhysics : MonoBehaviour
    {
        [SerializeField] private float speed;

        private new Rigidbody rigidbody;
        [SerializeField]
        private InputAction input;

        private Vector2 inputMovement;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            input.Enable();
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
using System;
using UnityEngine;

namespace Presentation
{
    public class PlayerPhysics : MonoBehaviour
    {
        [SerializeField] private float speed;

        private new Rigidbody rigidbody;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Vector3 movement = Vector3.right * (speed * Time.fixedDeltaTime);
            rigidbody.MovePosition(transform.position + movement);
        }
    }
}
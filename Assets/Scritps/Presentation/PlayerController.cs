using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Presentation
{
    public class PlayerController : MonoBehaviour, IDamagable
    {
        [SerializeField] private float speed;


        private void Update()
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            Vector3 rot = transform.rotation.eulerAngles;
            Quaternion newRot = Quaternion.Euler(rot);
        }

        public float Health { get; private set; }
        public void Damage(float damage)
        {
            Health -= damage;
        }
    }
}

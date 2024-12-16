using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Presentation
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Update()
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}

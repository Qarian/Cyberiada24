using System;
using UnityEngine;

namespace Presentation
{
    public class Pickup : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            //var component = GetComponent<PlayerPhysics>();
            if (other.TryGetComponent<PlayerPhysics>(out var player))
            {
                player.points++;
                Destroy(this.gameObject);
            }
            
        }

        private void OnCollisionEnter(Collision other)
        {
            
        }
    }
}
using System;
using UnityEngine;

namespace Presentation
{
    public class Pickup : MonoBehaviour
    {
        //private static readonly int Pick = Animator.StringToHash("Pick");
        [SerializeField] private Animator animator;
        [SerializeField] private AudioSource audio;
        
        private void Start()
        {
            // if (animator == null)
            //     animator = GetComponentInChildren<Animator>();
            animator ??= GetComponentInChildren<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            //var component = GetComponent<PlayerPhysics>();
            if (other.TryGetComponent<PlayerPhysics>(out var player))
            {
                player.points++;
                //animator.Play("Pick");
                animator.SetTrigger("Pick");
                //Destroy(this.gameObject);
                audio.Play();
                Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            
        }
    }
}
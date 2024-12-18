using System;
using UnityEngine;

namespace Presentation
{
    public class Pickup : MonoBehaviour
    {
        //private static readonly int Pick = Animator.StringToHash("Pick");
        [SerializeField] private Animator animator;
        [SerializeField] private AudioSource audio;
        [SerializeField] private ParticleSystem particle;

        [SerializeField] private GameplayRuntime runtime;
        
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
                runtime.points++;
                //animator.Play("Pick");
                animator.SetTrigger("Pick");
                //Destroy(this.gameObject);
                audio.Play();
                particle.Play();
                Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
            }

            if (other.TryGetComponent<NavControler>(out var controller))
            {
                controller.Speed *= 5f;
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            
        }
    }
}
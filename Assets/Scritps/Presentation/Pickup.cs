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
        
        private void Start()
        {
            // if (animator == null)
            //     animator = GetComponentInChildren<Animator>();
            animator ??= GetComponentInChildren<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IPicker>(out var picker))
            {
                picker.Pick();
                //animator.Play("Pick");
                animator.SetTrigger("Pick");
                //Destroy(this.gameObject);
                audio.Play();
                particle.Play();
                Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            
        }
    }
}
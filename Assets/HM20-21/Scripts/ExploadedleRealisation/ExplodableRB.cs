using System;
using UnityEngine;

namespace HM20_21.Scripts
{
    public class ExplodableRB : MonoBehaviour, IExplodable
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Explode(Vector3 explosionForce, float force)
        {
            if (_rigidbody != null)
            {
                _rigidbody.isKinematic = false;
                _rigidbody.AddForce(explosionForce * force, ForceMode.Impulse);
            }
        }
    }
}
using System;
using UnityEngine;

namespace HM20_21.Scripts
{
    public class GrabSimpleRB : MonoBehaviour, IGrabbable
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        public void OnGrab()
        {
            if (_rigidbody != null)
            {
                _rigidbody.useGravity = false;
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.angularVelocity = Vector3.zero;
                _rigidbody.isKinematic = true;
            }
        }

        public void OnRelease()
        {
            if (_rigidbody != null)
            {
                _rigidbody.useGravity = true;
                _rigidbody.isKinematic = false;
            }
        }

        public void Drag(Vector3 targetPosition)
        {
        }
    }
}
using System;
using UnityEngine;

namespace HM20_21.Scripts
{
    public class GrabSimpleRB : MonoBehaviour, IGrabbable
    {
        [SerializeField] private float _dragSpeed = 15f;
        
        private Rigidbody _rigidbody;
        private bool _isGrabbed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        public void OnGrab()
        {
            if (_rigidbody != null)
            {
                _isGrabbed = true;
                
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
                _isGrabbed = false;
                
                _rigidbody.useGravity = true;
                _rigidbody.isKinematic = false;
            }
        }

        public void Drag(Vector3 targetPosition)
        {
            if (_isGrabbed)
            {
                _rigidbody.MovePosition(Vector3.Lerp(_rigidbody.position, targetPosition, Time.deltaTime * _dragSpeed));
            }
        }
    }
}
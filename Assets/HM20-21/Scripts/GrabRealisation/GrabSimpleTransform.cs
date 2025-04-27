using System;
using UnityEngine;

namespace HM20_21.Scripts
{
    public class GrabSimpleTransform : MonoBehaviour, IGrabbable
    {
        private Transform _transform;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }
        
        public void OnGrab()
        {
        }

        public void OnRelease()
        {
        }

        public void Drag(Vector3 targetPosition)
        {
            _transform.position = Vector3.Lerp(_transform.position, targetPosition, Time.deltaTime * 10f);
        }
    }
}
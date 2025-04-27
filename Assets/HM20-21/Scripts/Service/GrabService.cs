using UnityEngine;

namespace HM20_21.Scripts
{
    public class GrabService
    {
        private LayerMask _grabbableMask;

        public GrabService(LayerMask grabbableMask)
        {
            _grabbableMask = grabbableMask;
        }

        public IGrabbable TryGrab(Ray ray, out Rigidbody grabbedRigidbody)
        {
            grabbedRigidbody = null;

            if (Physics.Raycast(ray, out RaycastHit hit) &&
                (_grabbableMask.value & (1 << hit.collider.gameObject.layer)) != 0)
            {
                IGrabbable grabbable = hit.collider.GetComponent<IGrabbable>();
                if (grabbable != null)
                {
                    grabbedRigidbody = hit.rigidbody;
                    grabbable.OnGrab();
                    return grabbable;
                }

                Debug.Log(hit.collider.gameObject.name);
            }

            return null;
        }
    }
}
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

        public IGrabbable TryGrab(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _grabbableMask))
            {
                IGrabbable grabbable = hit.collider.GetComponent<IGrabbable>();
                if (grabbable != null)
                {
                    grabbable.OnGrab();
                    return grabbable;
                }

                Debug.Log(hit.collider.gameObject.name);
            }

            return null;
        }
    }
}
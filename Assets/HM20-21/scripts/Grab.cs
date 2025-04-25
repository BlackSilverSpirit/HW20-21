using UnityEngine;

namespace HW2021
{
    public class Grab : IObjectInteraction
    {
        public void Execute(Camera cam, ref Rigidbody selectedObject, ref Vector3 grabOffset, float _)
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit) && hit.rigidbody != null &&
                LayerMask.LayerToName(hit.collider.gameObject.layer) == "Grab")
            {
                selectedObject = hit.rigidbody;
                grabOffset = Vector3.zero;

                selectedObject.useGravity = false;
                selectedObject.velocity = Vector3.zero;
                selectedObject.angularVelocity = Vector3.zero;
                selectedObject.isKinematic = true;
            }
        }
    }
}
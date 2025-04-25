using UnityEngine;

namespace HW2021
{
    public class Drag : IObjectInteraction
    {
        private float _dragHeight = 2f;

        public void Execute(Camera cam, ref Rigidbody selectedObject, float dragSpeed)
        {
            if (selectedObject == null)
                return;

            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 surfacePoint = hit.point;

                Vector3 targetPosition = new Vector3(surfacePoint.x, hit.point.y + _dragHeight, surfacePoint.z);

                selectedObject.MovePosition(Vector3.Lerp(selectedObject.position, targetPosition,
                    Time.deltaTime * dragSpeed));
            }
        }
    }
}
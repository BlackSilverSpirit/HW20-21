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

            var dragPlane = new Plane(Vector3.up, Vector3.zero);

            if (dragPlane.Raycast(ray, out float distance))
            {
                Vector3 hitPoint = ray.GetPoint(distance);

                Vector3 targetPosition = new Vector3(hitPoint.x, _dragHeight, hitPoint.z);

                selectedObject.MovePosition(Vector3.Lerp(selectedObject.position, targetPosition,
                    Time.deltaTime * dragSpeed));
            }
        }
    }
}
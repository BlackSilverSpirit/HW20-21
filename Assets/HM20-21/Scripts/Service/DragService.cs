using UnityEngine;

namespace HM20_21.Scripts
{
    public class DragService
    {
        private float _dragHeight;

        public DragService(float dragHeight = 2f)
        {
            _dragHeight = dragHeight;
        }

        public void Drag(Ray ray, IGrabbable grabbable)
        {
            if (grabbable == null) return;

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 surfacePoint = hit.point;
                Vector3 targetPosition = new Vector3(surfacePoint.x, surfacePoint.y + _dragHeight, surfacePoint.z);
                grabbable.Drag(targetPosition);
            }
        }
    }
}
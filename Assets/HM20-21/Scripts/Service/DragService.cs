using UnityEngine;

namespace HM20_21.Scripts
{
    public class DragService
    {
        private float _dragHeight;
        private float _dragSpeed;

        public DragService(float dragHeight = 2f, float dragSpeed = 15f)
        {
            _dragHeight = dragHeight;
            _dragSpeed = dragSpeed;
        }

        public void Drag(Ray ray, Rigidbody rigidbody)
        {
            if (rigidbody == null)
                return;

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 surfacePoint = hit.point;

                Vector3 targetPosition = new Vector3(surfacePoint.x, hit.point.y + _dragHeight, surfacePoint.z);

                rigidbody.MovePosition(Vector3.Lerp(rigidbody.position, targetPosition,
                    Time.deltaTime * _dragSpeed));
            }
        }

        public void DragWithoutRigidbody(Ray ray, IGrabbable grabbable)
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
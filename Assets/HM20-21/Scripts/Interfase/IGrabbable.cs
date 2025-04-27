using UnityEngine;

namespace HM20_21.Scripts
{
    public interface IGrabbable
    {
        void OnGrab();
        void OnRelease();

        void Drag(Vector3 targetPosition);
    }
}
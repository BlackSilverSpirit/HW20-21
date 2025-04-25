using UnityEngine;

namespace HW2021
{
    public interface IObjectInteraction
    {
        void Execute(Camera cam, ref Rigidbody selectedObject, ref Vector3 grabOffset, float parameter);
    }
}
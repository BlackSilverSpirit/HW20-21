using UnityEngine;

namespace HW2021
{
    public class Release : IObjectInteraction
    {
        public void Execute(Camera cam, ref Rigidbody selectedObject, float _)
        {
            selectedObject.useGravity = true;
            selectedObject.isKinematic = false;

            selectedObject = null;
        }
    }
}
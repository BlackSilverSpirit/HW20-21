using UnityEngine;

namespace HM20_21.Scripts
{
    public interface IExplodable
    {
        void Explode(Vector3 explosionForce, float force);
    }
}
using UnityEngine;

namespace HM20_21.Scripts
{
    public class ExplodableTransform : MonoBehaviour, IExplodable
    {
        public void Explode(Vector3 explosionForce, float force)
        {
            Vector3 explosionDirection = explosionForce.normalized;
            transform.position += explosionDirection * (force * Time.deltaTime);
        }
    }
}
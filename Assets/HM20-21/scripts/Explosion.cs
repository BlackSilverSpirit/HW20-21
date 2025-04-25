using UnityEngine;

namespace HW2021
{
    public class Explosion : IObjectInteraction
    {
        private ExplosionEffect _explosionPrefab;

        public Explosion(ExplosionEffect explosionPrefab)
        {
            this._explosionPrefab = explosionPrefab;
        }

        public void Execute(Camera cam, ref Rigidbody selectedObject, ref Vector3 grabOffset, float explosionRadius)
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 explosionPoint = hit.point;

                if (_explosionPrefab != null)
                {
                    Object.Instantiate(_explosionPrefab, explosionPoint, Quaternion.identity);
                }

                var affectedObjects = Physics.OverlapSphere(explosionPoint, explosionRadius);
                foreach (Collider col in affectedObjects)
                {
                    Rigidbody rb = col.attachedRigidbody;
                    if (rb != null)
                    {
                        rb.AddExplosionForce(explosionRadius * 100f, explosionPoint, explosionRadius);
                    }
                }
            }
        }
    }
}
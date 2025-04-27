using UnityEngine;

namespace HM20_21.Scripts
{
    public class ExplosionService
    {
        private ExplosionEffect _explosionPrefab;
        private string _explodableTag;
        private float _explosionRadius;
        private float _explosionForse;

        public ExplosionService(ExplosionEffect explosionPrefab, string explodableTag, float explosionRadius = 5f,
            float explosionForse = 10f)
        {
            _explosionPrefab = explosionPrefab;
            _explodableTag = explodableTag;
            _explosionRadius = explosionRadius;
            _explosionForse = explosionForse;
        }

        public void Explode(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 explosionPoint = hit.point;

                if (_explosionPrefab != null)
                {
                    Object.Instantiate(_explosionPrefab, explosionPoint, Quaternion.identity);
                }

                Collider[] affectedObjects = Physics.OverlapSphere(explosionPoint, _explosionRadius);

                foreach (Collider col in affectedObjects)
                {
                    if (col.CompareTag(_explodableTag))
                    {
                        IExplodable explodable = col.GetComponent<IExplodable>();
                        if (explodable != null)
                        {
                            Vector3 explosionDirection = (col.transform.position - explosionPoint).normalized;
                            explodable.Explode(explosionDirection, _explosionForse);
                        }
                    }
                }
            }
        }
    }
}
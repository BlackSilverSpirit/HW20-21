using UnityEngine;

namespace HW2021
{
    public class ObjectManager : MonoBehaviour
    {
        [SerializeField] private float _dragSpeed = 15f;

        [SerializeField] private ExplosionEffect _explosionPrefab;
        [SerializeField] private float _explosionRadius = 5f;

        private Camera _camera;
        private Rigidbody _selectedObject;
        private Vector3 _grabOffset;

        private IObjectInteraction _grab;
        private IObjectInteraction _drag;
        private IObjectInteraction _release;
        private IObjectInteraction _explosion;

        private void Start()
        {
            _camera = Camera.main;

            _grab = new Grab();
            _drag = new Drag();
            _release = new Release();
            _explosion = new Explosion(_explosionPrefab);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _grab.Execute(_camera, ref _selectedObject, ref _grabOffset, 0);

            if (Input.GetMouseButton(0) && _selectedObject != null)
                _drag.Execute(_camera, ref _selectedObject, ref _grabOffset, _dragSpeed);

            if (Input.GetMouseButtonUp(0) && _selectedObject != null)
                _release.Execute(_camera, ref _selectedObject, ref _grabOffset, 0);

            if (Input.GetMouseButtonDown(1))
                _explosion.Execute(_camera, ref _selectedObject, ref _grabOffset, _explosionRadius);
        }
    }
}
using UnityEngine;

namespace HM20_21.Scripts
{
    public class ObjectManager : MonoBehaviour
    {
        [SerializeField] private LayerMask _grabbableMask;
        [SerializeField] private string _explodableTag;
        [SerializeField] private ExplosionEffect _explosionPrefab;

        private Camera _camera;
        private GrabService _grabService;
        private DragService _dragService;
        private ReleaseService _releaseService;
        private ExplosionService _explosionService;
        
        private IGrabbable _currentGrabbable;

        private void Start()
        {
            _camera = Camera.main;
            _grabService = new GrabService(_grabbableMask);
            _dragService = new DragService();
            _releaseService = new ReleaseService();
            _explosionService = new ExplosionService(_explosionPrefab, _explodableTag);
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                _currentGrabbable = _grabService.TryGrab(ray);
            }

            if (Input.GetMouseButton(0))
            {
                if (_currentGrabbable != null)
                {
                    _dragService.Drag(ray, _currentGrabbable);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (_currentGrabbable != null)
                    _releaseService.Release(_currentGrabbable);
            }

            if (Input.GetMouseButtonDown(1))
            {
                _explosionService.Explode(ray);
            }
        }
    }
}
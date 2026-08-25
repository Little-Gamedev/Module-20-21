using UnityEngine;

public class Dragging : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Collider _groundCollider;

    [SerializeField] private int _dragMouseButton = 0;

    private bool _isDragging = false;

    private Transform _draggedTransform;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_dragMouseButton))
            TryStartDrag();

        if (Input.GetMouseButton(_dragMouseButton) && _isDragging)
            Drag();

        if (Input.GetMouseButtonUp(_dragMouseButton))
            StopDrag();
    }

    private void TryStartDrag()
    {
        Ray mouseRay = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseRay, out RaycastHit hit))
        {
            IDraggable draggable = hit.collider.GetComponent<IDraggable>();

            if (draggable == null)
                return;
            else
            {
                _draggedTransform = draggable.DragTransform;
                _isDragging = true;
            }
        }
    }

    private void Drag()
    {
        Ray mouseRay = _camera.ScreenPointToRay(Input.mousePosition);

        if (_groundCollider.Raycast(mouseRay, out RaycastHit hit, Mathf.Infinity))
        {
            Vector3 newPosition = new Vector3(hit.point.x, _draggedTransform.position.y, hit.point.z);

            _draggedTransform.position = newPosition;
        }
    }

    private void StopDrag()
    {
        _draggedTransform = null;
        _isDragging = false;
    }
}
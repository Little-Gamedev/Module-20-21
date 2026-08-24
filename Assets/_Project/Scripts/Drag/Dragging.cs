using UnityEngine;

public class Dragging : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Collider _groundCollider;

    [SerializeField] private int _dragMouseButton = 0;

    private Transform _draggedTransform;
    private Ray mouseRay;

    private void Update()
    {
        TryDrag();
    }

    private void TryDrag()
    {
        if (!Input.GetMouseButton(_dragMouseButton) && !IsDraggable()) return;

        if (_draggedTransform == null) return;

        Drag(_draggedTransform);
    }

    private bool IsDraggable()
    {
        mouseRay = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseRay, out RaycastHit hit))
        {
            IDraggable draggable = hit.collider.GetComponent<IDraggable>();
            if (draggable == null)
            {
                _draggedTransform = null;
                return false;
            }

            _draggedTransform = draggable.DragTransform;
            return true;
        }
        else
            _draggedTransform = null;
        return false;
    }

    private void Drag(Transform draggedTransform)
    {
        Vector3 newPosition = Input.mousePosition;
        _draggedTransform.position = newPosition;
    }
}

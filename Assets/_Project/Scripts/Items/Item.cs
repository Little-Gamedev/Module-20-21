using UnityEngine;

public class Item : MonoBehaviour, IDraggable
{
    public Transform DragTransform => transform;
}

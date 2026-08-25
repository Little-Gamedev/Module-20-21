using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour, IDraggable, IReactive
{
    [SerializeField] private Rigidbody _rigidbody;

    public Transform DragTransform => transform;

    public void React(Vector3 explosionPosition, float explosionForce, float explosionRadius)
    {
        _rigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
    }
}

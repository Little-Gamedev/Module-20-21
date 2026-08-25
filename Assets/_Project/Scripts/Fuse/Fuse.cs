using UnityEngine;

public class Fuse : MonoBehaviour
{
    [SerializeField] private float _radius = 2f;
    [SerializeField] private float _force = 5f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            Shoot();
    }

    private void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Collider[] targets = Physics.OverlapSphere(hit.point, _radius);

            foreach (Collider target in targets)
            {
                IReactive reactive = target.GetComponent<IReactive>();
                if (reactive != null)
                    reactive.React(hit.point, _force, _radius);
            }
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ExplosiveBarrel : MonoBehaviour
{
    [SerializeField] private float _power;
    [SerializeField] private float _radius;

    private Rigidbody _rigidbody;

    public UnityEvent OnExplode;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Explode()
    {
        _rigidbody.AddExplosionForce(_power, transform.position, _radius);
        OnExplode?.Invoke();
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _radius);
    }
}

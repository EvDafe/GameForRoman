using System;
using UnityEngine;

[RequireComponent(typeof(Chessman))]
[RequireComponent(typeof(Rigidbody))]
public class ChessmanThrower : MonoBehaviour
{
    [SerializeField] protected float _throwPower;
    [SerializeField] protected float _maxThrowDistance;

    public float MaxThrowDistance => _maxThrowDistance;

    protected Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public virtual void Throw(Vector3 point)
    {
        if (point == null) throw new ArgumentException();

        Vector3 direction = point.FindReflectedVectorBetween(transform.position);
        float distance = Vector3.Distance(point, transform.position);
        if (distance > _maxThrowDistance) distance = _maxThrowDistance;
        _rigidbody.AddForce(_throwPower * distance * direction.normalized);
    }
}

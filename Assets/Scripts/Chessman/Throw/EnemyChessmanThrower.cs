using System;
using UnityEngine;

public class EnemyChessmanThrower : ChessmanThrower
{
    public override void Throw(Vector3 point)
    {
        if (point == null) throw new ArgumentException();

        Vector3 direction = point.FindVectorBetween(transform.position);
        _rigidbody.AddForce(_throwPower * _maxThrowDistance * direction.normalized);
    }
}

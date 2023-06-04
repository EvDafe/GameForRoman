using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Chessman))]
[RequireComponent(typeof(Rigidbody))]
public class ChessmanPusher : MonoBehaviour
{
    [SerializeField] float _pushPower;
    [SerializeField] float _pushResistance;

    private Rigidbody _rigidbody;

    public float PushPower => _pushPower;
    public float Magnitude => _rigidbody.velocity.magnitude;
    public UnityEvent OnPush;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out ChessmanPusher pusher))
        {
            Push(pusher);
        }
    }
    private void Push(ChessmanPusher pusher)
    {
        var pusherPosition = pusher.transform.position;
        var direction = pusherPosition.FindReflectedVectorBetween(transform.position);
        direction = direction.normalized;
        Debug.Log(pusher.Magnitude);
        Vector3 offset = direction * pusher.Magnitude * pusher.PushPower / _pushResistance;
        _rigidbody.AddForce(offset);
        OnPush?.Invoke();
    }
}

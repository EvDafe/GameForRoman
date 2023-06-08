using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

[RequireComponent(typeof(Chessman))]
public class ChessmanHealth : MonoBehaviour
{
    private Chessman _chessman;

    public UnityEvent OnDeath;

    private void Start()
    {
        _chessman = GetComponent<Chessman>();
    }
    private void Death()
    {
        OnDeath.AddListener(Wallet.Instance.TakeMoney);
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DeathTrigger deathTrigger))
        {
            Death();
        }
    }
}

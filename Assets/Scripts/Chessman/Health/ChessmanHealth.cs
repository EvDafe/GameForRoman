using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Chessman))]
public class ChessmanHealth : MonoBehaviour
{
    public UnityEvent OnDeath;
    public UnityEvent<Chessman> Died;
    private void Death()
    {
        Chessman chessman = GetComponent<Chessman>();
        OnDeath.AddListener(Wallet.Instance.TakeMoney);
        OnDeath?.Invoke();
        Died?.Invoke(chessman);
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

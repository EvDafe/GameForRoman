using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ChessmanHealth))]
public class WalletMoneyGiver : MonoBehaviour
{
    private ChessmanHealth _health;

    public UnityEvent OnGiveMoney;

    private void Start()
    {
        _health = GetComponent<ChessmanHealth>();
        _health.OnDeath.AddListener(GiveMoney);
    }
    private void GiveMoney()
    {
        Wallet.Instance.TakeMoney();
        OnGiveMoney?.Invoke();
    }
}

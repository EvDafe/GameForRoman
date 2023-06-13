using UnityEngine;
using UnityEngine.Events;

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
        OnDeath?.Invoke();
        ChessmanContainer.Instance.DeathChessman(_chessman);
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

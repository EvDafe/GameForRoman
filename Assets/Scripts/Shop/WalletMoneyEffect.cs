using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class WalletMoneyEffect : MonoBehaviour
{
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}

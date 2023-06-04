using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] Chessman _chessmanPrefab;
    [SerializeField] Transform _chessmanSpawnPosition;
    [SerializeField] float _cost;

    public float Cost => _cost;
    public void TryBuy()
    {
        if (Wallet.Instance.Money >= _cost)
            Buy();
    }
    private void Buy()
    {
        Wallet.Instance.TryGiveMoney(_cost);
        Instantiate(_chessmanPrefab, _chessmanSpawnPosition.position, Quaternion.identity);
    }
} 

using UnityEngine;

[RequireComponent(typeof(WalletMoneyGiver))]
public class WalletMoneyGiverPresenter : MonoBehaviour
{
    [SerializeField] private WalletMoneyEffect _effectPrefab;

    private WalletMoneyGiver _giver;

    private void Start()
    {
        _giver = GetComponent<WalletMoneyGiver>();
        _giver.OnGiveMoney.AddListener(CreateEffect);
    }

    private void CreateEffect()
    {
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
    }
}

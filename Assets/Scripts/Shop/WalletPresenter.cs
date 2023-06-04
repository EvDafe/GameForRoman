using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class WalletPresenter : MonoBehaviour
{
    private Text _text;
    private void Start()
    {
        _text = GetComponent<Text>();
        Wallet.Instance.OnChangeMoney.AddListener(UpdateText);
    }

    private void UpdateText(float money)
    {
        _text.text = money.ToString();
    }
}

using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Turn))]
public class TurnPresenter : MonoBehaviour
{
    
    [SerializeField] private string _text;

    private Turn _turn;

    private void Start()
    {
        _turn = GetComponent<Turn>();
        _turn.OnStart.AddListener(TurnText.Instance.UpdateText);
        _turn.OnStart?.Invoke(_text);
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class PlayerTurn : Turn
{
    private PlayerChessman _selectedChessman;

    private void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            TrySelectChessman();
        }
        if (Input.GetMouseButtonUp((int)MouseButton.Left))
        {
            TryThrowChessman();
        }
    }
    private void TrySelectChessman()
    {
        InputManager.Instance.TryGetComponentAtMousePosition(out PlayerChessman playerchess);
        _selectedChessman = playerchess;
    }
    private void TryThrowChessman()
    {
        if(_selectedChessman != null)
        {
            InputManager.Instance.GetMousePosition(out Vector3 mousePosition);
            ChessmanThrower thrower = _selectedChessman.GetComponent<ChessmanThrower>();
            thrower.Throw(mousePosition);
            _selectedChessman = null;
            EndTurn();
        }
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class PlayerTurn : Turn
{
    private Camera _camera;

    private PlayerChessman _selectedChessman;

    private void Start()
    {
        _camera = Camera.main;
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
        Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);
        if (hit.collider.TryGetComponent(out PlayerChessman playerchess))
            _selectedChessman = playerchess;
    }
    private void TryThrowChessman()
    {
        if(_selectedChessman != null)
        {
            Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);
            ChessmanThrower thrower = _selectedChessman.GetComponent<ChessmanThrower>();
            thrower.Throw(hit.point);
            _selectedChessman = null;
            EndTurn();
        }
    }
}

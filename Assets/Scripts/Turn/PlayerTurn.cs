using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerTurnPresenter))]
public class PlayerTurn : Turn
{
    private Camera _camera;
    private PlayerTurnPresenter _presenter;
    private PlayerChessman _selectedChessman;

    private void Start()
    {
        _camera = Camera.main;
        _presenter = GetComponent<PlayerTurnPresenter>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            TrySelectChessman();
            _presenter.TrySpawnEffect(_selectedChessman);
        }
        if (Input.GetMouseButton((int)MouseButton.Left))
        {
            _presenter.Present(_selectedChessman, _camera);
        }
        if (Input.GetMouseButtonUp((int)MouseButton.Left))
        {
            TryThrowChessman();
            _presenter.TryDeleteEffect();
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

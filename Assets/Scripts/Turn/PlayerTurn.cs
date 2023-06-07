using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerTurnCursorSpawner))]
public class PlayerTurn : Turn
{
    [SerializeField] private LayerMask _chessmansLayer;

    private PlayerChessman _selectedChessman;
    private PlayerTurnCursorSpawner _cursorSpawner;

    private void Start()
    {
        _cursorSpawner = GetComponent<PlayerTurnCursorSpawner>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            TrySelectChessman();
            _cursorSpawner.TrySpawnEffect(_selectedChessman);
        }
        if (Input.GetMouseButtonUp((int)MouseButton.Left))
        {
            TryThrowChessman();
            _cursorSpawner.TryDeleteEffect();
        }
    }
    private void TrySelectChessman()
    {
        PlayerChessman playerchess = InputManager.Instance.TryGetComponentAtMousePosition<PlayerChessman>(_chessmansLayer);
        if(playerchess != null)
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

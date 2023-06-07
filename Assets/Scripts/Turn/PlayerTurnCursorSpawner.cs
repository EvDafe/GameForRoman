using UnityEngine;

public class PlayerTurnCursorSpawner : MonoBehaviour
{
    [SerializeField] private PlayerTurnCursor _linePrefab;
    [SerializeField] private float _floorMargin;

    private PlayerTurnCursor _spawnedLine;
    public void TrySpawnEffect(Chessman chessman)
    {
        if (chessman != null)
        {
            InputManager.Instance.GetMousePosition(out Vector3 mousePosition);
            _spawnedLine = Instantiate(_linePrefab, mousePosition + Vector3.up, Quaternion.identity);
            _spawnedLine.SetChessman(chessman);
        }
    }

    public void TryDeleteEffect()
    {
        if (_spawnedLine != null)
            Destroy(_spawnedLine.gameObject);
    }
}

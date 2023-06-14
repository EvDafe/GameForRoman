using System.Collections;
using UnityEngine;

public class EnemyTurn : Turn
{
    [SerializeField] private float _turnDuration;

    private EnemyChessman _selectedChessman;

    private void Start()
    {
        Invoke(nameof(Turn), _turnDuration);
    }
    
    private void Select()
    {
        int index = Random.Range(0, ChessmanContainer.Instance.EnemyChessmans.Count);
        _selectedChessman = ChessmanContainer.Instance.EnemyChessmans[index];
    }
    
    private Vector3 FindClosestPlayerChessmanPosition()
    {
        if(ChessmanContainer.Instance.PlayerChessmans.Count > 0)
        {
            Vector3 selectedChessmanPosition = _selectedChessman.transform.position;
            return selectedChessmanPosition.FindClosest(ChessmanContainer.Instance.PlayerChessmans);
        }
        return Vector3.zero;
    }

    private void Turn()
    {
        Select();
        var closest = FindClosestPlayerChessmanPosition();
        Throw(closest);
        EndTurn();
    }
    private void Throw(Vector3 point)
    {
        var thrower = _selectedChessman.GetComponent<EnemyChessmanThrower>();
        thrower.Throw(point);
    }
}

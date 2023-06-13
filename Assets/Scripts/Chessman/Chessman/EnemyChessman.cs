using System.Linq;
using UnityEngine;

public class EnemyChessman : Chessman
{
    private void Start()
    {
        ChessmanContainer.Instance.AddEnemy(this);
    }
    private void OnDestroy()
    {
        TryRemoveMe();
    }

    private void TryRemoveMe()
    {
        if (ChessmanContainer.Instance.EnemyChessmans.Contains(this))
            ChessmanContainer.Instance.RemoveEnemy(this);
    }
}

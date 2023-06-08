using UnityEngine;

public class EnemyChessman : Chessman
{
    private void Start()
    {
        Chessman—ontainer.Instance.AddEnemy(this);
    }
    private void OnDestroy()
    {
        Chessman—ontainer.Instance.RemoveEnemy(this);
    }
}

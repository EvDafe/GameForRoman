using UnityEngine;

public class PlayerChessman : Chessman
{
    private void Start()
    {
        Chessman—ontainer.Instance.AddPlayer(this);
    }
    private void OnDestroy()
    {
        Chessman—ontainer.Instance.RemovePlayer(this);
    }
}

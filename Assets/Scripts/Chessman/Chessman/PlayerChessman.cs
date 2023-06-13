using UnityEngine;

public class PlayerChessman : Chessman
{
    private void Start()
    {
        ChessmanContainer.Instance.AddPlayer(this);
    }
    private void OnDestroy()
    {
        TryRemoveMe();
    }

    private void TryRemoveMe()
    {
        if(ChessmanContainer.Instance.PlayerChessmans.Contains(this))
            ChessmanContainer.Instance.RemovePlayer(this);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class WinChecker : MonoBehaviour
{
    private void Start()
    {
        ChessmanContainer.Instance.OnDeathChessman.AddListener(CheckWin);
    }
    
    private void CheckWin()
    {
        if (ChessmanContainer.Instance.EnemyChessmans.Count == 0)
            Win();
    }
    private void Win()
    {
        Debug.Log("Win");
        new SceneManager().TryLoadNextScene();
    }
}

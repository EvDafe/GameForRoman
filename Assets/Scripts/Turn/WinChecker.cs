using UnityEngine;
using UnityEngine.SceneManagement;

public class WinChecker : MonoBehaviour
{
    private void FixedUpdate()
    {
        CheckWin();
    }
    private void CheckWin()
    {
        if (ChessmanContainer.Instance.EnemyChessmans.Count == 0)
            Win();
    }
    private void Win()
    {
        new SceneManager().TryLoadNextScene();
    }
}

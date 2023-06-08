using UnityEngine;
using UnityEngine.SceneManagement;

public class WinChecker : MonoBehaviour
{
    private void Start()
    {
        Chessman—ontainer.Instance.OnRemoveChessman.AddListener(CheckWin);
    }
    
    private void CheckWin()
    {
        if (Chessman—ontainer.Instance.EnemyChessmans.Count == 0)
            Win();
    }
    private void Win()
    {
        new SceneManager().TryLoadNextScene();
    }
}

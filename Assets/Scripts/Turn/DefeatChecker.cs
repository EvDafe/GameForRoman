using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatChecker : MonoBehaviour
{
    private void FixedUpdate()
    {
        CheckDefeat();
    }
    private void CheckDefeat()
    {
        if (ChessmanContainer.Instance.PlayerChessmans.Count == 0)
            Defeat();
    }
    private void Defeat()
    {
        new SceneManager().ReloadScene();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatChecker : MonoBehaviour
{
    private void Start()
    {
        ChessmanContainer.Instance.OnDeathChessman.AddListener(CheckDefeat);
    }

    private void CheckDefeat()
    {
        if (ChessmanContainer.Instance.PlayerChessmans.Count == 0)
            Defeat();
    }
    private void Defeat()
    {
        Debug.Log("Defeat");
        new SceneManager().ReloadScene();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatChecker : MonoBehaviour
{
    private void Start()
    {
        Chessman—ontainer.Instance.OnRemoveChessman.AddListener(CheckDefeat);
    }

    private void CheckDefeat()
    {
        if (Chessman—ontainer.Instance.PlayerChessmans.Count == 0)
            Defeat();
    }
    private void Defeat()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}

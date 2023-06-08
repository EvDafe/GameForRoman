using UnityEngine.SceneManagement;

public static class SceneManagerExtensions
{
    public static void ReloadScene(this SceneManager manager)
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    public static void TryLoadNextScene(this SceneManager manager)
    {
        var currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex != SceneManager.sceneCount)
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        else
            SceneManager.LoadScene(currentScene.buildIndex);
    }
}

using UnityEngine.SceneManagement;
using UnityEngine;

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
        int nextSceneIndex = currentScene.buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextSceneIndex);
        else
            SceneManager.LoadScene(currentScene.name);

    }
}

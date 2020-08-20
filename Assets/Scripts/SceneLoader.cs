using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadAsyncScene(string sceneName)
    {
       SceneManager.LoadSceneAsync(sceneName);
    }

    public void ReloadScene() {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void ExitGame() 
    {
        Application.Quit();
    }
}

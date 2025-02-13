using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Map1");
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}

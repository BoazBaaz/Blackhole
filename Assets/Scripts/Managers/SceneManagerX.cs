using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagerX : MonoBehaviour
{
    static public SceneManagerX instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    /// <summary>
    /// Load the given _scene
    /// </summary>
    /// <param name="_scene"></param>
    public void LoadScene(int _scene)
    {
        SceneManager.LoadScene(_scene);
    }

    /// <summary>
    /// Load the next scene in the buildindex
    /// </summary>
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Stop the application
    /// </summary>
    public void StopGame()
    {
        Application.Quit();
    }
}

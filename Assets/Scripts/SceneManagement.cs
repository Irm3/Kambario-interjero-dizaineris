using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField]
    private GameObject Credits;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoCredits()
    {
        Credits.SetActive(true);
        gameObject.SetActive(false);
    }

    public void GoMainMenu()
    {
        Credits.SetActive(false);
        gameObject.SetActive(true);
    }
}

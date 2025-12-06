using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Back()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}

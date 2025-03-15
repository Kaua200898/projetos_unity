using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("GameOver")]
    public static bool GameIsOver;
    [SerializeField] GameObject panelGameOver;

    [Header("Attributes")]
    public static int Points;

    [Header("UI")]
    [SerializeField] Text textPoints;

    // Start is called before the first frame update
    void Start()
    {
        GameIsOver = false;
        Points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void GameOver()
    {
        Time.timeScale = 0.5f;
        panelGameOver.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        panelGameOver.SetActive(false);
        SpawnerEnemies.EnemiesAlive = 0;
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    void UpdateUI()
    {
        textPoints.text = GameManager.Points.ToString();
    }
}

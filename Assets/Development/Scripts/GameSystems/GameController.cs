using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject gameOverWindow;
   
    void Start()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        gameOverWindow.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGames : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && SceneManager.GetActiveScene().name == "GameScene")
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}

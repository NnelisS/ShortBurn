using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }    

    public void GameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }    
    
    public void Quit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 public void PlayGame()
    {
        //brings into game from main menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Playagain()
    {
        //brings into game from caught menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void menu()
    {
        //goes into main menu from caught menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void replay()
    {
        //goes intogame from win menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void menu2()
    {
        // goes into main menu from win menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    public void QuitGame()
    {
        // closes game
        Application.Quit();
    }
}

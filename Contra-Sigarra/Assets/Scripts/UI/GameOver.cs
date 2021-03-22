using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static void gameOverScreen()
    {
        SceneManager.LoadScene(1);
    }

    public static void WinScreen()
    {
        SceneManager.LoadScene(3);
    }
}

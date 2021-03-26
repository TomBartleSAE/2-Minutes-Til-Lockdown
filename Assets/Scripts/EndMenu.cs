using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene("Supermarket");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextScene : MonoBehaviour
{
    public void LoadingNextScene()
    {
        SceneManager.LoadScene("ChooseLevel");
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("GamePanel");
    }
}



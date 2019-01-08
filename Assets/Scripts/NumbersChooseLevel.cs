using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseLevel : MonoBehaviour {

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("NumbersGameLevel1");
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("NumbersGameLevel2");
    }
    public void LoadLevelThree()
    {
        SceneManager.LoadScene("NumbersGameLevel3");
    }
    public void GoBack()
    {
        SceneManager.LoadScene("NumbersLearning");
    }
}

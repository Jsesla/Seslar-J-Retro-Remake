using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneLoader : MonoBehaviour
{
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("level one");
    }
}

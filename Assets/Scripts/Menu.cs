using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ButtonPlay(){
        SceneManager.LoadScene("Level_1");
    }
    public void ButtonAbout(){
        //SceneManager.LoadScene("Level_1");
    }
    public void ButtonExit(){
        Application.Quit();
    }
}

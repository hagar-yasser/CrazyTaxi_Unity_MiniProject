using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoaderScript : MonoBehaviour
{
    private bool mute = false;
    public Button myButton;
    public TMP_Text buttonText;
    void Start() {
         AudioListener.volume = 1;
    }
    public void LoadScene(){
        SceneManager.LoadScene("Scenes/GameScene");
    }
    public void QuitGame(){
        Application.Quit();
        Debug.Log("I have quitted");
    }
    public void Mute(){
        mute = !mute;
        if (mute)
        {
            ColorBlock newColor = myButton.colors;
            newColor.normalColor = new Color(1, 1, 0);
            myButton.colors = newColor;
            buttonText.text = "Unmute";
            AudioListener.volume = 0;
        }
        else{
            ColorBlock newColor = myButton.colors;
            newColor.normalColor = new Color(1, 0, 0);
            myButton.colors = newColor;
            buttonText.text = "Mute";
            AudioListener.volume = 1;
        }
    }
}

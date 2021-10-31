using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart(){
        SceneManager.LoadScene("GameScene");
        
    }
    public void GoToMainMenu(){
        SceneManager.LoadScene("TitleScreen");
    }
}

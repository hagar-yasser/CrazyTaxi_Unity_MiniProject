using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenScript : MonoBehaviour
{
  
   public void Restart(){
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class TaxiScript : MonoBehaviour
{
    private int score = 0;
    public TMP_Text myScore;
    public TMP_Text myCoins;
    public TMP_Text mySpheres;
    public TMP_Text invincible;
    public TMP_Text mySpeedText;
    private int coins = 0;
    private int spheres = 0;
    private int endHighSpeedAt =-1;
    private int endInvincibleModeAt = -1;
    private int currentTime = 0;
    private bool isInvincible = false;
    private float moveX;
    public float Speed;
    public int forwardVelocity;
    public AudioSource goodAudio;
    public AudioSource badAudio;
    public AudioSource gameMusic;
    public AudioSource invincibleMusic;
    private bool paused = false;
    private Rigidbody rb;
    // public GameObject Street;
    // public GameObject BlueSphere;
    // public GameObject Coin;
    // public GameObject Bomb;
    // public GameObject IronSphere;
    public GameObject[] Cameras;
    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    // public GameObject scoreScreen;
    private int cameraIndex=0;
    // Start is called before the first frame update
    void Start()
    {
        myCoins.text = "Coins: " + coins;
        myScore.text = "Score: " + score;
        mySpheres.text = "BlueSpheres: " + spheres;
        mySpeedText.text = "Speed: " + forwardVelocity;
        invincible.text = "Invincible Mode: " + isInvincible;
        rb = GetComponent<Rigidbody>();
       
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void  FixedUpdate()
    {
        TrackTime();
        myCoins.text = "Coins: " + coins;
        myScore.text = "Score: " + score;
        mySpheres.text = "BlueSpheres: " + spheres;
        if(currentTime==endHighSpeedAt){
            endHighSpeedAt = -1;
            forwardVelocity /= 2;
        }
        if(currentTime==endInvincibleModeAt){
            endInvincibleModeAt = -1;
            isInvincible = false;
            invincibleMusic.Stop();
            gameMusic.Play();
        }
        mySpeedText.text = "Speed: " + forwardVelocity;
        invincible.text = "Invincible Mode: " + isInvincible;
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forwardVelocity);
        // MOVE HORIZONTALLY BETWEEN LANES
        if (moveX * Speed + transform.position.x < 2 && moveX * Speed + transform.position.x > -2)
        {
            transform.Translate(new Vector3(moveX * Speed, 0, 0));
            moveX = 0;

        }
        //ADD DOWNWARD FORCE TO GET DOWN FASTER
        if(transform.position.y > 0.5){
            rb.AddForce(new Vector3(0, -20 * rb.mass, 0));
        }
        //ADD NEW STREET AND REMOVE THE CURRENT
        

        
    
    }
    //for swipe detection https://stackoverflow.com/questions/41491765/detect-swipe-gesture-direction
    public void Move(InputAction.CallbackContext context){

       
        Vector2 direction = context.ReadValue<Vector2>();
        moveX = direction.x;
        Debug.Log("position x" + transform.position.x);

        // Debug.Log("z velocity " + rb.velocity.z);

    }
    public void Jump(InputAction.CallbackContext context){
        Debug.Log("in jump "+transform.position.y);
        Debug.Log("timeScale = " + Time.timeScale);
        if (transform.position.y <= 0.6)
        {
           
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
    }
    public void ChangeCamera(InputAction.CallbackContext context){
        Debug.Log("in change camera");
        Cameras[cameraIndex].SetActive(false);
        cameraIndex = 1 - cameraIndex;
        Cameras[cameraIndex].SetActive(true);

    }
    public void PauseAndResume (InputAction.CallbackContext context){
        Debug.Log("Pause and resume");
        paused = !paused;
        pauseScreen.SetActive(paused);
        if(paused){
            Time.timeScale = 0;
            gameMusic.Pause();
        }
        else{
            Time.timeScale = 1;
            gameMusic.Play();
        }
        
    }
    public void ResumeFromPauseScreen(){
        Debug.Log("resume from pause screen");
        paused = false;
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
        gameMusic.Play();
    }
    void TrackTime(){
        currentTime = (int)Time.fixedTime;
    }
    void OnTriggerEnter(Collider collisionInfo)
    {
        if(collisionInfo.gameObject.tag=="Bomb"&&!isInvincible){
            badAudio.Play();
            Destroy(gameObject);
            Debug.Log("dead by bomb");
            gameOverScreen.SetActive(true);


        }
        if(collisionInfo.gameObject.tag=="IronSphere"&&!isInvincible){
            badAudio.Play();
            score -= 10;
            if(score<=0){
                Destroy(gameObject);
                Debug.Log("dead by iron");
                gameOverScreen.SetActive(true);
            }
        }
        if(collisionInfo.gameObject.tag=="BlueSphere"){
            goodAudio.Play();
            score += 10;
            spheres++;
            if(spheres==3){
                spheres = 0;
                TrackTime();
                endHighSpeedAt = currentTime + 7;
                forwardVelocity = forwardVelocity * 2;
            }
        }
        if(collisionInfo.gameObject.tag=="Coin"){
            goodAudio.Play();
            score += 15;
            coins++;
            if(coins==3){
                coins = 0;
                TrackTime();
                endInvincibleModeAt = currentTime + 5;
                isInvincible = true;
                gameMusic.Pause();
                invincibleMusic.Play();
            }
        }
    }
   
}

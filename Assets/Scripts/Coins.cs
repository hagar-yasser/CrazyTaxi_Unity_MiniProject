using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    // Start is called before the first frame update
    private int angle = 30;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void FixedUpdate() {
        // transform.Rotate(0, angle*Time.deltaTime,0,);
        

    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Debug.Log("inTrigger Coin");
    }
}

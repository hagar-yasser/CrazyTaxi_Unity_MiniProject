using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetScript : MonoBehaviour
{
    // Start is called before the first frame update
    StreetCreator streetCreator;
    public GameObject Bomb;
    public GameObject IronSphere;
    public GameObject BlueSphere;
    public GameObject Coin;
    void Start()
    {
        streetCreator = GameObject.FindObjectOfType<StreetCreator>();
        createObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other) {
        
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("onTrigger Exit");
        streetCreator.createTile();
        Destroy(gameObject,2);
    }
    void createObjects(){
        createBomb();
        createIronSpheres();
        createBlueSpheres();
        createCoins();
    }
    void createBomb(){
        //CREATE ONLY ONE BOMB
        //-20 to start form the beginning of the street
        Vector3 location = new Vector3(
            Random.Range(-1,1),
             0.5f, 
             (Random.Range(0.2f, 1.0f) * 40) + transform.position.z-20 );
            GameObject temp=Instantiate(Bomb);
            temp.transform.position = location;
            temp.transform.SetParent(transform, true);
            
    }
    void createIronSpheres(){
        //CREATE RANDOM NUMBER OF IRON SPHERES BETWEEN 0-1
        int quantity = Random.Range(0, 2);
        for (int i = 0; i < quantity; i++)
        {
            Vector3 location = new Vector3(
            Random.Range(-1,1),
             0.5f, 
             (Random.Range(0.2f, 1.0f) * 40) + transform.position.z-20 );
             //ATTATCH THEM TO THIS STREET INSTANCE TO GET DESTROYED WITH IT
            GameObject temp=Instantiate(IronSphere);
            temp.transform.position = location;
            temp.transform.SetParent(transform, true);
        }
    }
    void createBlueSpheres(){
        //CREATE RANDOM NUMBER OF BLUE SPHERES BETWEEN 0-1
        int quantity = Random.Range(0, 2);
        for (int i = 0; i < quantity; i++)
        {
            Vector3 location = new Vector3(
            Random.Range(-1,1),
             0.5f, 
             (Random.Range(0.2f, 1.0f) * 40) + transform.position.z-20 );
             //ATTATCH THEM TO THIS STREET INSTANCE TO GET DESTROYED WITH IT
            GameObject temp=Instantiate(BlueSphere);
            temp.transform.position = location;
            temp.transform.SetParent(transform, true);
        }
    }
    void createCoins(){
         //CREATE RANDOM NUMBER OF COINS BETWEEN 0-1
        int quantity = Random.Range(0, 2);
        for (int i = 0; i < quantity; i++)
        {
            Vector3 location = new Vector3(
            Random.Range(-1,1),
             0.5f, 
             (Random.Range(0.2f, 1.0f) * 40) + transform.position.z -20);
             //ATTATCH THEM TO THIS STREET INSTANCE TO GET DESTROYED WITH IT
            GameObject temp=Instantiate(Coin);
            temp.transform.position = location;
            temp.transform.SetParent(transform, true);
            
        }
    }
}

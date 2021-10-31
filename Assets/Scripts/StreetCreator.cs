using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetCreator : MonoBehaviour
{
    public float Offset = 80;
    public GameObject Street;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void createTile(){
        Instantiate(Street, new Vector3(0, 0, Offset), Quaternion.identity);
        Offset += 40;
    }
    
}

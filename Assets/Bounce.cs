using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    float placeholder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.GetComponent<Player_Script>())
        {

            other.gameObject.GetComponent<Player_Script>().gravityValue = 20000*Time.deltaTime;
            

        }
    }
}

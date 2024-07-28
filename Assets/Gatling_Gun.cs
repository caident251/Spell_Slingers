using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingGun : MonoBehaviour
{
     GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                if(transform.parent.parent != null){
         player = transform.parent.parent.GetChild(1).GetComponent<wand>().Player;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wand : MonoBehaviour
{
    public GameObject Player;
    public Combat moveset;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moveset = Player.GetComponent<Combat>();
        
    }
    void Fire(){
       // if(moveset.Attack == 2){
       // Instantiate(moveset.Secondary.creation, transform.position,Quaternion.identity);
       // }
        if(moveset.Attack == 1){
               GameObject b = Instantiate(moveset.Primary.creation, transform.position,Player.transform.GetChild(0).GetChild(1).GetChild(0).rotation * moveset.Primary.creation.transform.rotation);
             // b.transform.parent = Player.transform.GetChild(0).GetChild(1).rotation * b.transform.rotation;
              b.transform.parent = Player.transform.GetChild(0).GetChild(1).GetChild(0);
        }
        if (moveset.Attack == 2)
        {
            
            GameObject b = Instantiate(moveset.Secondary.creation, transform.position, Player.transform.GetChild(0).GetChild(1).GetChild(0).rotation * moveset.Secondary.creation.transform.rotation);
            // b.transform.parent = Player.transform.GetChild(0).GetChild(1).rotation * b.transform.rotation;
            b.transform.parent = Player.transform.GetChild(0).GetChild(1).GetChild(0);
        }
        moveset.Attack = 0;
    }
}

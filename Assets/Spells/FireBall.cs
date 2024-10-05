using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.GetChild(1).GetComponent<wand>().Player;
        float magiccost = player.GetComponent<Combat>().Cost;
        player.GetComponent<Combat>().Curmagic -= magiccost;
        GetComponent<DamageDealer>().Source = player;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.parent != null)
        {
            player = transform.parent.GetChild(1).GetComponent<wand>().Player;
        }
        if (GetComponent<Animation>().isPlaying == false)
        {
            if (transform.parent != null)
            {
                GetComponent<Rigidbody>().AddForce(Camera.main.transform.up * 300f + Camera.main.transform.forward *  1000f);

            }
            transform.parent = null;
            GetComponent<Rigidbody>().useGravity=true;
            GetComponent<DamageDealer>().Source=player;
        }
        
    }
}

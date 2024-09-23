using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_sword : MonoBehaviour
{
    GameObject player;
    int mouse;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.parent.GetChild(1).GetComponent<wand>().Player;
        float magiccost = player.GetComponent<Combat>().Cost;

        player.GetComponent<Combat>().Curmagic -= magiccost;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(player.GetComponent<Combat>().lookpoint);

        float magiccost = player.GetComponent<Combat>().Cost;
        player.GetComponent<Combat>().Curmagic -= magiccost;

        if (player.GetComponent<Combat>().Curmagic < magiccost)
        {
            Destroy(gameObject.transform.parent.gameObject);
            player.GetComponent<Combat>().Attack = 0;


        }
        else
        {
            if(Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
            {
                anim.speed = 1;

            }
        }
GetComponent<DamageDealer>().Source = player;
            player.GetComponent<Combat>().Attack = 3;
        

    }
    public void Pause()
    {
        anim.speed = 0;
    }
}


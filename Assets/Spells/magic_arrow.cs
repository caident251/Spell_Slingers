using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic_arrow : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.parent.GetChild(1).GetComponent<wand>().Player;
        float magiccost = player.GetComponent<Combat>().Cost;
        player.GetComponent<Combat>().Curmagic -= magiccost;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.parent != null){
         player = transform.parent.parent.GetChild(1).GetComponent<wand>().Player;
        }
       if(GetComponent<Animation>().isPlaying ==false){
        transform.parent.parent = null;
       
         transform.parent.position += transform.parent.up * 2.5f;

       } 
       for(int i = 0; i<transform.childCount;i++)
       {
           if(GetComponent<Animation>().isPlaying ==false)
    {
           GameObject a = transform.GetChild(i).gameObject;
       if(a.GetComponent<SphereCollider>()==null)
       {
                var c = a.AddComponent<DamageDealer>();
       var b = a.AddComponent<Rigidbody>();
                    var g = a.AddComponent<SphereCollider>();

                }
       else
       {
          var g = a.GetComponent<SphereCollider>();
           g.isTrigger = true;
           g.radius = 2;
                var c = a.GetComponent<DamageDealer>();
                c.Source =player;
                    c.Destructable = true;
       c.Damage = player.GetComponent<Combat>().CurSpell.damage;
       c.lifetime = player.GetComponent<Combat>().CurSpell.lifetime;
       var b = a.GetComponent<Rigidbody>();
       b.isKinematic = true;
       }
       }
 
       }

    }
}

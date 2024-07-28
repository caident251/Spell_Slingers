using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic_arrow : MonoBehaviour
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
       if(GetComponent<Animation>().isPlaying ==false){
        transform.parent.parent = null;
       
         transform.parent.position += transform.parent.up * 2.5f;

       } 
       for(int i = 0; i<transform.childCount;i++)
       {
           if(GetComponent<Animation>().isPlaying ==false){
           GameObject a = transform.GetChild(i).gameObject;
       if(a.GetComponent<MeshCollider>()==null)
       {
          var g = a.AddComponent<MeshCollider>();
           g.convex = true;
           g.isTrigger = true;
           g.providesContacts = true;
                var c = a.AddComponent<DamageDealer>();
                c.Source =player;
       c.Damage = 10;
       var b = a.AddComponent<Rigidbody>();
       b.isKinematic = true;
       }
       }
 
       }
    }
}

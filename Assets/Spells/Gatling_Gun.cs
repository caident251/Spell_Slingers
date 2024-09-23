using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingGun : MonoBehaviour
{
    float FireRate ;

    GameObject player;
    public GameObject Orb;
    GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.parent != null)
        {
            player = transform.parent.parent.GetChild(1).GetComponent<wand>().Player;
        }
        transform.parent.parent = transform.parent.parent.GetChild(1);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.GetComponent<Combat>().lookpoint);
         a = Instantiate(Orb,transform.position,transform.rotation);
      float magiccost =  player.GetComponent<Combat>().Cost;
      player.GetComponent<Combat>().Curmagic -= magiccost;
        if (a.GetComponent<MeshCollider>() == null)
        {
            var g = a.AddComponent<MeshCollider>();
            g.convex = true;
            g.isTrigger = true;
            var c = a.AddComponent<DamageDealer>();
            c.Source = player;
            c.Damage = player.GetComponent<Combat>().CurSpell.damage;
            c.Destructable = true;
            c.lifetime = 5;
            var b = a.AddComponent<Rigidbody>();
            b.useGravity = false;

        }
        if ((!Input.GetMouseButton(1) && !Input.GetMouseButton(0)) || player.GetComponent<Combat>().Curmagic < magiccost)
        {
            Destroy(gameObject.transform.parent.gameObject);
            player.GetComponent<Combat>().Attack = 0;


        }
        if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
        {
            player.GetComponent<Combat>().Attack = 3;
        }

        a.GetComponent<Rigidbody>().AddForce(transform.forward*1000);
    }
}

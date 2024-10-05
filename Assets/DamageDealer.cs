using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float Damage,timer,lifetime;
    public GameObject Source;
    public bool Destructable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         timer = timer + Time.deltaTime;
        if (timer > lifetime)
        {
            if (Destructable)
            {
                Destroy(gameObject);
            }

        }
    }
   void OnTriggerEnter(Collider other){

        if (other.gameObject != Source)
        {
            if (other.gameObject.GetComponent<Enemy_Health>() != null)
            {
                other.gameObject.GetComponent<Enemy_Health>().DoDamage(Damage * Source.GetComponent<Combat>().Strength * Source.GetComponent<Combat>().Magic);
            }
            else
            {
                if (other.gameObject.layer != LayerMask.NameToLayer("Projectile"))
                {
                    
                }
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float Damage;
    public GameObject Source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   void OnTriggerEnter(Collider other){
        if(other.gameObject != Source){
            Debug.Log(other.name);
            if(other.gameObject.GetComponent<Enemy_Health>() != null){
            other.gameObject.GetComponent<Enemy_Health>().DoDamage(Damage * Source.GetComponent<Combat>().Strength*Source.GetComponent<Combat>().Magic);
            }
        Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
   public float Max_Health,Cur_health;
    // Start is called before the first frame update
    void Start()
    {
       Cur_health=Max_Health;
    }

    // Update is called once per frame
    void Update()
    {
       if(Cur_health <1){
           Destroy(gameObject);
       } 
    }
    public void DoDamage(float damage){
        Cur_health -= damage;
    }
}

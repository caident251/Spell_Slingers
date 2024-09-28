using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Health : MonoBehaviour
{
   public float Max_Health,Cur_health;

    GameObject[] spawn;
    public Color[] origincolor;
    public float p;
    // Start is called before the first frame update
    void Start()
    {
       Cur_health=Max_Health;
        p = Max_Health;
        origincolor = new Color[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Renderer>() != null)
            {
                origincolor[i] = transform.GetChild(i).GetComponent<Renderer>().material.color;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
       if(Cur_health <1){
          Destroy(gameObject);
       }
       if(p > Cur_health)
        {
            Debug.Log("b");
            p = p - (p - Cur_health)*Time.deltaTime*200;


        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<Renderer>() != null)
                {
                    transform.GetChild(i).GetComponent<Renderer>().material.color = origincolor[i];
                }
            }
        }
    }
    public void DoDamage(float damage){
        Cur_health -= damage;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Renderer>() != null)
            {
                Debug.Log(gameObject.name);

                transform.GetChild(i).GetComponent<Renderer>().material.color=Color.white *Color.white;
            }
        }

    }
    void reset()
    {

    }
}

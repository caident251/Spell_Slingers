using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorshower : MonoBehaviour
{
    public GameObject Meteor;
       // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.gameObject.transform.position,Camera.main.gameObject.transform.forward, out hit,50f))
        {
        if (Input.GetMouseButtonDown(1) ||Input.GetMouseButtonDown(0))
        { 
                 StartCoroutine( Shower(hit.point));
                }
            }
        
      

    }
    IEnumerator Shower(Vector3 v)
{
    for(int i = 0;i<18;i++)
    {
        if(i==17){
            this.enabled =false;
        }
                        GameObject b = Instantiate(Meteor,v + new Vector3(0,50,0)+Random.onUnitSphere*10,Quaternion.identity);
                b.GetComponent<DamageDealer>().Source = gameObject;
        yield return new WaitForSeconds(Random.Range(0.5f,1));
    }
}
}
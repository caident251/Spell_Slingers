using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Screecher : MonoBehaviour
{
    Animator Anim;
    NavMeshAgent Agent;
   public GameObject[] Players, obs;
    public LayerMask Playerlayer, groundMask;
    public int counter,i,Attack;
    public GameObject Target;
    float dist;
    public float attackrange,distance,Damage;
    public Transform Orb;
    LineRenderer LR;
    // Start is called before the first frame update bbh
    void Start()
    {
        dist=100000;
       
       Agent = GetComponent<NavMeshAgent>();
       Anim = GetComponent<Animator>();
              obs = (GameObject[]) Object.FindObjectsOfType(typeof(GameObject));
        LR = GetComponent<LineRenderer>();

        for( i = 0;i<obs.Length;i++)
       {
               Debug.Log("hello21");

           if(obs[i].layer == 3){
               Players[counter] = obs[i];
               counter+=1;
           }
       } 
    }

    // Update is called once per frame
    void Update()
    {
       foreach(GameObject player in Players){
           float possibledist = Vector3.Distance(transform.position, player.transform.position);
           if(possibledist<dist){
               Target = player;
               dist = possibledist;
           }
       }
       RaycastHit hit;
       if(Physics.Raycast(Target.transform.position,-Vector3.up,out hit,100f,groundMask)){
       Agent.SetDestination(hit.point);
       }
       Anim.SetInteger("Attack",Attack);
       distance = Vector3.Distance(Target.transform.position,transform.position);
       if(distance<attackrange){
          Attack = 2;
       }
       if(Attack!=0){
           Agent.isStopped =true;

        }
        else
        {
            transform.LookAt(Target.transform.position);
            Orb.transform.LookAt(Target.transform.position);
        }
    }
    public void Blast()
    {
        RaycastHit hit;
        LR.SetPosition(0,Orb.position);
        Debug.DrawRay(Orb.transform.position, transform.forward, Color.green,100);
        if(Physics.SphereCast(Orb.transform.position,1,transform.forward,out hit,100)){
        LR.SetPosition(1,hit.point);
            Debug.Log(hit.collider.gameObject.name);

            hit.collider.gameObject.GetComponent<Health>().DoDamage(Damage);

        }
        else
        {
LR.SetPosition(1,Orb.position + transform.forward*1000);
        }
        Attack = 0;

        Agent.isStopped=false;
    }
    
}

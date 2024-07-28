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
    public float attackrange,distance;
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
               Debug.Log("hello");
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
           transform.LookAt(new Vector3(Target.transform.position.x, transform.position.y,Target.transform.position.z));}
    }
    public void Blast()
    {
        Attack = 0;
        RaycastHit hit;
        LR.SetPosition(0,Orb.position);
        if(Physics.Raycast(Target.transform.position,transform.forward,out hit,Mathf.Infinity,Playerlayer)){
        LR.SetPosition(1,hit.point);

        }else{
LR.SetPosition(1,Orb.position + transform.forward*1000);
        }
        
        Agent.isStopped=false;
    }
    
}

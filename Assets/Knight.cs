using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
  Animator Anim;
    UnityEngine.AI.NavMeshAgent Agent;
   public GameObject[] Players, obs;
    public LayerMask Playerlayer, groundMask;
    public int counter,i,Attack;
    public GameObject Target,Sword;
    float dist;
    public float attackrange,distance,Damage;
    public Transform Orb;
    LineRenderer LR;
    // Start is called before the first frame update bbh
    void Start()
    {
        dist=100000;
       
       Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
       Anim = GetComponent<Animator>();
           obs = (GameObject[]) Object.FindObjectsOfType(typeof(GameObject));


        for( i = 0;i<obs.Length;i++)
       {


           if(obs[i].layer == 3){
               Players= new GameObject[Players.Length +1];
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
          Attack = 1;
       }else{
           Attack = 0;
       }
       if(Attack!=0){
           Agent.isStopped =true;

        }
        else
        {
            transform.LookAt(Target.transform.position);

        }
    }

}

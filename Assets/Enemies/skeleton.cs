using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton : MonoBehaviour
{
    Animator Anim;
    UnityEngine.AI.NavMeshAgent Agent;
    public GameObject[] Players, obs;
    public LayerMask Playerlayer, groundMask;
    public int counter, i, Attack;
    public GameObject Target;
    public float dist,b;
    public float attackrange, distance, Damage,x;
    public bool ishielding, ischasing, isAttacking;
    // Start is called before the first frame update bbh
    void Start()
    {
        dist = 100000;
       b= GetComponent<Enemy_Health>().Cur_health;
        Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        x = Agent.speed;
        Anim = GetComponent<Animator>();
        obs = (GameObject[])Object.FindObjectsOfType(typeof(GameObject));

        for (i = 0; i < obs.Length; i++)
        {
            Debug.Log("hello21");

            if (obs[i].layer == 3)
            {
                Players[counter] = obs[i];
                counter += 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject player in Players)
        {
            float possibledist = Vector3.Distance(transform.position, player.transform.position);
            if (possibledist < dist)
            {
                Target = player;
                dist = possibledist;
            }
        }
        transform.LookAt(new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z));
        RaycastHit hit;
        if (Physics.Raycast(Target.transform.position, -Vector3.up, out hit, 100f, groundMask))
        {
            Agent.SetDestination(hit.point);
        }
        float Dist = Vector3.Distance(transform.position, Target.transform.position);
            float lookdist = Vector3.Distance(transform.position, Target.GetComponent<Combat>().lookpoint);
             ischasing = (Dist > 20);
        if (lookdist < 3f || b != GetComponent<Enemy_Health>().Cur_health) { ishielding = true; }
        else { ishielding = false; }
          isAttacking = (Dist < 6);
        if (ischasing) Chase();
        if (!isAttacking && ishielding) Block();
        if (isAttacking) Attacking();
        Anim.SetBool("Block", (!isAttacking && ishielding));
        Anim.SetBool("Attack",isAttacking);

    }
   public void Chase()
    {
        Agent.SetDestination(Target.transform.position);
        Agent.speed = 2*x;
        Attack = 0;
       
    }
    public void Block()
    {
        Agent.speed = x*0.5f;
        Attack = 1;
        Invoke("hreset", (b - GetComponent<Enemy_Health>().Cur_health) / 5);
    }
    public void Attacking()
    {
        Agent.speed = x * 0.5f;

        Anim.SetInteger("Attack",2);
    }
    void hreset()
    {
        b = GetComponent<Enemy_Health>().Cur_health;
    }
    //Chase/walk to enemy
    // Shield if player is looking at object or Damaged recently
    // Drop gaurd and attack if close enough
    //push after running in to knockdown
}

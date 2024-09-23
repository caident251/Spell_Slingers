using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golemlet : MonoBehaviour
{
    Animator Anim;
    public Vector3 rollpath;
    UnityEngine.AI.NavMeshAgent Agent;
    public GameObject[] Players, obs;
    public LayerMask Playerlayer, groundMask;
    public int counter, i, Attack;
    public GameObject Target;
    float dist;
    public float attackrange, distance,Damage,path;
    LineRenderer LR;
    
    // Start is called before the first frame update bbh
    void Start()
    {
        dist = 100000;

        Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Anim = GetComponent<Animator>();
        obs = (GameObject[])Object.FindObjectsOfType(typeof(GameObject));
        LR = GetComponent<LineRenderer>();

        for (i = 0; i < obs.Length; i++)
        {
            Debug.Log("hello21");

            if (obs[i].layer == 3)
            {
                Debug.Log("hello");
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
        RaycastHit hit;
        if (Physics.Raycast(Target.transform.position, -Vector3.up, out hit, 100f, groundMask))
        {
            Agent.SetDestination(hit.point);
        }
        Anim.SetInteger("Attack", Attack);
        distance = Vector3.Distance(Target.transform.position, transform.position);
        if (distance < attackrange)
        {
            Attack = 2;
        }
        else
        {
            Agent.speed = 5;

            Attack = 0;
            transform.LookAt(Target.transform.position);
            RaycastHit hit1;
            if (Physics.Raycast(Target.transform.position + transform.forward * path + transform.up * 20, -Vector3.up, out hit1, 100f, groundMask))
            {
                rollpath = hit1.point;
            }
        }
        if (Attack != 0)
        {

                path = 10;
                Agent.speed = 50;
                Agent.SetDestination(rollpath);
                if (Vector3.Distance(Target.transform.position, rollpath) < 5f)
                {
                    Agent.speed = 5;
                    Attack = 0;
                }
                else
                {
                    Attack = 2;
                }

            
            
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (Attack != 0)
        {
            if (other.gameObject.GetComponent<Health>() != null)
            {
                other.gameObject.GetComponent<Health>().DoDamage(Damage);
            }
        }
    }
}

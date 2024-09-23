using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DevilMite : MonoBehaviour
{
    Animator Anim;
    public Vector3 Dir;
    UnityEngine.AI.NavMeshAgent Agent;
    public GameObject[] Players, obs;
    public LayerMask Playerlayer, groundMask;
    public int counter, i, Attack;
    public GameObject Target;
    float dist;
    public bool jumped;
    public float attackrange, distance, Damage, path;

    // Start is called before the first frame update bbh
    void Start()
    {
        dist = 100000;

        Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
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
        RaycastHit hit;
        Debug.DrawRay(Target.transform.position, -Vector3.up, Color.green);
        if (Physics.Raycast(Target.transform.position, -Vector3.up, out hit, 100f,groundMask))
        {
            Agent.SetDestination(hit.point);


        }
        if (dist < attackrange)
        {
            jumped = true;
        }
        if (jumped)
        {
            Attack = 1;
            if (Agent.enabled == true)
            {
                GetComponent<Rigidbody>().AddForce(Dir *1000+Vector3.up*100);
                GetComponent<Rigidbody>().useGravity = true;

                Agent.enabled = false;
            }
        }
        else
        {
           Dir = Camera.main.gameObject.transform.position - transform.position;
            Dir.Normalize();
            Agent.enabled = true;
            Attack = 0;
            GetComponent<Rigidbody>().useGravity = false;

        }
        Anim.SetInteger("Attack", Attack);
    }
    void OnTriggerEnter(Collider other)
    {

        if (jumped)
        {
            int LayerIgnoreRaycast = LayerMask.NameToLayer("ground");
            if(other.gameObject.layer == 6)
            {
                Debug.Log(other.gameObject.name);


                jumped = false;
            }
            if (other.gameObject.GetComponent<Health>() != null)
            {

                other.gameObject.GetComponent<Health>().DoDamage(Damage);
            }
        }
    }
}

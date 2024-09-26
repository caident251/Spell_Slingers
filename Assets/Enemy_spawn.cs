using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawn : MonoBehaviour
{
    public GameObject[] Players;
    public GameObject[] Enemies;
    int counter, enemycounter;
    float radius;
    float clock;
    // Start is called before the first frame update
    void Start()
    {
            GameObject[]  obs = (GameObject[]) Object.FindObjectsOfType(typeof(GameObject));


        for(int i = 0;i<obs.Length;i++)
       {
               Debug.Log("hello21");

           if(obs[i].layer == 3){
               Players = new GameObject[Players.Length + 1];
               Players[counter] = obs[i];
               counter+=1;
           }
       } 
    }

    // Update is called once per frame
    void Update()
    {
        clock = clock + Time.deltaTime;
        if(clock >= 5f){
        foreach(GameObject Player in Players)
        {
             UnityEngine.AI.NavMeshHit hit;
           Vector3 Randompoint = Player.transform.position + Random.onUnitSphere*50;
            if (UnityEngine.AI.NavMesh.SamplePosition(Randompoint, out hit, Mathf.Infinity, UnityEngine.AI.NavMesh.AllAreas))
            {
               Instantiate(Enemies[Random.Range(0,Enemies.Length)], hit.position,Quaternion.identity);
                
            }
        }
        clock = 0;
        }
    }
}
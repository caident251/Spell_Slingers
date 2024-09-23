using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_Manaager : MonoBehaviour
{
    GameObject[] SpawnPoints;
    public static GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

        SpawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
        Instantiate(Player, SpawnPoints[0].transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

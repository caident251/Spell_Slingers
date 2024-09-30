using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorshower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int key = GetComponent<Combat>().CurSkill;
        if (Input.GetKeyDown(""+key+""))
        {

        }
    }
}

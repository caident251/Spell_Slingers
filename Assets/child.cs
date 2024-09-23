using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class child : MonoBehaviour
{
    public GameObject Activemodel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Activemodel.SetActive(true);
    }
    public void change(GameObject Model)
    {
        Activemodel.SetActive(false);
        Activemodel = Model;
        

    }
}
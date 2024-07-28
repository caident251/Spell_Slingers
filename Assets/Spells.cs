using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Spells", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class Spells : ScriptableObject

{
    public GameObject creation;
    public float damage,lifetime;
    public string Call;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : Skillmove
{

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        stats = GetComponent<Stats>();
        Lifetime = 12f;
    }

    // Update is called once per frame
    void Update()
    {
        health.DamageMultiplier = 0;
        Invoke("End", Lifetime);
    }
    void End()
    {
        health.DamageMultiplier = 1;
        Destroy(this);
    }
}

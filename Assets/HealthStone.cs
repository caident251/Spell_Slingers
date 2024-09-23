using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthStone : MonoBehaviour
{
  public  LayerMask Player;
    GameObject Text;
    
    // Start is called before the first frame update
    void Start()
    {
        Text = GameObject.FindWithTag("Note");
    }

    // Update is called once per frame
    void Update()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10f);
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.gameObject.GetComponent<Health>() != null)
            {
                Text.GetComponent<TMP_Text>().text = "Press [F] to interact";
                if (Input.GetKeyDown("f"))
                {
                    hitCollider.gameObject.GetComponent<Health>().DoDamage(transform.localScale.x * -10);
                    Text.GetComponent<TMP_Text>().text = "";
                    Destroy(gameObject);
                }
            }
            else
            {
                Text.GetComponent<TMP_Text>().text = "";

            }
        }
    }
}

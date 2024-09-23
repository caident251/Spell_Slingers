using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxHealth, CurHealth,origin, DamageMultiplier;
   public  RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GameObject.FindWithTag("HealthBar").GetComponent<RectTransform>();
        origin = rect.sizeDelta.x;
        CurHealth = MaxHealth;
    }
    void Update()
    {
        rect.sizeDelta = new Vector2((origin / (MaxHealth )) * CurHealth, rect.sizeDelta.y);
        if (CurHealth >= MaxHealth)
        {
            CurHealth = MaxHealth;
        }
    }
    // Update is called once per frame
    public void DoDamage(float damage)
    {
        CurHealth -= damage*DamageMultiplier;
    }
}

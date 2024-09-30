using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    public int Speed, Strength, Constitution, Intelligence, Magic, Attibute_points;
    public Spells Primary,CurSpell;
    public Spells Secondary;
    public int Attack, Mouse,CurSkill;
    public GameObject Wand;
    Animator Anim;
   public LayerMask notprojectile;
    public float Maxmagic, Curmagic,origin,Cost;
    public RectTransform rect;
    public Vector3 lookpoint;
    public Skill SkillI, SkillII, SkillIII;
    float Ftimer, Stimer, Ttimer;
    // Start is called before the first frame update
    void Start()
    {
        
        rect = GameObject.FindWithTag("MagicBar").GetComponent<RectTransform>();
        origin = rect.sizeDelta.x;
        Anim = Wand.GetComponent<Animator>();
        var wandScript = Wand.GetComponent<wand>();
        wandScript.Player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.SphereCast(Camera.main.gameObject.transform.position,2f, Camera.main.gameObject.transform.forward, out hit, 100f,notprojectile))
        {
            
            lookpoint = hit.point;
        }else{
            lookpoint = Camera.main.gameObject.transform.position+1000f*Camera.main.gameObject.transform.forward;
        }

        rect.sizeDelta = new Vector2((origin /( Maxmagic+Magic)) * Curmagic, rect.sizeDelta.y) ;
        if(Curmagic<(Maxmagic + Magic))        Curmagic += ( Intelligence) * Time.deltaTime;
       
        if(Input.GetMouseButton(0) && Attack ==0)
        {
            
            if (Curmagic > Primary.Cost)
            {
                Cost = Primary.Cost;
                CurSpell = Primary;
                Attack = 1;
                Debug.Log("0");

                foreach (AnimatorControllerParameter Parameter in Anim.parameters)
                {
                    Debug.Log("1");
                    if (Parameter.name == Primary.Call)
                    {
                        if (Parameter.type == AnimatorControllerParameterType.Bool)
                        {
                            Anim.SetBool(Primary.Call, Input.GetMouseButton(0));
                        }

                        if (Parameter.type == AnimatorControllerParameterType.Trigger)
                        {

                            Anim.SetTrigger(Primary.Call);
                        }
                        
                        
                    }
                }
            }
        }
        
        if (Input.GetMouseButton(1) && Attack == 0)
        {
            if (Curmagic > Secondary.Cost)
            {
                Cost = Secondary.Cost;
                Attack = 2;
                CurSpell = Secondary;
                foreach (AnimatorControllerParameter Parameter in Anim.parameters)
                {
                    if (Parameter.name == Secondary.Call)
                    {
                        if (Parameter.type == AnimatorControllerParameterType.Bool)
                        {
                            Anim.SetBool(Secondary.Call, Input.GetMouseButton(1));
                        }

                        if (Parameter.type == AnimatorControllerParameterType.Trigger)
                        {

                            Anim.SetTrigger(Secondary.Call);

                        }
                    }
                }
            }
        }

        Ftimer = Ftimer - Time.deltaTime;
        if (Input.GetKeyDown("1")&&(Ftimer<=0))
        {
            //  b = SkillI.Script;
            Type componentType = Type.GetType(SkillI.ScriptName);
            var comp = GetComponent(componentType);
            var b = gameObject.AddComponent(componentType);
            Ftimer = SkillI.Cooldown;

        }
    }

}

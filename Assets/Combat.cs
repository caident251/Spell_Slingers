using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
   public int Speed , Strength, Constitution, Intelligence,Magic, Attibute_points;
   public Spells Primary;
   public Spells Secondary;
   public int Attack;
  public GameObject Wand;
   Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
      
        Anim = Wand.GetComponent<Animator>();
        var wandScript = Wand.GetComponent<wand>();
        wandScript.Player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
                if(Input.GetMouseButton(1)&& Attack==0){
                Attack = 2;
                                    foreach(AnimatorControllerParameter Parameter in Anim.parameters){
                    if(Parameter.name == Secondary.Call){
                        if(Parameter.type == AnimatorControllerParameterType.Bool){
                        Anim.SetBool(Secondary.Call,Input.GetMouseButton(0));}
                        if(Parameter.type == AnimatorControllerParameterType.Trigger){
                        Anim.SetTrigger(Primary.Call);}
                    }
                }


                if(Input.GetMouseButton(0)){
                    
                    foreach(AnimatorControllerParameter Parameter in Anim.parameters){
                    if(Parameter.name == Primary.Call){
                        if(Parameter.type == AnimatorControllerParameterType.Bool){
                        Anim.SetBool(Primary.Call,Input.GetMouseButton(0));}
                        if(Parameter.type == AnimatorControllerParameterType.Trigger){
                        Anim.SetTrigger(Primary.Call);}
                    }
                    }
        }
    }

}}

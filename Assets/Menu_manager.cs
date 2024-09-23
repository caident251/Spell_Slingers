using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_manager : MonoBehaviour
{
   public bool SwitchedOn,n,m;
    public GameObject Player;
    public Spells prim, sec;
    public Image first, second;
    public TMP_Text Title, Description;
    public int scenenumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //            Player.GetComponent<Combat>().Primary = prim;
         //Player.GetComponent<Combat>().Secondary = sec;
        if (n)
        {
           Debug.Log("b");
            if (Title != null)
            {
                Title.text = prim.Title;
                Description.text = prim.Description;
            }
        }
        else
        {
            if (Title != null)
            {
                Title.text = sec.Title;
                Description.text = sec.Description;
            }
        }
        Player.GetComponent<Combat>().Primary = prim;
        Player.GetComponent<Combat>().Secondary = sec;
    }
    public void PlayerSpells(Image Element)
    {
        if (n) first.sprite = Element.sprite;
        if (n) first.color = Element.color;   
        if (!n) second.sprite = Element.sprite;
        if (!n) second.color = Element.color;
        
    }
    public void PlayerSpells(Spells Element)
    {
        if(n)        prim = Element;
        if(!n)      sec = Element;
    }
    public void False()
    {
        n = false;
    }
    public void True()
    {
        n = true;
    }

    public void GameLoader(TMP_Dropdown sender)
    {
        SceneManager.LoadScene(sender.value);
        scenenumber = sender.value;
        Scene_Manaager.Player =  Player;
    }
    public void Playerselect(GameObject Build)
    {

        Player = Build;
    }
}

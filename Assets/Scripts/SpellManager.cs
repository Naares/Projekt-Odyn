using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    //later we will manage spell names and guids wia spellbookmanager wich will interact with player, now just proof of concept
    public string spellName1 = "Fireball";
    public string spellName2 = "Strom";
    public string spellName3 = "Holybolt";
    public string spellName4 = "Arcanebolt";
    public string spellName5 = "Arcanebeam";

    private Object spell1;
    private Object spell2;
    private Object spell3;
    private Object spell4;
    private Object spell5;
    // Start is called before the first frame update
    void Start()
    {
        spell1 = Resources.Load("Spells/" + spellName1);
        spell2 = Resources.Load("Spells/" + spellName2);
        spell3 = Resources.Load("Spells/" + spellName3);
        spell4 = Resources.Load("Spells/" + spellName4);
        spell5 = Resources.Load("Spells/" + spellName5);                
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("CastSpell1")){
            Instantiate(spell1);
        }
        if(Input.GetButtonUp("CastSpell2")){
            Instantiate(spell2);
        }
        /*if(Input.GetButtonUp("CastSpell3")){
            Instantiate(spell3);
        }
        if(Input.GetButtonUp("CastSpell4")){
            Instantiate(spell4);
        }
        if(Input.GetButtonUp("CastSpell5")){
            Instantiate(spell5);
        }*/
    }

    //Called based on physics engine (permanent tick rate)
    void FixedUpdate() {
        
    }

    //Called last
    void LateUpdate() {
        
    }
}

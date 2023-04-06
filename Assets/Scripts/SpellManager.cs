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
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("CastSpell1")){
            Instantiate(Resources.Load("Spells/" + spellName1));
        }
        if(Input.GetButtonUp("CastSpell2")){
            Instantiate(Resources.Load("Spells/" + spellName2));
        }
    }

    //Called based on physics engine (permanent tick rate)
    void FixedUpdate() {
        
    }

    //Called last
    void LateUpdate() {
        
    }
}

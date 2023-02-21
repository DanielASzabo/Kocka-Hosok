using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kapcsolat : MonoBehaviour
{
    public static Kapcsolat egyed;
    public PHPOszekotes oszekotes { private set; get; }
    public FelhasznaloAdatok felhasznaloAdatok { private set; get; }
    private void Start()
    {

        if (egyed == null)
        {
            egyed = this;
            GameObject.DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        oszekotes = gameObject.GetComponent<PHPOszekotes>();
        if (GameObject.Find("FelhasznaloAdatok") != null)
        {
            felhasznaloAdatok = GameObject.Find("FelhasznaloAdatok").GetComponent<FelhasznaloAdatok>();
        }
        
        
    }
    
    
}

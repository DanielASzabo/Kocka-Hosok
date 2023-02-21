using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FelhasznaloAdatok : MonoBehaviour
{
    static GameObject egyed;
    public string email { get; private set; }
    public string felhNev { get; private set; }
    string jelszo;
    private void Start()
    {

        if (egyed == null)
        {
            egyed = gameObject;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        email = "";
        felhNev = "";
        jelszo = "";
    }

    public void SetAdatok(string felhNev,string email, string jelszo)
    {
        this.felhNev = felhNev;
        this.email = email;
        this.jelszo = jelszo;
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyozelmiKondicioElerve : MonoBehaviour
{
    private PalyaMenedzser palyaMenedzser;
    public string koviPalya ="";
    // Start is called before the first frame update
    void Start()
    {
        palyaMenedzser = GameObject.FindObjectOfType<PalyaMenedzser>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Jatekos"))
        {
            if (!koviPalya.Equals(""))
            {
                PontKezelo.egyed.pontokMent();
                palyaMenedzser.MenyPalya(koviPalya);
            }
            else
            {
                Debug.LogError("Nincs megadva következő pálya");
            }
            
        }
    }
}

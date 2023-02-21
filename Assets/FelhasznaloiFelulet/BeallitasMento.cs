using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeallitasMento : MonoBehaviour
{
    public Slider hangeroCsuszka;
    public PalyaMenedzser palyaMenedzser;

    private ZeneLejatszo zeneLejatszo;
    void Start()
    {
        zeneLejatszo = GameObject.FindObjectOfType<ZeneLejatszo>();
        hangeroCsuszka.value = BeallitasKezelo.HangeroGet();
    }


    void Update()
    {
        zeneLejatszo.HangeroValto(hangeroCsuszka.value);
    }


    public void MentesEsKilep()
    {
        BeallitasKezelo.HangeroSet(hangeroCsuszka.value);
        palyaMenedzser.MenyPalya("01A_Fomenu");
    }
}

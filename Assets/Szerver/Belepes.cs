using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Belepes : MonoBehaviour
{
    public InputField email;
    public InputField jelszo;
    public void Belep()
    {
        StartCoroutine(Kapcsolat.egyed.oszekotes.Belepes(email.text, jelszo.text));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Regisztracio : MonoBehaviour
{
    public InputField email;
    public InputField felhnev;
    public InputField jelszo;
    public InputField jelszo2;
    public Text hibaHely;
    public void Regisztra()
    {
        if (jelszo.text.Equals(jelszo2.text))
        {
            if (!jelszo.text.Equals("") && !felhnev.text.Equals("") && !email.text.Equals(""))
            {
                StartCoroutine(Kapcsolat.egyed.oszekotes.Regiszt(felhnev.text, email.text, jelszo.text));
            }
            else
            {
                hibaHely.text = "Kérem töltse ki a az öszes mezőt";
            }
            
        }
        else
        {
            hibaHely.text = "A jelszavak nem egyez";
        }
        
    }

}

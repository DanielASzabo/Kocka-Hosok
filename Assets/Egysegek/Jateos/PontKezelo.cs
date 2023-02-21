using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PontKezelo : MonoBehaviour
{
    public static PontKezelo egyed;
    public int pontok { private set; get; }
    public int vilagszam;
    public int palyaszam;
    private PontKiiro pontKiiro;
    void Start()
    {
        egyed = this;
        pontok = 0;
    }
    void OnEnable()
    {
        if (GameObject.FindObjectOfType<PontKiiro>() != null)
        {
            pontKiiro = GameObject.FindObjectOfType<PontKiiro>();
        }
        else
        {
            pontKiiro = null;
        }
    }

    public void pontokNovel(int menyivel)
    {
        pontok += menyivel;
        if (pontKiiro != null) 
        {
            pontKiiro.PontokValtoztat(pontok);
        }
    }

    public void pontokNullaz()
    {
        pontok = 0;
    }
    public void pontokMent()
    {
        string email = Kapcsolat.egyed.felhasznaloAdatok.email;
        StartCoroutine(Kapcsolat.egyed.oszekotes.PontokMent(email,"" + vilagszam, "" + palyaszam, "" + pontok));
    }
}

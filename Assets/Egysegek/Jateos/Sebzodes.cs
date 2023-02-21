using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sebzodes : MonoBehaviour
{
    public int eletEro = 1;
    public float erethetetlensegIdo = 1f;
    private int kezdoEletEro;
    
    private void Start()
    {
        
        kezdoEletEro = eletEro;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Sebzo") || collision.collider.tag.Equals("Ellenseg"))
        {
            Sebzodik();
        }else if (collision.collider.tag.Equals("Halal"))
        {
            Meghal();
        }

    }

    private void Sebzodik()
    {
        eletEro--;
        if (eletEro <= 0)
        {
            Meghal();
        }
    }

    private void Meghal()
    {
        JatekosKontroll jatekosKontroll =  gameObject.GetComponent<JatekosKontroll>();
        jatekosKontroll.MenyKezdopontra();
        eletEro = kezdoEletEro;
    }
    
}

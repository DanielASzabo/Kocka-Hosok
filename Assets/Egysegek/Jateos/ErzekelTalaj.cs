using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErzekelTalaj : MonoBehaviour
{
    private JatekosKontroll jatekos;
    private void Start()
    {
        jatekos = gameObject.GetComponentInParent<JatekosKontroll>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag.Equals("Talaj")) 
        {
           
            jatekos.SetFoldonVan(true);
        }else if (collision.collider.tag.Equals("Ellenseg"))
        {
            PontKezelo.egyed.pontokNovel(100);
            gameObject.GetComponentInParent<JatekosKontroll>().Pattanj(); ;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Talaj"))
        {
            jatekos.SetFoldonVan(true);
        }
        else if (collision.tag.Equals("Ellenseg"))
        {
            Debug.Log("belépet");
            gameObject.GetComponentInParent<JatekosKontroll>().Pattanj(); ;
            Destroy(collision.gameObject);
        }
    }
}

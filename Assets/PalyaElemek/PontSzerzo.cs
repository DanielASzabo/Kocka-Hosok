using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontSzerzo : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Pont"))
        {
            PontKezelo.egyed.pontokNovel(collision.GetComponent<PontErtek>().pontErtek);
            Destroy(collision.gameObject);
        }   
    }
}

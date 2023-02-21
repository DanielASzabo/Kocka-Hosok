using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllensegMozgas : MonoBehaviour
{
    public float maximalisSebbesseg = 1f;
    public bool mozogjBalra = false;
    

    private const int BALRA = 1;
    private const int JOBBRA = -1;
    private float jelenlegiSebbesseg = 0f;
    private Rigidbody2D rigidbody2;
    private void Awake()
    {}
    private void Start()
    {
        rigidbody2 = gameObject.GetComponent<Rigidbody2D>();
        rigidbody2.freezeRotation = true;
    }
    
    private void FixedUpdate()
    {
        if (mozogjBalra) {
            Mozogj(BALRA);
        }
        else
        {
            Mozogj(JOBBRA);
        }
        
       
    }
    void Mozogj(int irany)
    {
        if (irany < 0)
        {
            jelenlegiSebbesseg = maximalisSebbesseg;
            transform.localScale = new Vector3(System.Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (irany > 0)
        {
            jelenlegiSebbesseg = maximalisSebbesseg * -1;
            transform.localScale = new Vector3(-System.Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            jelenlegiSebbesseg = 0;
        }
        gameObject.transform.position = new Vector2((gameObject.transform.position.x + jelenlegiSebbesseg), gameObject.transform.position.y);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Fordulj"))
        {
            mozogjBalra = !mozogjBalra;
        }
    }
    /*public float ugrassiEro = 1f;
     * private bool foldonVan = false;
    kellhet egy késöbbi ellenfél fejlesztéséhez
    public void Ugorj()
    {
        if (foldonVan)
        {
            rigidbody2.AddForce(new Vector2(0f,ugrassiEro),ForceMode2D.Impulse);
            foldonVan = false;
        }
    }
     public void SetFoldonVan(bool erinti)
    {
        foldonVan = erinti;
    }
    */
}

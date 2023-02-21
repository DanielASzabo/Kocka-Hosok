using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JatekosKontroll : MonoBehaviour
{
    public float maximalisSebesseg = 10f;
    public float gyorsulas = 1f;
    public float ugrassiEro = 10f;
    public Transform kontrollerBelso;
    public Transform kontrollerKulso;

    
    private bool foldonVan = false;
    private bool kontrollKezd = false;
    private Vector2 aPont;
    private Vector2 bPont;
    private float jelenlegiSebbesseg = 0f;
    private Rigidbody2D rigidbody2;
    private KezdoPont kezdoPont;
    private void Awake()
    {
        kezdoPont = FindObjectOfType<KezdoPont>();
        MenyKezdopontra();
    }
    private void Start()
    {
        rigidbody2 = gameObject.GetComponent<Rigidbody2D>();
        rigidbody2.freezeRotation = true;
    }
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            aPont = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,Camera.main.transform.position.z));
            Vector2 maximumControllerHely = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2,Screen.height, Camera.main.transform.position.z));
            if (aPont.x <= maximumControllerHely.x)
            {//azért kell a -1 hogy a pálya elé kerüljön a kontroller
                kontrollerBelso.transform.position = new Vector3(aPont.x, aPont.y, -1);

                kontrollerKulso.transform.position = new Vector3(aPont.x, aPont.y,-1);
                kontrollerBelso.GetComponent<SpriteRenderer>().enabled = true;
                kontrollerKulso.GetComponent<SpriteRenderer>().enabled = true;
                kontrollKezd = true;
            }
        }
        // bugos ha getbuttont használok elrátja a joisticket ha rányomok egy második ujjal
        if(Input.touchCount> 0)
        {
            bPont = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.transform.position.z));
        }
        else
        {
            kontrollKezd = false;
            kontrollerBelso.GetComponent<SpriteRenderer>().enabled = false;
            kontrollerKulso.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void FixedUpdate()
    {
        if (kontrollKezd)
        {
            Vector2 kulombseg = bPont - aPont;
            Vector2 irany = Vector2.ClampMagnitude(kulombseg, 1.0f);
            Mozogj(irany);
            kontrollerBelso.transform.position = new Vector3(aPont.x + irany.x, aPont.y + irany.y,-1);

        }
        else if (!kontrollKezd && jelenlegiSebbesseg !=0)
        {
            Lassulj();
        }
        /*
         * rigidbody2D.freezeRotation = true; ha kinematikusra rakom akkor ez kell
         * 
    public float gravitacio = 0.1f;
         * if (!foldonVan)
        {
            esesiSebbeseg -= gravitacio;
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + esesiSebbeseg);
        }*/
    }
    void Mozogj(Vector2 irany)
    {
        // 0 és 1 közzöt a vezérlő érzékenysége
        float erzekenyseg = 0.2f;
        if (irany.x < erzekenyseg*-1)
        {
            jelenlegiSebbesseg = maximalisSebesseg *-1; 
            transform.localScale = new Vector3(-System.Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            /*if (jelenlegiSebbesseg > maximalisSebbesseg * -1)
            {
                jelenlegiSebbesseg -= gyorsulas;
            }*/
        }
        else if (irany.x > erzekenyseg)
        {
            jelenlegiSebbesseg = maximalisSebesseg;
            transform.localScale = new Vector3(System.Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            /*if (jelenlegiSebbesseg < maximalisSebbesseg)
            {
                jelenlegiSebbesseg += gyorsulas;
            }*/

        }

        if (irany.x > erzekenyseg || irany.x < erzekenyseg)
        {
            gameObject.transform.position = new Vector2((gameObject.transform.position.x + jelenlegiSebbesseg), gameObject.transform.position.y);
        }
    }
    void Lassulj()
    {
        int sebessegOszto = 20;
        if (jelenlegiSebbesseg != 0)
        {
            if (jelenlegiSebbesseg > 0)
            {
                if (jelenlegiSebbesseg - gyorsulas < 0)
                {
                    jelenlegiSebbesseg = 0;
                }
                else
                {
                    jelenlegiSebbesseg -= jelenlegiSebbesseg/ sebessegOszto + gyorsulas;
                }
            }
            else
            {
                if (jelenlegiSebbesseg + gyorsulas > 0)
                {
                    jelenlegiSebbesseg = 0;
                }
                else
                {
                    jelenlegiSebbesseg += (jelenlegiSebbesseg / sebessegOszto) * -1 + gyorsulas;
                }
            }
        }
        gameObject.transform.position = new Vector2((gameObject.transform.position.x + jelenlegiSebbesseg), gameObject.transform.position.y);

    }
    public void Ugorj()
    {
        if (foldonVan)
        {
            rigidbody2.AddForce(new Vector2(0f,ugrassiEro),ForceMode2D.Impulse);
            foldonVan = false;
        }
    }
    public void Pattanj()
    {
        rigidbody2.AddForce(new Vector2(0f, ugrassiEro), ForceMode2D.Impulse);
    }
    public void SetFoldonVan(bool erinti)
    {
        foldonVan = erinti;
    }

    public void MenyKezdopontra()
    {
        gameObject.transform.position = kezdoPont.transform.position;
    }

}   

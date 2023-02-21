using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;
using UnityEngine.UI;

public class FelhasznaloPontok : MonoBehaviour
{
    private string vilag;
    private string palya;
    private string pontszam;
    Action<string> _callback;

    void Start()
    {
        PontokCsinalo();
        
        
    }

     public void PontokCsinalo()
    {
        if (GameObject.Find("FelhasznaloAdatok") != null && !Kapcsolat.egyed.felhasznaloAdatok.email.Equals(""))
        {
            string email = Kapcsolat.egyed.felhasznaloAdatok.email;
            StartCoroutine(Kapcsolat.egyed.oszekotes.JatekosPontok(email, _callback = (jsonArray) =>
            {
                StartCoroutine(PontokKiir(jsonArray));
            }));
            
        }
        else
        {
            GameObject szovegDoboz = Instantiate(Resources.Load("PontszamKiiras")) as GameObject;
            szovegDoboz.transform.SetParent(this.transform);
            szovegDoboz.transform.localScale = Vector2.one;
            szovegDoboz.transform.localPosition = Vector2.zero;

            szovegDoboz.GetComponent<Text>().text = "Kérem jelentkezzenbe";
        }
        
    }

    IEnumerator PontokKiir(string json)
    {
        /*Debug.Log(JSONArray.Parse(json).ToString() + "ez a json arrays"); eredmény jsonArray = JSONArray.Parse(json)
        JSONArray jsonArray = new JSONArray();
        jsonArray = JSONArray.Parse(json) as JSONArray;
        Debug.Log(jsonArray.ToString()); eredmény null*/

        //json = "{ \"0\":{ \"vilag\":\"1\",\"palya\":\"2\",\"pontok\":\"220\"},\"1\":{ \"vilag\":\"10\",\"palya\":\"20\",\"pontok\":\"22000\"} }";
        // ha csak var ként használom nem null lesz az objektum

        //Debug.Log(jsonArray.ToString());
        var jsonArray = JSONArray.Parse(json);
        int n = jsonArray.Count;
        float maximumPozicio = 300;
        float minimumPozicio = -300;
        float yPoz = 0;
        float szovegdobozSzelleseg = 0;
        for (int i = 0; i<n; i++ )
        {
            string vilag = jsonArray[i].AsObject["vilag"];
            string palya = jsonArray[i].AsObject["palya"];
            string pontok = jsonArray[i].AsObject["pontok"];
            GameObject szovegDoboz = Instantiate(Resources.Load("PontszamKiiras")) as GameObject ;
            szovegdobozSzelleseg = szovegDoboz.GetComponent<RectTransform>().rect.height;
            Vector2 pozicio = new Vector2();
            yPoz = maximumPozicio - szovegdobozSzelleseg * this.transform.childCount;
            if (yPoz>= minimumPozicio)
            {
                pozicio.Set(0, yPoz);
                szovegDoboz.transform.SetParent(this.transform);
                szovegDoboz.transform.localScale = Vector2.one;
                szovegDoboz.transform.localPosition = pozicio;
                szovegDoboz.GetComponent<Text>().text = "Világ: " + vilag + " Pálya: " + palya + " Pontszám: " + pontok;
            }
            
        }
        yield return null;
    }
}

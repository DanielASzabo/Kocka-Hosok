using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
public class PHPOszekotes : MonoBehaviour
{
    //string utvonal = "http://localhost/KockaHosokPHP/";
    string utvonal = "http://tanulo1.szf1a.oktatas.szamalk-szalezi.hu/KockaHosokPHP/";
    public IEnumerator SzerezdAdatok()
    {
        string url = utvonal + "index.php";
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if (!string.IsNullOrEmpty(www.error)) 
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log(www.downloadHandler.text);

                //byte[] results = www.downloadHandler.data;
            }

        }
    }

    public IEnumerator Belepes(string email,string jelszo)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("jsz", jelszo);
        string url = utvonal + "belepes.php";
        Debug.Log(url);
        using (UnityWebRequest www = UnityWebRequest.Post(url,form))
        {
            yield return www.SendWebRequest();
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
            }
            else
            {
                string felhnev = www.downloadHandler.text;
                
                if (!felhnev.Contains("-1") && !felhnev.Contains("Töltse ki az összes mezőt!"))
                {
                    Kapcsolat.egyed.felhasznaloAdatok.SetAdatok(felhnev, email, jelszo);
                }
                else
                {
                    Debug.Log("hibás email vagy jelszó");
                }
                
            }

        }
    }

    public IEnumerator Regiszt(string felhNev,string email,string jelszo)
    {
        WWWForm form = new WWWForm();
        form.AddField("jsz", jelszo);
        form.AddField("email", email);
        form.AddField("nev", felhNev);
        string url = utvonal + "regisztracio.php";
        using (UnityWebRequest www = UnityWebRequest.Post(url,form))
        {
            yield return www.SendWebRequest();
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log(www.downloadHandler.text);

                //byte[] results = www.downloadHandler.data;
            }

        }
    }
    // callbackes nem az én ötletem
    public IEnumerator JatekosPontok(string email,Action<string> callback)
    {
        Debug.Log(email);
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        string url = utvonal + "felhasznalopontok.php";
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log(www.downloadHandler.text);
                string jsonAdatok = www.downloadHandler.text;
                callback(jsonAdatok);
            }

        }
    }


    public IEnumerator PontokMent(string email, string vilag, string palya, string pontok)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("vilag", vilag);
        form.AddField("palya", palya);
        form.AddField("pontok", pontok);
        string url = utvonal + "pontokMent.php";
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }

        }
    }
}

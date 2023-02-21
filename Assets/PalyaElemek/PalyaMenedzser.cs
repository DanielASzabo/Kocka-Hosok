using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PalyaMenedzser : MonoBehaviour
{
    public float KoviPalyaMpMulva = 0;
    public string PalyaNev = "";
    // Start is called before the first frame update
    void Start()
    {
        
        if (KoviPalyaMpMulva > 0f)
        {
            // ha nincs név a kövi build indexüre megy
            if (PalyaNev.Equals("")) 
            {
                
                Invoke("MenyKoviPalya",KoviPalyaMpMulva);
            } 
            else 
            {
                //paraméter átadás nem lehetséges invokeban
                Invoke("AdatAtado", KoviPalyaMpMulva);
            }
            
        }
    }
    
    private void AdatAtado()
    {
        MenyPalya(PalyaNev);
    }
    public void MenyKoviPalya()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void MenyPalya(string palyaNev)
    {
        SceneManager.LoadScene(palyaNev);
    }
    public void Kilepes()
    {
        Application.Quit();
    }
}

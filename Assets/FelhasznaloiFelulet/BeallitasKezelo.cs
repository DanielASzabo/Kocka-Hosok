using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeallitasKezelo : MonoBehaviour
{
    private const string HANGERO_KULCS = "hangero";


    public static void HangeroSet(float hangero)
    {
        if (hangero>=0f && hangero <=1f)
        {
            PlayerPrefs.SetFloat(HANGERO_KULCS, hangero);
        }
        else
        {
            Debug.LogError("Hibás hangerő érték");
        }
        
    }
    public static float HangeroGet()
    {
        if (PlayerPrefs.HasKey(HANGERO_KULCS))
        {
            return PlayerPrefs.GetFloat(HANGERO_KULCS);
        }
        else
        {
            HangeroSet(0.75f);
            return HangeroGet();
        }
        
    }
}

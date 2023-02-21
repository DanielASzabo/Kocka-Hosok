using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontKiiro : MonoBehaviour
{
    private Text pontok;
    private string elotag = "Pontok: ";
    private int jelenlegiPont = 0;
    void Start()
    {
        pontok = gameObject.GetComponent<Text>();
        pontok.text = elotag + jelenlegiPont;
    }

    public void PontokValtoztat(int pontErtek)
    {
        jelenlegiPont = pontErtek;
        pontok.text = elotag + jelenlegiPont;
    }

}

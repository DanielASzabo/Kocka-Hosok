using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZeneLejatszo : MonoBehaviour
{
    public AudioClip[] zenek;
    AudioSource zeneLejatszo;
    static GameObject ez;
    private int jelenlegiZene = -1;

    private void Awake()
    {
        if (ez == null)
        {
            ez = gameObject;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += BetoltotPalya;
    }
    private void Start()
    {
        HangeroValto(BeallitasKezelo.HangeroGet());
    }
    private void BetoltotPalya(Scene szinpad, LoadSceneMode szinpadMod)
    {
        zeneLejatszo = gameObject.GetComponent<AudioSource>();
        int palyaIndex = szinpad.buildIndex;
        if (zenek.Length > palyaIndex)
        {
            if (zenek[palyaIndex] && jelenlegiZene != palyaIndex)
            {
                jelenlegiZene = palyaIndex;
                zeneLejatszo.clip = zenek[palyaIndex];
                zeneLejatszo.loop = true;
                zeneLejatszo.Play();
            }
        }
        else
        {
            Debug.Log("növeld meg a zenék méretét");
        }
    }

    public void HangeroValto(float hangero)
    {
        zeneLejatszo.volume = hangero;
    }
    
}

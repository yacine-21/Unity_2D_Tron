using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlayers : MonoBehaviour
{
    public GameObject panelP3;
    public GameObject panelP4;
    public GameObject p3;
    public GameObject p4;
    void Awake()
    {
        int nbPlayers = PlayerPrefs.GetInt("nbPlayers");
        if(nbPlayers == 3)
        {
            p3.SetActive(true);
            panelP3.SetActive(true);
        }
        if (nbPlayers == 4)
        {
            p3.SetActive(true);
            p4.SetActive(true);
            panelP3.SetActive(true);
            panelP4.SetActive(true);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    bool optionsOpen = false;
    public GameObject optionsMenu;
    public Text nbPlayers;
    public Slider nbPlayersSlider;

    private void Start()
    {
        int nb = PlayerPrefs.GetInt("nbPlayers");
        nbPlayersSlider.value = nb;
        Camera.main.GetComponent<cam>().GetComponent<AudioSource>().Stop();
    }
    public void Play()
    {
        /*Application.LoadLevel(1);*/
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        if (!optionsOpen)
        {
            optionsOpen = true;
        }
        else
        {
            optionsOpen = false;
        }
        optionsMenu.SetActive(optionsOpen);
    }

    public void SetPlayers()
    {
        nbPlayers.text = nbPlayersSlider.value.ToString();
        PlayerPrefs.SetInt("nbPlayers", (int)nbPlayersSlider.value);
    }

}

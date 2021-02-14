using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    bool isPaused = false;
    gameManager gm;
    AudioSource sound;
    public GameObject PauseMenu;

    private void Start()
    {
        sound = Camera.main.GetComponent<cam>().GetComponent<AudioSource>();
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!isPaused)
            {
                isPaused = true;
                gm.gameSpeed = 0;
                sound.Pause();
            }
            else
            {
                isPaused = false;
                gm.gameSpeed = 1;
                sound.Play();
            }
            PauseMenu.SetActive(isPaused);
        }
    }
}

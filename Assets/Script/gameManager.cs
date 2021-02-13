using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    int nbAlivePlayers;
    [HideInInspector]
    public float gameSpeed = 1;
    public int[] scores;
    PlayerMove[] players;

    private void Start()
    {
        players = FindObjectsOfType<PlayerMove>();
        nbAlivePlayers = players.Length;
    }

    public void killPlayer()
    {
        nbAlivePlayers--;
        if(nbAlivePlayers <= 1)
        {
            gameSpeed = 0;
            GetWinner();
        }
    }

    void GetWinner()
    {
        foreach(PlayerMove p in players)
        {
            if (p.isAlive)
            {
                switch(p.playerName)
                {
                    case "P1":
                        scores[0]++;
                        GameObject.Find("p1score").GetComponent<Text>().text = "Score : 00" + scores[0];
                        break;
                    case "P2":
                        scores[1]++;
                        GameObject.Find("p2score").GetComponent<Text>().text = "Score : 00" + scores[1];
                        break;
                    case "P3":
                        scores[2]++;
                        GameObject.Find("p3score").GetComponent<Text>().text = "Score : 00" + scores[2];
                        break;
                    case "P4":
                        scores[3]++;
                        GameObject.Find("p4score").GetComponent<Text>().text = "Score : 00" + scores[3];
                        break;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // Declaration des variables
    Rigidbody2D rb; // Rigidbody du joueur
    public int speed; // Vitesse de déplacement
    Vector2 dir; // Direction du joueur
    GameObject wallPrefab; // Mur à instancier
    Vector2 lastPos;
    Collider2D lastWallCol;
    int wallSize = 1;
    public GameObject boomParticules;
    bool canActivateBoost = true;
    public string playerName;

    // Start is called before the first frame update
    void Start()
    {
        dir = Vector2.up; // Direction par défaut
        rb = GetComponent<Rigidbody2D>(); // Récupération du rb
        rb.velocity = dir * speed; // Mouvement de depart
        // Récupération dynamique du mur à instancier
        wallPrefab = Resources.Load("Wall" + gameObject.tag) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        HandleKeys();
        SetLastWallSize(lastWallCol, lastPos, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != lastWallCol)
        {
            Instantiate(boomParticules, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    // Fonctions custom
    private void HandleKeys()
    {   
        // Gestion des touches de direction
        if (Input.GetButtonDown(playerName+"UP"))
        {
            if(dir != Vector2.down)
            {
                dir = Vector2.up;
                CreteWall();
            }
        } 
        else if (Input.GetButtonDown(playerName+"DOWN"))
        {
            if(dir != Vector2.up)
            {
                dir = Vector2.down;
                CreteWall();
            }
        }
        else if (Input.GetButtonDown(playerName+"LEFT"))
        {
            if (dir != Vector2.right)
            {
                dir = Vector2.left;
                CreteWall();
            }
        }
        else if (Input.GetButtonDown(playerName+"RIGHT"))
        {
            if (dir != Vector2.left)
            {
                dir = Vector2.right;
                CreteWall();
            }
        }
        else if (Input.GetButtonDown(playerName+"BOOST"))
        {
            if (canActivateBoost == true)
            {
                StartCoroutine("ActivateBoost");
            }
        }

        // On applique le mouvement demandé
        rb.velocity = dir * speed;
    }

    IEnumerator ActivateBoost()
    {
        canActivateBoost = false;
        speed += 5;
        yield return new WaitForSeconds(3);
        speed -= 5;
    }
    private void CreteWall()
    {
        lastPos = transform.position;
       GameObject go = Instantiate(wallPrefab, transform.position, Quaternion.identity);
        lastWallCol = go.GetComponent<Collider2D>();
    }

    private void SetLastWallSize(Collider2D col, Vector2 posStart, Vector2 posEnd)
    {
        if (col)
        {
            col.transform.position = posStart + (posEnd - posStart) / 2;
            float size = Vector2.Distance(posEnd, posStart);
            if (posStart.x != posEnd.x)
            {
                col.transform.localScale = new Vector2(size + wallSize, wallSize);
            }
            else
            {
                col.transform.localScale = new Vector2(wallSize, size + wallSize);
            }
        }
    }
}

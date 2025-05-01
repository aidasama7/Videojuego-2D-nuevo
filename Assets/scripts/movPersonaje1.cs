using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movPersonaje : MonoBehaviour
{
    public float velocidad = 5f;
    private float multiplicador = 5f;
    private float multiplicadorSalto = 5f;

    float movTeclas;

    private bool puedoSaltar = true;
    private bool activaSaltoFixed = false;

    public static bool miraDerecha = true;

    private Rigidbody2D rb;
    private Animator animatorController;

    public GameObject respawn;
    private bool primerRespawnHecho = false;

    bool soyAzul;

    public PlataformaEnMovimiento plataforma;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<Animator>();
        respawn = GameObject.Find("Respawn");
        Respawnear();
    }

    void Update()
    {
        movTeclas = Input.GetAxis("Horizontal");

        if (GameManager.estoyMuerto) return;

        // Flip sprite
        if (movTeclas < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            miraDerecha = false;
        }
        else if (movTeclas > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            miraDerecha = true;
        }

        // Animación caminando
        animatorController.SetBool("activaCamina", movTeclas != 0);

        // Comprobar si está tocando el suelo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        Debug.DrawRay(transform.position, Vector2.down, Color.magenta);
        puedoSaltar = hit.collider != null;

        // Saltar
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            activaSaltoFixed = true;
        }

        // Si cae fuera de la pantalla
        if (transform.position.y <= -7)
        {
            AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fxDead);
            Respawnear();
        }

        if (GameManager.vidas <= 0)
        {
            GameManager.estoyMuerto = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movTeclas * multiplicador, rb.velocity.y);

        if (activaSaltoFixed)
        {
            rb.AddForce(new Vector2(0, multiplicadorSalto), ForceMode2D.Impulse);
            activaSaltoFixed = false;
        }
    }

    public void Respawnear()
    {
        if (plataforma != null)
        {
            Debug.Log("Reiniciando plataforma...");
            plataforma.ReiniciarPosicion();
        }

        if (primerRespawnHecho)
        {
            GameManager.vidas--;
            Debug.Log("vida perdida, quedan: " + GameManager.vidas);
        }
        else
        {
            primerRespawnHecho = true;
            Debug.Log("primer respawn sin perder vida");
        }

        transform.position = respawn.transform.position;
    }
    public void CambiarColor()
    {
        if (soyAzul)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            soyAzul = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
            soyAzul = true;
        }
    }
}
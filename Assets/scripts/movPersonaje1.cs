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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorController = this.GetComponent<Animator>();
        respawn = GameObject.Find("Respawn");
        Respawnear();
    }

    // Update is called once per frame
    void Update()
    {
        movTeclas = Input.GetAxis("Horizontal");

        if(GameManager.estoyMuerto) return;

        float miDeltaTime = Time.deltaTime;
        Debug.Log(Time.deltaTime);

        // Movimiento con Rigidbody2D
        movTeclas = Input.GetAxis("Horizontal"); //(a -1 - d 1f)
        //float movTeclasY = Input.GetAxis("Vertical"); //(a -1 - d 1f)


        // Flip sprite
        if (movTeclas < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            miraDerecha = false;
        }
        else if (movTeclas > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
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
            //PuedoSaltarFixed
            /*
            rb.AddForce(
                new Vector2(0, multiplicadorSalto),
                ForceMode2D.Impulse
            );
            */
        }

        // Si cae de la pantalla
        if (transform.position.y <= -7)
        {
            Respawnear();
        }


        // 0 vidas

        if(GameManager.vidas <= 0)
        {
            GameManager.estoyMuerto = true;

        }
    }

    void FixedUpdate(){

        rb.velocity = new Vector2(movTeclas*multiplicador, rb.velocity.y);

        if(activaSaltoFixed == true){
            rb.AddForce(
                new Vector2(0, multiplicadorSalto),
                ForceMode2D.Impulse
            );
            activaSaltoFixed = false;
        }

    }

    public void Respawnear(){

        Debug.Log("vidas: "+GameManager.vidas);
        GameManager.vidas = GameManager.vidas -1;
        Debug.Log("vidas: "+GameManager.vidas);

        transform.position = respawn.transform.position;
    }
}
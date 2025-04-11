using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Collections;
using UnityEngine;

public class movPersonaje : MonoBehaviour
{
  
  public float multiplicador = 5f;
  public float multiplicadorSalto = 5f;

  private bool puedoSaltar = true;

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
      float movTeclas = Input.GetAxis("Horizontal"); //(a -1f - d 1f)  
      //float movTeclasY = Input.GetAxis("Vertical"); //(a -1f - d 1f)  
      
      //aproximación 1
 /*     transform.position = new UnityEngine.Vector3(
        transform.position.x+(movTeclas/100),
        transform.position.y,
        transform.position.z
    
      ); */

      float miDeltaTime = Time.deltaTime;

      Debug.Log(Time.deltaTime);

      /*
      transform.Translate(
        movTeclas*(Time.deltaTime*multiplicador),
        0,
        0
      );
      */

      //movimiento personaje

      rb.velocity = new UnityEngine.Vector2(movTeclas*multiplicador, rb.velocity.y);

      //izq
      if(movTeclas < 0){
          this.GetComponent<SpriteRenderer>().flipX = true;
      }else if(movTeclas > 0){
      //dcha
         this.GetComponent<SpriteRenderer>().flipX = false;
      }

      //ANIMACION WALKING
      if(movTeclas != 0){
          animatorController.SetBool("activaCamina", true);
      }else{
          animatorController.SetBool("activaCamina", false);
      }

      
      




      RaycastHit2D hit = Physics2D.Raycast(transform.position, UnityEngine.Vector2.down, 0.5f);
      Debug.DrawRay(transform.position,UnityEngine.Vector2.down,Color.magenta);

      if(hit){
          puedoSaltar = true;
          Debug.Log(hit.collider.name);
      }else{
          puedoSaltar = false;
      }


      //salto
      if(Input.GetKeyDown(KeyCode.Space) && puedoSaltar){
          rb.AddForce(
            new UnityEngine.Vector2(0,multiplicadorSalto),
            ForceMode2D.Impulse
          );
          puedoSaltar = false;

      }
    }


    /*
    void OnCollisionEnter2D(){
      puedoSaltar = true;
      Debug.Log("Collision");
    }
    */


    public void Respawnear(){
        transform.position = respawn.transform.position;
    }




}

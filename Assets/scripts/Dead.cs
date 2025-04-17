using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    private GameObject personajeGO;
    private movPersonaje personajeScript;

    // Start is called before the first frame update
    void Start()
    {
        personajeGO = GameObject.FindWithTag("Player");
        
        if (personajeGO != null)
        {
            personajeScript = personajeGO.GetComponent<movPersonaje>();

            if (personajeScript == null)
            {
                Debug.LogError("No se encontró el componente movPersonaje en el GameObject 'Personaje'");
            }
        }
        else
        {
            Debug.LogError("No se encontró el GameObject llamado 'Personaje'");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
{
    if (col.CompareTag("Player") && personajeScript != null)
    {
        Debug.Log("¡Tocó las spikes!");
        personajeScript.Respawnear();
    }
}
}
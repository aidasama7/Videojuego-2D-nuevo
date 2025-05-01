using UnityEngine;

public class SonidoCofre : MonoBehaviour
{
    private bool sonidoReproducido = false;  

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger activado por: " + other.gameObject.name);

        if (other.CompareTag("Player") && !sonidoReproducido)
        {
            AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fxCofre); 

            sonidoReproducido = true;
            Debug.Log("Sonido de cofre reproducido.");
        }
    }
}
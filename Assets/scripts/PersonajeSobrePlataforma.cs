using UnityEngine;

public class PersonajeSobrePlataforma : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            // Personaje es hijo de la plataforma
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            // Quitamos relación padre-hijo al bajar de la plataforma
            transform.parent = null;
        }
    }
}
using UnityEngine;

public class ActivadorPlataforma : MonoBehaviour
{
    public PlataformaEnMovimiento plataforma;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            plataforma.ActivarMovimiento(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            plataforma.ActivarMovimiento(false);
        }
    }
}
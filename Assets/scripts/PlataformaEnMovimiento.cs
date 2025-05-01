using UnityEngine;

public class PlataformaEnMovimiento : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction = Vector2.right;

    private bool mover = false;
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position; 
    }

    void Update()
    {
        if (mover)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    public void ActivarMovimiento(bool activar)
    {
        mover = activar;
    }

    public void ReiniciarPosicion()
    {
        mover = false;
        transform.position = posicionInicial; // Vuelve a la posición original
    }
}
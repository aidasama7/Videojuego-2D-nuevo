using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int vidas = 3;
    public static int puntos = 0;
    private GameObject vidasText;

    public static int muertes = 0;

    public static bool estoyMuerto = false;

    
    // Start is called before the first frame update
    void Start()
    {
        vidasText = GameObject.Find("VidasText");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Puntos:"+puntos);
        Debug.Log("Deads:"+muertes);

        vidasText.GetComponent<TextMeshProUGUI>().text = vidas.ToString();

    }
}

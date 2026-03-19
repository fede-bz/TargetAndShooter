using UnityEngine;

public class TemporizadorVida : MonoBehaviour
{
    public float tiempoDeVida = 5f; // Empieza en 5 segundos

    void Start()
    {
        Debug.Log("Tiempo de vida inicial: " + tiempoDeVida + " segundos");
    }

    void Update()
    {
        // Disminuye el tiempo cada frame
        tiempoDeVida -= Time.deltaTime;

        // Muestra el tiempo restante cada segundo (aproximadamente)
        if (Time.frameCount % 60 == 0) // Cada 60 frames
        {
            Debug.Log("Tiempo restante: " + tiempoDeVida.ToString("F2") + " segundos");
        }

        // Cuando llega a 0 o menos
        if (tiempoDeVida <= 0)
        {
            Debug.Log("¡Tiempo agotado! El objeto se destruye");
            Destroy(gameObject);
        }
    }
}
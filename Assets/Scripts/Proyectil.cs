using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 10f;
    public float tiempoDeVida = 3f;

    void Start()
    {
        Debug.Log("Proyectil disparado!");
    }

    void Update()
    {
        // EJERCICIO 3: Movimiento hacia adelante con Translate
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

        // EJERCICIO 2: Tiempo de vida disminuye
        tiempoDeVida -= Time.deltaTime;

        if (tiempoDeVida <= 0)
        {
            Debug.Log("Proyectil destruido por tiempo");
            Destroy(gameObject);
        }
    }

    // EJERCICIO 4: Colisión que desactiva objetos
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("¡Proyectil golpeó: " + collision.gameObject.name + "!");

        // Buscar el objeto raíz (padre más alto)
        Transform objetivo = collision.transform;

        // Subir en la jerarquía hasta encontrar el objeto raíz
        while (objetivo.parent != null)
        {
            objetivo = objetivo.parent;
        }

        Debug.Log("Destruyendo objeto raíz: " + objetivo.name);

        // Desactivar el objeto raíz completo (el soldado entero)
        objetivo.gameObject.SetActive(false);

        // Destruir el proyectil
        Destroy(gameObject);
    }
}
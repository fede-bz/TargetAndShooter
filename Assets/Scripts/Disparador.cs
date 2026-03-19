using UnityEngine;

public class Disparador : MonoBehaviour
{
    public GameObject prefabProyectil;
    public Transform puntoDisparo;
    public Camera camaraPrincipal;
    public float cooldownDisparo = 0.5f;

    private float tiempoUltimoDisparo = 0f;

    void Start()
    {
        // Si no asignaste la cámara manualmente, busca la Main Camera
        if (camaraPrincipal == null)
        {
            camaraPrincipal = Camera.main;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= tiempoUltimoDisparo + cooldownDisparo)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    void Disparar()
    {
        Debug.Log("¡Disparo!");

        if (prefabProyectil == null || puntoDisparo == null)
        {
            Debug.LogError("Falta asignar prefab o punto de disparo");
            return;
        }

        // Crear el proyectil en el punto de disparo
        GameObject bala = Instantiate(prefabProyectil, puntoDisparo.position, Quaternion.identity);

        // Calcular dirección hacia el CENTRO de la pantalla (donde está la mira)
        Ray ray = camaraPrincipal.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 direccion = ray.direction;

        // Rotar la bala para que apunte en esa dirección
        bala.transform.rotation = Quaternion.LookRotation(direccion);

        Debug.Log("Proyectil disparado hacia el centro de la pantalla");
    }
}
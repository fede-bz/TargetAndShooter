using UnityEngine;

public class EnemigoAvanzar : MonoBehaviour
{
    public Transform jugador; // Referencia al jugador
    public float velocidad = 2f; // Velocidad de avance
    public float distanciaMinima = 2f; // Se detiene a esta distancia

    private Animator animator;

    void Start()
    {
        // Obtener el Animator del soldado
        animator = GetComponentInChildren<Animator>();

        // Si no asignaste el jugador manualmente, buscarlo
        if (jugador == null)
        {
            GameObject jugadorObj = GameObject.Find("Jugador");
            if (jugadorObj != null)
            {
                jugador = jugadorObj.transform;
            }
        }

        // Activar animación de combat_run
        if (animator != null)
        {
            animator.SetBool("isRunning", true);
            // O si usa trigger:
            // animator.SetTrigger("combat_run");
        }
    }

    void Update()
    {
        if (jugador == null) return;

        // Calcular distancia al jugador
        float distancia = Vector3.Distance(transform.position, jugador.position);

        // Si está lejos, avanzar hacia el jugador
        if (distancia > distanciaMinima)
        {
            // Calcular dirección hacia el jugador
            Vector3 direccion = (jugador.position - transform.position).normalized;

            // Solo moverse en X y Z (no en Y para que no vuelen)
            direccion.y = 0;

            // Mover hacia el jugador
            transform.position += direccion * velocidad * Time.deltaTime;

            // Rotar para mirar al jugador
            transform.LookAt(new Vector3(jugador.position.x, transform.position.y, jugador.position.z));
        }
        else
        {
            // Si llegó cerca, detener animación (opcional)
            if (animator != null)
            {
                animator.SetBool("isRunning", false);
            }
        }
    }
}
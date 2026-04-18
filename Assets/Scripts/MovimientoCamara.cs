using UnityEngine;
public class MovimientoCamara : MonoBehaviour
{
    public float sensibilidad = 2f;
    public Transform cuerpoJugador;
    private float rotacionX = 0f;
    private float rotacionY = 0f;
    private bool camaraActiva = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        rotacionX = 0f;
        rotacionY = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            camaraActiva = false;
        }

        // Activar cámara con click izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            camaraActiva = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (!camaraActiva) return; // No mover hasta que el jugador clickee

        float mouseX = Input.GetAxis("Mouse X") * sensibilidad;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -60f, 60f);

        rotacionY += mouseX;
        rotacionY = Mathf.Clamp(rotacionY, -60f, 60f); // 180° en total

        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        cuerpoJugador.rotation = Quaternion.Euler(0f, rotacionY, 0f);
    }
}
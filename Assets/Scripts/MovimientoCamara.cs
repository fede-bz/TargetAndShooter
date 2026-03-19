using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public float sensibilidad = 2f;
    public Transform cuerpoJugador;

    private float rotacionX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Resetear rotación de la cámara al empezar
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        rotacionX = 0f;
    }

    void Update()
    {
        // Presionar ESC para desbloquear cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Obtener movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad;

        // Rotar cámara arriba/abajo
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f); // Limitar a 90 grados

        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);

        // Rotar cuerpo del jugador izquierda/derecha
        cuerpoJugador.Rotate(Vector3.up * mouseX);
    }
}
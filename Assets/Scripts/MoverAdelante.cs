using UnityEngine;

public class MoverAdelante : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        // Mueve el objeto hacia adelante (eje Z positivo)
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }
}
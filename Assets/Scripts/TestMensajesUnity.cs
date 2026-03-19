using UnityEngine;

public class TestMensajesUnity : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("AWAKE: Se ejecuta primero, antes de Start");
    }

    void Start()
    {
        Debug.Log("START: Se ejecuta una vez al inicio, después de Awake");
    }

    void Update()
    {
        Debug.Log("UPDATE: Se ejecuta cada frame");
    }

    void FixedUpdate()
    {
        Debug.Log("FIXED UPDATE: Se ejecuta en intervalos fijos (física)");
    }

    void LateUpdate()
    {
        Debug.Log("LATE UPDATE: Se ejecuta después de todos los Update");
    }

    void OnEnable()
    {
        Debug.Log("ON ENABLE: Se ejecuta cuando el objeto se activa");
    }

    void OnDisable()
    {
        Debug.Log("ON DISABLE: Se ejecuta cuando el objeto se desactiva");
    }
}
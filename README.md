# Target Shooter / FPS - Clase 5

**Alumno:** Federico Bazán  
**Fecha:** Abril 2026  
**Curso:** Diplomatura en Desarrollo de Videojuegos - UNC

---

## 🎮 Descripción

Shooter en primera persona donde soldados enemigos corren hacia el jugador y éste debe dispararles proyectiles para eliminarlos. El jugador está estático con un arma que dispara proyectiles físicos.

Ambientación: **Fortaleza oscura en zona de guerra** — estilo low poly con tono nocturno dramático, arquitectura de dungeon/fortaleza, niebla gris azulada y iluminación lateral rasante.

---

## 🕹️ Controles

- **Mouse**: Apuntar (mover vista) — se activa con el primer click
- **Click Izquierdo**: Disparar proyectil / Activar cámara
- **ESC**: Desbloquear cursor

---

## ✅ Lo que había (Hecho en Clase 5)

### Scripts principales:
- `Proyectil.cs` - Manejo del proyectil
- `Disparador.cs` - Sistema de disparo
- `EnemigoAvanzar.cs` - Movimiento de enemigos hacia jugador
- `MoverAdelante.cs` - Movimiento básico hacia adelante
- `MovimientoCamara.cs` - Control de cámara FPS
- `TemporizadorVida.cs` - Sistema de vida/tiempo
- `TestMensajesUnity.cs` - Testing de mensajes Unity

### Mecánicas:
- Sistema de disparo con instanciación de prefabs
- Proyectiles con física (Rigidbody + AddForce)
- Enemigos que se mueven hacia el jugador
- Detección de impactos y destrucción de enemigos

---

## 🆕 Cambios de Clase 11

### **Bug Fix: Proyectil destruía el piso**

**Problema:** `OnCollisionEnter` subía por la jerarquía y desactivaba el objeto raíz sin verificar si era un enemigo. Si el proyectil golpeaba el piso, lo desactivaba.

**Solución:** Agregar `CompareTag("Enemy")` antes de desactivar el objeto raíz.

```csharp
void OnCollisionEnter(Collision collision)
{
    Debug.Log("¡Proyectil golpeó: " + collision.gameObject.name + "!");

    Transform objetivo = collision.transform;
    while (objetivo.parent != null)
    {
        objetivo = objetivo.parent;
    }

    // Solo actuar si el objeto raíz es un enemigo
    if (objetivo.CompareTag("Enemy"))
    {
        Debug.Log("Destruyendo objeto raíz: " + objetivo.name);
        objetivo.gameObject.SetActive(false);
    }

    // El proyectil siempre se destruye
    Destroy(gameObject);
}
```

---

### **Fix: Cámara inactiva hasta primer click + Límite de rotación horizontal**

**Problema 1:** La cámara se movía sola al iniciar el juego sin interacción del jugador.

**Problema 2:** El jugador podía girar 360°, mostrando la parte trasera de la escena sin assets.

**Solución:** Variable `camaraActiva` que arranca en false y se activa con el primer click. Clampeo de `rotacionY` para limitar el giro horizontal.

```csharp
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

        // Activar cámara con primer click
        if (Input.GetMouseButtonDown(0))
        {
            camaraActiva = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (!camaraActiva) return;

        float mouseX = Input.GetAxis("Mouse X") * sensibilidad;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        rotacionY += mouseX;
        rotacionY = Mathf.Clamp(rotacionY, -45f, 45f); // 90° en total

        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        cuerpoJugador.rotation = Quaternion.Euler(0f, rotacionY, 0f);
    }
}
```

---

### **Ambientación: Image Rebrand — Fortaleza Nocturna WWII Low Poly**

#### Iluminación
- **Directional Light:**
  - Rotation: X=35, Y=150, Z=0
  - Color: `#C8A882` (amarillo desaturado, luz rasante)
  - Intensity: 1.2
- **Ambient Color:** `#5A6A72` (azul gris frío)

#### Niebla
- Activada en Window → Rendering → Lighting → Environment → Other Settings
- Color: RGB (90, 106, 114)
- Mode: Exponential Squared

#### Skybox
- Asset: **Customizable Skybox** (Unity Asset Store, gratuito)
- Material seleccionado: **Night2**

#### Material del piso
- Material de mosaico de piedras preexistente
- Ajuste: Smoothness → 0.1, Metallic → 0 (eliminar reflejos)

#### Props
- Asset importado: **StylizedHandPaintedDungeon (Free)**
  - Paredes, columnas y puertas para armar la fortaleza
  - Estilo low poly pintado a mano, combina con los ToonSoldiers

---

## 🎓 Conceptos Aplicados en Clase 11

- Importación y configuración de assets de terceros (skybox, props)
- Creación y ajuste de materiales (Smoothness, Metallic)
- Configuración de iluminación ambiental y directional light
- Uso de niebla para ambientación
- Composición de escena con props para generar atmosfera
- Bug fixing con CompareTag para filtrar colisiones
- Control de input con estado booleano (camaraActiva)
- Clampeo de rotación para limitar movimiento del jugador

---

## 📦 Assets Utilizados

- **ToonSoldiers_WW2_demo** — Modelos de soldados cartoon WWII
- **Customizable Skybox** — Skybox parametrizable (material: Night2)
- **StylizedHandPaintedDungeon (Free)** — Props de fortaleza low poly (paredes, columnas, puertas)

---

**Creado:** Abril 2026  
**Para uso en:** Entrega Clase 11 - Aesthetics Lvl 1 Parte 2

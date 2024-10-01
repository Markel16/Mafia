using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifespan = 5f; // Tiempo en segundos antes de que la bala se destruya

    void Start()
    {
        // Destruir la bala después de un tiempo
        Destroy(gameObject, lifespan);
    }

    // Puedes añadir más funcionalidad aquí, como detectar colisiones
}

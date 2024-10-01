using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifespan = 5f; // Tiempo en segundos antes de que la bala se destruya

    void Start()
    {
        // Destruir la bala despu�s de un tiempo
        Destroy(gameObject, lifespan);
    }

    // Puedes a�adir m�s funcionalidad aqu�, como detectar colisiones
}

using UnityEngine;

public class FollowerMovement : MonoBehaviour
{
    public Transform target; // El objeto que se seguirá (el jugador)
    public float speed = 5f; // Velocidad de seguimiento
    public float deceleration = 2f; // Desaceleración más baja
    public float maxDistance = 5f; // Distancia máxima respecto al jugador
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform firePoint; // Punto de disparo
    private Vector2 currentSpeed = Vector2.zero; // Velocidad actual

    void Update()
    {
        // Calcular la dirección hacia el objetivo
        Vector2 direction = target.position - transform.position;

        // Calcular la distancia
        float distance = direction.magnitude;

        // Normalizar la dirección
        if (distance > 0)
        {
            direction.Normalize();
        }

        // Acelerar o desacelerar
        if (distance > 1f && distance < maxDistance) // Si está entre 1 unidad y la distancia máxima del jugador
        {
            currentSpeed += (Vector2)direction * speed * Time.deltaTime;
        }
        else if (distance >= maxDistance) // Si está más allá de la distancia máxima
        {
            currentSpeed = Vector2.zero; // Detener el movimiento
        }
        else
        {
            // Desaceleración al acercarse al jugador
            if (currentSpeed.magnitude > 0)
            {
                currentSpeed -= currentSpeed.normalized * deceleration * Time.deltaTime;
            }

            // Detenerse completamente
            if (currentSpeed.magnitude < 0.1f)
            {
                currentSpeed = Vector2.zero;
            }
        }

        // Mover al objeto
        transform.Translate(currentSpeed * Time.deltaTime);

        // Disparar balas al pulsar espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar la bala en el punto de disparo
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Agregar velocidad a la bala
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {
            bulletRb.velocity = firePoint.up * 100f; // Cambia el valor de 10f a la velocidad deseada
        }
    }
}

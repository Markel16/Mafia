using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float acceleration = 5f; // Aceleración al arrancar
    public float maxSpeed = 10f; // Velocidad máxima
    public float deceleration = 10f; // Desaceleración para frenar más rápido
    private Vector2 currentSpeed = Vector2.zero; // Velocidad actual (x, y)

    void Update()
    {
        // Obtener input
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey("left"))
        {
            horizontalInput = -1f; // Movimiento hacia la izquierda
        }
        else if (Input.GetKey("right"))
        {
            horizontalInput = 1f; // Movimiento hacia la derecha
        }

        /*if (Input.GetKey("up"))
        {
            verticalInput = 1f; // Movimiento hacia arriba
        }
        else if (Input.GetKey("down"))
        {
            verticalInput = -1f; // Movimiento hacia abajo
        }*/

        // Aceleración
        if (horizontalInput != 0)
        {
            currentSpeed.x += horizontalInput * acceleration * Time.deltaTime;
            currentSpeed.x = Mathf.Clamp(currentSpeed.x, -maxSpeed, maxSpeed); // Limitar velocidad horizontal
        }
        else
        {
            // Desaceleración horizontal
            if (currentSpeed.x > 0)
            {
                currentSpeed.x -= deceleration * Time.deltaTime; // Desacelerar hacia la izquierda
            }
            else if (currentSpeed.x < 0)
            {
                currentSpeed.x += deceleration * Time.deltaTime; // Desacelerar hacia la derecha
            }

            // Detenerse completamente
            if (Mathf.Abs(currentSpeed.x) < 0.1f)
            {
                currentSpeed.x = 0f;
            }
        }

        // Aceleración vertical
        if (verticalInput != 0)
        {
            currentSpeed.y += verticalInput * acceleration * Time.deltaTime;
            currentSpeed.y = Mathf.Clamp(currentSpeed.y, -maxSpeed, maxSpeed); // Limitar velocidad vertical
        }
        else
        {
            // Desaceleración vertical
            if (currentSpeed.y > 0)
            {
                currentSpeed.y -= deceleration * Time.deltaTime; // Desacelerar hacia abajo
            }
            else if (currentSpeed.y < 0)
            {
                currentSpeed.y += deceleration * Time.deltaTime; // Desacelerar hacia arriba
            }

            // Detenerse completamente
            if (Mathf.Abs(currentSpeed.y) < 0.1f)
            {
                currentSpeed.y = 0f;
            }
        }

        // Mover al jugador
        transform.Translate(currentSpeed * Time.deltaTime);
    }
}

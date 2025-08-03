using System.Threading;
using UnityEngine;


/// <summary>
/// EnemyMovement controla el movimiento de los enemigos en el juego.
/// Simula el movimiento retro dando saltos en intervalos regulares basados en la velocidad actual de la dificultad.
/// </summary>
public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Distancia del salto")]
    [SerializeField] private float stepDistance;
    [Tooltip("Multiplicador de velocidad para ajustar la frecuencia del salto")]
    [SerializeField] private float speedMultiplier = 1f;

    private float currentTimer;

    public DirectionManager dm;

    private void Start()
    {
        currentTimer = 0f;
        dm = DirectionManager.instance;
    }

    private void FixedUpdate()
    {
        currentTimer += Time.deltaTime;

        if (currentTimer > (dm.CurrentSpeed * speedMultiplier))
        {
            transform.position += dm.Direction.normalized * stepDistance;
            currentTimer = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            dm.WallCollision();
        }
    }
}

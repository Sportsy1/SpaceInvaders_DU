using System.Collections;
using UnityEngine;

/// <summary>
/// Manager de la direccion de los enemigos.
/// El se encarga de cambiar la direccion de los enemigos al chocar con las paredes y al acercarse poco a poco a la linea de invasion
/// </summary>
public class DirectionManager : MonoBehaviour
{
    public static DirectionManager instance;

    private Vector3 direction;

    [Tooltip("La velocidad funciona como un multiplicador sobre el tiempo, entre menor sea este mas rapido sera este intervalo")]
    [SerializeField] private float currentSpeed;

    [Tooltip("Incremento de velocidad al matar un enemigo, esta velocidad solo se mantiene en el nivel")]
    [SerializeField] private float speedIncrement;

    [Tooltip("Dictamina el lugar de spawn de los enemigos")]
    [SerializeField] private GameObject enemyContainer;

    [Tooltip("El offset en Y que se le aplica al grupo de enemigos al chocar con la pared, para poder acercarse a la linea de invasion ")]
    [SerializeField] private float yOffset;
    private float collisionCD = 0.3f;
    private bool canCollide = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        direction = Vector3.right;
        currentSpeed -= DifficultyManager.instance.CurrentScale * currentSpeed;
    }


    /// <summary>
    /// Metodo que cambia la direccion de los enemigos al acercarse a la pared
    /// </summary>
    public void WallCollision()
    {
        if (canCollide)
        {
            if (direction == Vector3.right)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.right;
            }

            StartCoroutine(CollideCD());

            enemyContainer.transform.position += new Vector3(0, yOffset, 0);
        }
    }

    private IEnumerator CollideCD()
    {
        canCollide = false;
        yield return new WaitForSeconds(collisionCD);
        canCollide = true;
    }

    public void IncreaseSpeed()
    {
        currentSpeed += speedIncrement;
    }

    public float CurrentSpeed
    {
        get { return currentSpeed; }
    }

    public Vector3 Direction
    {
        get { return direction; }
    }
}

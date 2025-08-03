using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// El Actor de la faccion enemiga interactua con el sistema de puntuacion y cambio de niveles.
/// </summary>
public class EnemyActor : Actor
{
    [SerializeField] private int points;

    [Tooltip("Esta variable se deja publica para completo acceso por parte de multiples scripts")]
    [HideInInspector]
    public static bool canBeCalled = true;

    public override void Start()
    {
        base.Start();
        death.AddListener(DirectionManager.instance.IncreaseSpeed);
        death.AddListener(() => ScoreManager.instance.AddScore(points));

        if (!canBeCalled)
        {
            canBeCalled = true;
        }
    }


    public override void UpdateHealth(int healthDelta)
    {
        base.UpdateHealth(healthDelta);
    }


    /// <summary>
    /// Al Destruir este actor, este busca por otros actores aliados en la escena, si no hay ninguno, se procede a cambiar de nivel, se maneja una variable estatica para evitar conflictos de multiples llamadas.
    /// </summary>
    private void OnDestroy()
    {
        if (canBeCalled)
        {
            if (GameObject.FindWithTag("Enemy") == null)
            {
                canBeCalled = false;
                LevelManager.instance.NextLevel();
            }
        }
    }
}

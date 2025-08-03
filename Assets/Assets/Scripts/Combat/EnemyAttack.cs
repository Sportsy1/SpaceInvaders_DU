using UnityEngine;
using System.Collections;
using NUnit.Framework;



/// <summary>
/// Controla el comportamiento de ataque automático de un enemigo en intervalos aleatorios segun 2 parametros.
/// Utiliza el componente <see cref="Attack"/> para la logica de lanzamiento.
/// </summary>
public class EnemyAttack : MonoBehaviour
{
    [Header("Intervalos de ataque")]

    [Tooltip("Rango de tiempo para generar una posibildad de atacar")]
    [SerializeField] private Vector2 attackTimer;

    [Tooltip("Probabilidad de atacar, entre 0 y 9, siendo 0 imposible y 9 garantizado")]
    [SerializeField] private float aggro;
    private EnemyInstance currentInstance;


    private Attack _attack;
    private HealthVolume healthVolume;


    /// <summary>
    /// Se inicializan los componentes necesarios y se ajusta la aggro segun la dificultad actual del juego.
    /// </summary>
    private void Start()
    {
        _attack = GetComponent<Attack>();
        healthVolume = GetComponent<HealthVolume>();
        currentInstance = GetComponent<EnemyInstance>();
        aggro += DifficultyManager.instance.CurrentScale * aggro;
        StartCoroutine(SpawnerLoop());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }


    /// <summary>
    /// Ciclo de ataque que se ejecuta en intervalos aleatorios.
    /// </summary>
    private IEnumerator SpawnerLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(attackTimer.x, attackTimer.y));

            if (aggro >= Random.Range(0, 9) && currentInstance.CanShoot())
            {
                _attack.LaunchProjectile(healthVolume.factionClass);
            }

        }
    }
}

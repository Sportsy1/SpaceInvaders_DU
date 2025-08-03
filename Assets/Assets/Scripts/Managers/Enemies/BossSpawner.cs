using System.Collections;
using UnityEngine;


/// <summary>
/// Manager del Spawn del Boss.
/// El Boss se spawnea en un punto concreto del mapa y solo si no hay otro boss ya en escena.
/// Si no hay Boss presente este tiene una probabilidad de spawn cada cierto tiempo.
/// El Boss solo provee puntos y es opcional de matar
/// </summary>
public class BossSpawner : MonoBehaviour
{
    [Range(1f, 9f)]
    [SerializeField] private int aggro;
    [SerializeField] private float maxTimer;

    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPoint;

    private void Awake()
    {
        StartCoroutine(SpawnerLoop());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnerLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(maxTimer);

            if (!SearchInScene() && aggro >= Random.Range(0, 9))
            {
                Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            }

        }
    }

    private bool SearchInScene()
    {
        return GameObject.FindGameObjectWithTag("Boss") != null;
    }

}

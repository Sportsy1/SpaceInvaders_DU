using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Matriz de spawn de enemigos.
/// Genera una matriz a partir de 2 enteros que representan las filas y columnas.
/// Spawnea enemigos fila por fila el orden de una lista.
/// </summary>
public class EnemyMatrix : MonoBehaviour
{
    [Tooltip("Tamaño de la matriz")]
    [SerializeField] private int filas, columnas;

    [Tooltip("Lista de enemigos a spawnear, el orden de esta lista dictamina el orden en la matriz")]
    [SerializeField] private List<GameObject> enemies;

    [SerializeField] private GameObject parent;
    private BoxCollider2D area;
    private GameObject[,] enemyObjects;
    private Vector2[,] mainMatrix;

    public static EnemyMatrix instance;

    private void Awake()
    {
        area = parent.GetComponent<BoxCollider2D>();
        enemyObjects = new GameObject[filas, columnas];
        GenerateMatrix();

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                GenerarEnemigos(i, j);
            }
        }

        if (instance == null)
        {
            instance = this;
        }
    }


    /// <summary>
    /// Genera puntos de spawn en una matriz de tamaño filas x columnas para mantener un orden equitativo entre los objetos.
    /// </summary>
    private void GenerateMatrix()
    {
        mainMatrix = new Vector2[filas, columnas];

        Vector2 size = area.size;
        Vector2 center = (Vector2)area.transform.position + area.offset;

        Vector2 min = center - size * 0.5f;

        float stepX = size.x / (columnas - 1);
        float stepY = size.y / (filas - 1);

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                float x = min.x + stepX * j;
                float y = min.y + stepY * i;
                Vector2 position = new Vector2(x, y);
                mainMatrix[i, j] = position;
            }
        }
    }


    /// <summary>
    /// Instancia a los enemigos y guarda su informacion de fila/columna para mantener el seguimiento de su instancia y posicion.
    /// </summary>
    private void GenerarEnemigos(int fila, int columna)
    {
        GameObject obj = Instantiate(enemies[fila], mainMatrix[fila, columna], Quaternion.identity, parent.transform);
        EnemyInstance _enemyInstance = obj.GetComponent<EnemyInstance>();
        _enemyInstance.Fila = fila;
        _enemyInstance.Columna = columna;
        enemyObjects[fila, columna] = obj;
    }

    /// <summary>
    /// Comprueba si el enemigo en esa fila no tiene mas enemigos en frente.
    /// Permite que solo los enemigos mas cerca a ti disparen.
    /// </summary>

    public bool LastInRow(int filaActual, int columna)
    {
        for (int fila = 0; fila < filaActual; fila++)
        {
            if (enemyObjects[fila, columna] != null)
                return false;
        }

        return true;
    }


    public GameObject[,] EnemyObjects
    {
        get => enemyObjects;
        set => enemyObjects = value;
    }
}

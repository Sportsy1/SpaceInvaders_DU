using UnityEngine;


/// <summary>
/// Clase que representa una instancia de enemigo en la matriz de enemigos.
/// </summary>
public class EnemyInstance : MonoBehaviour
{
    private int fila, columna;

    public bool CanShoot()
    {
        bool canShoot;

        canShoot = EnemyMatrix.instance.LastInRow(fila, columna);
        return canShoot;
    }

    private void OnDestroy()
    {
        EnemyMatrix.instance.EnemyObjects[fila, columna] = null;
    }


    public int Fila
    {
        get => fila;
        set => fila = value;
    }

    public int Columna
    {
        get => columna;
        set => columna = value;
    }
}

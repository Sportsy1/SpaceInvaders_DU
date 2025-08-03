using UnityEngine;


/// <summary>
/// Manager de la dificultad del juego, cada vez que se pasa de nivel se sube la escala de dificultad
/// La escala afecta a la velocidad de los enemigos y a su aggro, permitiendo moverse mas rapido y disparar mas frecuentemente
/// </summary>
public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;
    private float currentScale;
    [SerializeField] private float scaleIncrement;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        currentScale = 0f;
    }

    public void IncreaseScale()
    {
        currentScale += scaleIncrement;
    }

    public float CurrentScale
    {
        get { return currentScale; }
    }

}

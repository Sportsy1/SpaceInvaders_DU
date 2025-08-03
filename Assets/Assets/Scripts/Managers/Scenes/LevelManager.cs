using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Manager del nivel, controla el nivel actual del juego y permite avanzar al siguiente nivel.
/// Usa el PlayerPrefs "level" para guardar el nivel actual.
/// </summary>
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int currentLevel;
    private bool canBeCalled;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        currentLevel = 1;

        PlayerPrefs.SetInt("level", currentLevel);
    }

    public void NextLevel()
    {

        if (currentLevel < 10)
        {
            Debug.Log("Next");
            currentLevel += 1;
            PlayerPrefs.SetInt("level", currentLevel);
            DifficultyManager.instance.IncreaseScale();
            LifesManager.instance.AddLife();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}

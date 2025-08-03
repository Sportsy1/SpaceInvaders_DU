using TMPro;
using UnityEngine;


/// <summary>
/// Manager del Score.
/// Mantiene el puntaje actual del jugador entre escenas y lo muestra en pantalla.
/// Usa el PlayerPrefs "score" para guardar el puntaje actual.
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI textObj;

    public int currentScore;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        if (PlayerPrefs.HasKey("score"))
        {
            currentScore = PlayerPrefs.GetInt("score");
            textObj.text = "SCORE: " + currentScore;
        }
        else
        {
            PlayerPrefs.DeleteKey("score");
            currentScore = 0;
            PlayerPrefs.SetInt("score", 0);
            textObj.text = "SCORE: 0";
        }


    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        PlayerPrefs.SetInt("score", currentScore);
        textObj.text = "SCORE: " + PlayerPrefs.GetInt("score");
    }



}

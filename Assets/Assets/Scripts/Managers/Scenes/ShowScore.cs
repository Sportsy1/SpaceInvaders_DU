using TMPro;
using UnityEngine;


/// <summary>
/// Muestra el puntaje actual del jugador en pantalla al cargar el nivel.
/// </summary>
public class ShowScore : MonoBehaviour
{
    private TextMeshProUGUI textObj;
    void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
        textObj.text = "Score: " + PlayerPrefs.GetInt("score");
    }
}

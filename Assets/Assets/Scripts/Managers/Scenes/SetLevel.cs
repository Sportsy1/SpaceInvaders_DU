using TMPro;
using UnityEngine;


/// <summary>
/// Actualiza el nivel actual al cargar un nivel
/// </summary>
public class SetLevel : MonoBehaviour
{
    private TextMeshProUGUI textObj;

    private void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
        textObj.text = "LEVEL: " + PlayerPrefs.GetInt("level");
    }
}

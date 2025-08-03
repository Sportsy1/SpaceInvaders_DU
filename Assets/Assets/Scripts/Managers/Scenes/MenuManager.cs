using UnityEngine;


/// <summary>
/// Borra todos los PlayerPrefs para comenzar desde cero y asegura que el tiempo del juego sea 1 al iniciar el menu.
/// </summary>
public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();
        Time.timeScale = 1f;
    }
}

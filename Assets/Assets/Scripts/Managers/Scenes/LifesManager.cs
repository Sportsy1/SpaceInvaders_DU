using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Manager de las vidas del jugador.
/// Añade una vida al pasar de nivel sin pasar de 3.
/// Al morir comprueba cuantas vidas tiene para recargar la escena o cambiar a GameOver.
/// </summary>
public class LifesManager : MonoBehaviour
{
    [SerializeField] private int maxLifes;
    [Tooltip("Texto que muestra las vidas actuales del jugador")]
    [SerializeField] private TextMeshProUGUI lifeObj;
    public int currentLifes;
    public static LifesManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (PlayerPrefs.HasKey("lifes"))
        {
            currentLifes = PlayerPrefs.GetInt("lifes");
            lifeObj.text = "[X" + currentLifes + "]";
        }
        else
        {
            currentLifes = 3;
            PlayerPrefs.SetInt("lifes", currentLifes);
            lifeObj.text = "[X" + currentLifes + "]";
        }
    }

    public void AddLife()
    {
        currentLifes += 1;
        currentLifes = Mathf.Clamp(currentLifes, 0, maxLifes);
        PlayerPrefs.SetInt("lifes", currentLifes);
    }


    /// <summary>
    /// Recarga la escena actual o cambia a GameOver si no quedan vidas.
    /// Usa el Flag del EnemyActor para evitar que se llame a este metodo varias veces si quedan varios enemigos en la escena.
    /// </summary>
    public void Die()
    {
        EnemyActor.canBeCalled = false;
        if (currentLifes > 0)
        {
            currentLifes -= 1;
            PlayerPrefs.SetInt("lifes", currentLifes);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }




}

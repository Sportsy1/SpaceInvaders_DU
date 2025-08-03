using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Carga una escena especifica cuando se pulsa la tecla Espacio.
/// </summary>
public class LoadManager : MonoBehaviour
{
    [SerializeField] private string sceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

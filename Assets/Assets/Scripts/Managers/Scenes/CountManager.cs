using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Conteo al inicio del nivel.
/// Pausa el juego, oculta ciertos elementos y muestra un contador regresivo para la continuacion del nivel.
/// </summary>
public class CountManager : MonoBehaviour
{
    [Tooltip("Lista de objetos a ocultar mientras el conteo esta presente")]
    [SerializeField] private List<GameObject> objectsToHide = new List<GameObject>();
    [SerializeField] private int count;
    [SerializeField] private TextMeshProUGUI countObj;


    [Header("Eventos")]
    [SerializeField] private UnityEvent countTrigger;
    [SerializeField] private UnityEvent startLevel;



    private void Start()
    {
        for (int i = 0; i < objectsToHide.Count; i++)
        {
            objectsToHide[i].SetActive(false);
        }

        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        Time.timeScale = 0f;

        float pauseDuration = count;
        float timer = pauseDuration;

        while (timer > 0)
        {
            countObj.text = Mathf.Ceil(timer).ToString();
            countTrigger?.Invoke();
            yield return new WaitForSecondsRealtime(1f);
            timer -= 1f;
        }

        countObj.text = "";
        Time.timeScale = 1f;


        for (int i = 0; i < objectsToHide.Count; i++)
        {
            objectsToHide[i].SetActive(true);
        }
        startLevel?.Invoke();
    }
}

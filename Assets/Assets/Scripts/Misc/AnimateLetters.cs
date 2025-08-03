using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Anima un texto letra por letra, con un evento que se dispara al escribir cada letra y otro al finalizar la escritura.
/// </summary>
public class AnimateLetters : MonoBehaviour
{
    private TextMeshProUGUI textObj;

    [Header("Velocidad en la cual se demora en poner la siguiente letra")]
    [SerializeField] private float speed;
    [SerializeField] private UnityEvent typeEvent;

    [Header("Tiempo de espera antes de disparar el evento de finalizacion del texto")]
    [SerializeField] private float finishDelay;
    [SerializeField] private UnityEvent finishEvent;
    

    [TextArea]
    [SerializeField] private string text;

    private void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
        StartCoroutine(StartTyping());
    }

    private IEnumerator StartTyping()
    {
        textObj.text = "";
        foreach (char letter in text)
        {
            textObj.text += letter;
            typeEvent?.Invoke();
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(finishDelay);
        finishEvent?.Invoke();
    }

}

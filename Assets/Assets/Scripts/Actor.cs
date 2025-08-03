using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Script base para actores del juego, todo Objeto que interactue con cualquier tipo de volumen (Vida / Daño) Debe tener este componente.
/// </summary>
public class Actor : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private float iFrames;
    public bool isImmortal = false;

    public bool canReceiveDamage;
    private int currentHealth;

    [SerializeField] protected UnityEvent death;
    [SerializeField] protected UnityEvent hit;

    public virtual void Start()
    {
        canReceiveDamage = true;
        currentHealth = maxHealth;
    }

    public virtual void UpdateHealth(int healthDelta)
    {
        if (!isImmortal)
        {
            if (canReceiveDamage)
            {
                currentHealth += healthDelta;
                hit?.Invoke();
                StartCoroutine(Invencibility());
                if (currentHealth <= 0)
                {
                    death?.Invoke();
                    StopAllCoroutines();
                    Destroy(gameObject);
                }
            }
        }
    }

    private IEnumerator Invencibility()
    {
        canReceiveDamage = false;
        yield return new WaitForSeconds(iFrames);
        canReceiveDamage = true;
    }
}

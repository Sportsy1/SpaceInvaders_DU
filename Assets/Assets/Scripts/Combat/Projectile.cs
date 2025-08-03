using System.Collections;
using UnityEngine;


/// <summary>
/// Instanciamiento de proyectil segun su caster, este script se encarga de la logica de daño y duracion del proyectil.
/// </summary>
public class Projectile : DamageVolume
{
    [SerializeField] private int damage;
    [SerializeField] private float duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // Si el objeto con el que colisiona tiene una interfaz ITakeDamage, se verifica si pertenece a una faccion diferente y envia el daño a la interfaz.
        if (collision.TryGetComponent<ITakeDamage>(out ITakeDamage receiver))
        {
            if (receiver.factionType != factionClass)
            {
                SendDamage(receiver, damage);
                gameObject.SetActive(false);
                StopAllCoroutines();
            }
        }
    }



    private void Awake()
    {
        StartCoroutine(LifeTime());
    }

    private IEnumerator LifeTime()
    {
        Debug.Log("start");
        yield return new WaitForSeconds(duration);
        Debug.Log("kill");
        gameObject.SetActive(false);
    }
}

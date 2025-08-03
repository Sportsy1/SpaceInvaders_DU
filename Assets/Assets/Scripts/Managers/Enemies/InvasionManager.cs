using UnityEngine;



/// <summary>
/// Script para el comprobar si un enemigo ha colisionado con un objeto.
/// Tanto el objeto como el enemigo son destruidos al mismo tiempo.
/// Si es un punto critic como la linea de invasion, se llama al metodo Die del LifesManager.
/// </summary>
public class InvasionManager : MonoBehaviour
{
    [SerializeField] private bool criticalPoint = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);

            if (criticalPoint)
            {
                LifesManager.instance.Die();
            }

            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Controla el disparo de proyectiles desde un objeto, este script se encarga de de la direccion .
/// </summary>
public class Attack : MonoBehaviour
{
    [Tooltip("Solo existen 2 direcciones posibles, el vector siempre se debe normalizar")]
    [SerializeField] private ProjectileDirection direction;

    [Tooltip("Velocidad del proyectil aplicada a su rigidbody")]
    [SerializeField] private float projectileSpeed;

    [Tooltip("Posicion del disparo, el proyectil se instanciara en esta posicion cuando se dispare")]
    [SerializeField] private Transform firePos;

    [Tooltip("Evento que se invoca al disparar el proyectil, se puede usar para efectos visuales o de sonido")]
    [SerializeField] private UnityEvent fire;

    private Vector3 projectileVector;


    /// <summary>
    /// Se Inicializa el vector del proyectil dependiendo de la direccion seleccionada.
    /// </summar>
    private void Awake()
    {
        if (direction == ProjectileDirection.Down)
        {
            projectileVector = Vector3.down;
        }
        else
        {
            projectileVector = Vector3.up;
        }
    }



    /// <summary>
    /// Lanza el proyectil desde la posicion de disparo, se instancia un objeto del pool de objetos segun la faccion de su HealthVolume.
    /// </summary>
    /// <param name="factionCaster"> Faccion del objeto que dispara, se usa para obtener del pool de objetos y gestionar quien daña a quien.</param>
    public void LaunchProjectile(FactionsList factionCaster)
    {
        GameObject projectileInstance = ObjectPool.instance.GetObjectFromPool(factionCaster);
        DamageVolume _damageVolume = projectileInstance.GetComponent<DamageVolume>();

        fire?.Invoke();

        if (_damageVolume != null)
        {
            _damageVolume.factionClass = factionCaster;
            Rigidbody2D projectileRb = projectileInstance.GetComponent<Rigidbody2D>();

            if (projectileRb != null)
            {
                projectileInstance.transform.position = firePos.position;
                projectileInstance.SetActive(true);
                projectileRb.linearVelocity = projectileVector.normalized * projectileSpeed;
            }
        }



    }
}

public enum ProjectileDirection
{
    Up,
    Down
}

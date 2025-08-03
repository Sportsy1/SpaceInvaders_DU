using UnityEngine;
using System.Collections;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;


/// <summary>
/// Controlador del movimiento y el ataque del jugador.
/// Utiliza el nuevo Input System de Unity para manejar el movimiento y los ataques.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Tooltip("Movimiento horizontal")]
    [SerializeField] private float horizontalSpeed;
    private Attack _attack;

    [Tooltip("Cooldown del ataque en segundos")]
    [SerializeField] private float attackCD;

    private HealthVolume hVolume;


    private bool canAttack;

    private Rigidbody2D rb;
    private Vector2 motionVector;

    private void Awake()
    {
        canAttack = true;
        rb = GetComponent<Rigidbody2D>();
        _attack = GetComponent<Attack>();
        hVolume = GetComponent<HealthVolume>();
    }

    public void Move(CallbackContext ctx)
    {
        motionVector = ctx.ReadValue<Vector2>();
    }

    /// <summary>
    /// Disparo del proyectil.
    /// Se asegura de que el CallbackContext sea "performed" para que solo se llame una vez.
    /// </summary>
    public void Fire(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (canAttack)
            {
                _attack.LaunchProjectile(hVolume.factionClass);
                StartCoroutine(AttackCD());
            }

        }
    }

    private IEnumerator AttackCD()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCD);
        canAttack = true;
    }


    private void FixedUpdate()
    {
        rb.linearVelocity = motionVector * horizontalSpeed;
    }

}

using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Volumen de salud, todo actor que pueda recibir daño debe tener un componente Actor.
/// </summary>
public class HealthVolume : Volume, ITakeDamage
{
    private Actor actorState;


    private void Awake()
    {
        actorState = GetComponent<Actor>();
    }


    public void TakeDamage(ISendDamage perpetrator, int amount)
    {
        if (actorState != null)
        {
            actorState.UpdateHealth(amount);
        }
        else
        {
            Debug.LogError("Health Volume Does Not Contain Valid Actor");
        }

    }
}

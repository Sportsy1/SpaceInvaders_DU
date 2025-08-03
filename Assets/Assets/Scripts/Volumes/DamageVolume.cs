using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Volumen de daño, toda entidad que haga daño debe implementar la interfaz ISendDamage.
/// </summary>
public class DamageVolume : Volume, ISendDamage
{
    public void SendDamage(ITakeDamage target, int amount)
    {
        target.TakeDamage(this, amount);
    }

}

using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Volumen de da�o, toda entidad que haga da�o debe implementar la interfaz ISendDamage.
/// </summary>
public class DamageVolume : Volume, ISendDamage
{
    public void SendDamage(ITakeDamage target, int amount)
    {
        target.TakeDamage(this, amount);
    }

}

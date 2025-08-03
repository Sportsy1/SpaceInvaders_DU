using UnityEngine;


/// <summary>
/// Interfaz para enviar daño a un objetivo que implemente ITakeDamage.
/// </summary>
public interface ISendDamage : IFaction
{
    void SendDamage(ITakeDamage target, int amount);
}

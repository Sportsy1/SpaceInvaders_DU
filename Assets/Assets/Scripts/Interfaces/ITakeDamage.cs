using UnityEngine;

/// <summary>
/// Interface for objects que pueden ser da�ados.
/// </summary>
public interface ITakeDamage : IFaction
{
    void TakeDamage(ISendDamage perpetrator, int amount);
}

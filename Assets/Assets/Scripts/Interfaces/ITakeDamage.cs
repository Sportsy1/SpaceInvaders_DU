using UnityEngine;

/// <summary>
/// Interface for objects que pueden ser dañados.
/// </summary>
public interface ITakeDamage : IFaction
{
    void TakeDamage(ISendDamage perpetrator, int amount);
}

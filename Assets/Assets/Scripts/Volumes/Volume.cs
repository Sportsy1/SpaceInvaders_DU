using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Clase base para vol�menes que interact�an con facciones.
/// </summary>
public class Volume : MonoBehaviour, IFaction
{
    public FactionsList factionClass;

    public FactionsList factionType => factionClass;
}

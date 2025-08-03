using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Clase base para volúmenes que interactúan con facciones.
/// </summary>
public class Volume : MonoBehaviour, IFaction
{
    public FactionsList factionClass;

    public FactionsList factionType => factionClass;
}

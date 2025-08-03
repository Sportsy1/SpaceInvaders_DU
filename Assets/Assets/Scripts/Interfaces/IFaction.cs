using UnityEngine;


/// <summary>
/// Interfaz de facciones, usada para discriminar entre diferentes tipos de actores en el juego para evitar fuego aliado.
/// </summary>
public interface IFaction
{
    public FactionsList factionType { get; }
}

public enum FactionsList
{
    player,
    barrier,
    alien,
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataTemplate {
    public readonly uint Number;
    public readonly string Property;
    public readonly string Type;
    public readonly uint Cost;
    public readonly string Name;
    public readonly string Explanation;
    public readonly uint Attack, Shiled, Health, Mana, Draw;
    public readonly string SpeicalEffect;
    public readonly uint Duration;
    public readonly string Target;
    public readonly string ActivationCondition;
    public readonly string Volatility;

    public CardDataTemplate(
        uint number, string property, string type, uint cost, string name, string explanation,
        uint attack, uint shiled, uint health, uint mana, uint draw, string specialEffect,
        uint duration, string target, string activationCondition, string volatility) {
        Number = number;
        Property = property;
        Type = type;
        Cost = cost;
        Name = name;
        Explanation = explanation;
        Attack = attack;
        Shiled = shiled;
        Health = health;
        Mana = mana;
        Draw = draw;
        SpeicalEffect = specialEffect;
        Duration = duration;
        Target = target;
        ActivationCondition = activationCondition;
        Volatility = volatility;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataTemplate {
    public readonly uint Number;
    public readonly string Name;
    public readonly string Description;
    public readonly string Content;
    public readonly uint Health, Power, Agility, Inteligence;
    public readonly string SpecialAbility;

    public ItemDataTemplate(
        uint number, string name, string description, string content,
        uint health, uint power, uint agility, uint inteligence,
        string specialAbility) {
        Number = number;
        Name = name;
        Description = description;
        Content = content;
        Health = health;
        Power = power;
        Agility = agility;
        Inteligence = inteligence;
        SpecialAbility = specialAbility;
    }
}

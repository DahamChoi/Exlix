using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area
{
    public Environment environment;
    public string imagePath;
    public int level;
    public List<Event> essentialEventList;
    public List<Area> parents;
}

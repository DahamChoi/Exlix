using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area {
    public AreaEnvironment environment;
    public Illustration illustration;
    public int level;
    public List<Event> essentialEventList;
    public List<Area> parents;
}

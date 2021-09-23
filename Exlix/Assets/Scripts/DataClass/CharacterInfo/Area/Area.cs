using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area {
    public int areaIndex;
    public AreaName name;
    public AreaEnvironment environment;
    public AreaDescribe describe;
    public AreaProbability probability;
    public Illustration illustration;
    public int level;
    public List<Event> essentialEventList;
    public List<Area> parents;
}

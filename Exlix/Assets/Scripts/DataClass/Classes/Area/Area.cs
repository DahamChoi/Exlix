using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area {
    public int areaIndex;
    public string name;
    public string areaEnvironment;
    public string areaDescribe;
    public AreaProbability probability;
    public Illustration illustration;
    public int level;
    public List<int> essentialEventList;
    public List<int> parentAreaList;
    public string parentString;
    static public AreaProbability SetAreaProbability(int mainProbability, int areaProbability, int subProbability) {
        AreaProbability prob = new AreaProbability();
        prob.areaProbability = areaProbability;
        prob.mainProbability = mainProbability;
        prob.subProbability = subProbability;

        return prob;
    }
}


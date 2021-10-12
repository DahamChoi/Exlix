using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle 
{
    public Battlefield battlefield;
    public List<Enemy> enemyList; 

    static public Battlefield SetBattleField(int illustIndex, string bgmPath) {
        Battlefield battlefield = new Battlefield();

        battlefield.illust = IllustrationDao.GetIllust(illustIndex);
        battlefield.bgmPath = bgmPath;

        return battlefield;
    }
}

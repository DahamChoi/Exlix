using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateInfo
{
    public int skillPoint { get; set; } //스킬 포인트
    public int hpPoint { get; set; }
    public int intPoint { get; set; }
    public int dexPoint { get; set; }
    public int strPoint { get; set; }
    public int PortraitNumber { get; set; }
    public SkillDataTemplate equipedSkill { get; set; } //장착중인 스킬
    public Dictionary<int , bool> unlockedSkill { get; set; } //해금한 스킬

    public PlayerStateInfo() {
        this.skillPoint = 5;
        this.hpPoint = 10;
        this.intPoint = 10;
        this.dexPoint = 10;
        this.strPoint = 10;
        this.PortraitNumber = 1;
    }
}

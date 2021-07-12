using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateInfo {
    public int skillPoint { get; set; } //스킬 포인트
    public int statusExtraPoint { get; set; }
    public int hpPoint { get; set; }
    public int intPoint { get; set; }
    public int dexPoint { get; set; }
    public int strPoint { get; set; }
    public int extraHp { get; set; }
    public int extraInt { get; set; }
    public int extraDex { get; set; }
    public int extraStr { get; set; }
    public PortraitDTO currentPortrait { get; set; }
    public StartDeckDTO currentStartDeck {get; set;}
    public string PlayerName { get; set; }
    public SkillDataTemplate equipedSkill { get; set; } //장착중인 스킬
    public Dictionary<int, bool> unlockedSkill { get; set; } //해금한 스킬

    public PlayerStateInfo() {//테스트용임
        this.statusExtraPoint = 5;
        this.hpPoint = 10;
        this.intPoint = 10;
        this.dexPoint = 10;
        this.strPoint = 10;
        this.extraHp = 0;
        this.extraInt = 0;
        this.extraStr = 0;
        this.extraDex = 0;
        this.PlayerName = "";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateInfo
{
    public int skillPoint { get; set; } //스킬 포인트
    public SkillDataTemplate equipedSkill { get; set; } //장착중인 스킬
    public Dictionary<int , bool> unlockedSkill { get; set; } //해금한 스킬

}

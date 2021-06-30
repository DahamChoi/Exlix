using System.Collections.Generic;
using System.IO;
using System.Text;

public class CSVSkillParser : CSVParser<SkillDataTemplate> {
    static public List<string> CoulumName = new List<string>{
        "Number", "CoolTime", "Title", "Explanation",
        "ContinuousTurn", "AttackTarget", "Attack", "ShiledTarget", "Shiled",
        "HealTarget", "Heal", "Mana", "Draw", "StunTarget", "Stun", "BleedingTarget", "Bleeding",
        "BurnTarget", "Burn", "DemurenessTarget", "Demureness",
        "WeakTarget", "Weak", "PoisonTarget", "Poison", "CorrosionTarget", "Corrosion", "SpeicalEffect"
    };
    public CSVSkillParser(string path) : base(path) { }

    public override void ReadData() {
        foreach (var line in File.ReadAllLines(Path, Encoding.GetEncoding(65001))) {
            var parts = line.Split(',');
            int index = 0;
            SkillDataTemplate dataTemplate = new SkillDataTemplate();
            foreach (var it in parts) {
                dataTemplate.Data.Add(CoulumName[index++], it == "" ? "0" : it);
            }
            DataList.Add(dataTemplate);
        }
    }
}
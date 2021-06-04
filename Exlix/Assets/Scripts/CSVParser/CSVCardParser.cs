using System.Collections.Generic;
using System.IO;
using System.Text;

public class CSVCardParser : CSVParser<CardDataTemplate> {
    static public List<string> CoulumName = new List<string>{
        "Number", "Property", "Type", "Consumable", "Cost", "Title", "Explanation",
        "ContinuousTurn", "AttackTarget", "Attack", "ShiledTarget", "Shiled",
        "HealTarget", "Heal", "Mana", "Draw", "StunTarget", "Stun", "BleedingTarget", "Bleeding",
        "BurnTarget", "Burn", "DemurenessTarget", "Demureness",
        "WeakTarget", "Weak", "PoisonTarget", "Poison", "CorrosionTarget", "Corrosion", "SpeicalEffect"
    };
    public CSVCardParser(string path) : base(path) {}

    public override void ReadData() {
        foreach(var line in File.ReadAllLines(Path, Encoding.GetEncoding(65001))){
            var parts = line.Split(',');
            int index = 0;
            CardDataTemplate dataTemplate = new CardDataTemplate();
            foreach(var it in parts){
                dataTemplate.Data.Add(CoulumName[index++], it);
            }
            DataList.Add(dataTemplate);
        }        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDAO {
    private static readonly string SkillTableName = "skill";
    public static SkillDTO GetSelectedSkillInfo(int skillId) {
        string query = $"SELECT * FROM {SkillTableName} WHERE number = {skillId};";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        SkillDTO skillData = new SkillDTO();
        if (false == it.Read())
            return default;
        
        skillData.Number = it.GetSafeValue<int>(0);
        skillData.ImagePath = it.GetSafeValue<string>(1);
        skillData.CoolTime = it.GetSafeValue<int>(2);
        skillData.Name = it.GetSafeValue<string>(3);
        skillData.Explain = it.GetSafeValue<string>(4);
        skillData.Parent = it.GetSafeValue<int>(5);
        skillData.SkillCard = it.GetSafeValue<int>(6);

        return skillData;
    }

    public static List<SkillDTO> GetSkillList() {
        List<SkillDTO> skillList = new List<SkillDTO>();
        string query = $"SELECT * FROM {SkillTableName}";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);
        while(true == it.Read()) {
            SkillDTO skillData = new SkillDTO();
            skillData.Number = it.GetSafeValue<int>(0);
            skillData.ImagePath = it.GetSafeValue<string>(1);
            skillData.CoolTime = it.GetSafeValue<int>(2);
            skillData.Name = it.GetSafeValue<string>(3);
            skillData.Explain = it.GetSafeValue<string>(4);
            skillData.Parent = it.GetSafeValue<int>(5);
            skillData.SkillCard = it.GetSafeValue<int>(6);

            skillList.Add(skillData);
        }

        
        return skillList;
    }
}

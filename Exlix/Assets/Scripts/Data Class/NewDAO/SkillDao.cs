using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
public class SkillDao {
    private static readonly string SkillTable = "skill";
    private static readonly string SkillNameTable = "skill_name";
    private static readonly string SkillDescribeTable = "skill_describe";

    public static List<Skill> GetSkillList() {
        string query = $"SELECT" +
              $"{SkillTable}.skill_index AS 'skill_index'," +
              $"{SkillNameTable}.ko_KR AS 'skill_name'," +
              $"{SkillDescribeTable}.ko_KR AS 'skill_describe'," +
              $"{SkillTable}.cooldown AS 'cooldown'," +
              $"{SkillTable}.image_path AS 'image_path'," +
              $"{SkillTable}.parent AS 'parent'," +
              $"{SkillTable}.skill_path AS 'skill_path'" +
              $"FROM {SkillTable}" +
              $"LEFT JOIN {SkillNameTable}" +
              $"ON {SkillTable}.skill_index = {SkillNameTable}.skill_index" +
              $"LEFT JOIN {SkillDescribeTable}" +
              $"ON {SkillTable}.skill_index = {SkillDescribeTable}.skill_index";

        List<Skill> skillList = new List<Skill>();
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);
        
        while(true == it.Read()) {
            Skill skill = new Skill();
            skill.name.textKr = it.GetSafeValue<string>(1);
            skill.imagePath = it.GetSafeValue<string>(2);
            skill.cooldown = it.GetSafeValue<int>(3);
            skill.parent = it.GetSafeValue<int>(4);
            //skill.skillPath = it.GetSafeValue<string>(5);

            skillList.Add(skill);
        }

        return skillList;
    }

    public static Skill GetSelectedSkill(int skillIndex) {
        string query = $"SELECT" +
        $"{SkillTable}.skill_index AS 'skill_index'," +
        $"{SkillNameTable}.ko_KR AS 'skill_name'," +
        $"{SkillDescribeTable}.ko_KR AS 'skill_describe'," +
        $"{SkillTable}.cooldown AS 'cooldown'," +
        $"{SkillTable}.image_path AS 'image_path'," +
        $"{SkillTable}.parent AS 'parent'," +
        $"{SkillTable}.skill_path AS 'skill_path'" +
        $"FROM {SkillTable}" +
        $"LEFT JOIN {SkillNameTable}" +
        $"ON {SkillTable}.skill_index = {SkillNameTable}.skill_index" +
        $"LEFT JOIN {SkillDescribeTable}" +
        $"ON {SkillTable}.skill_index = {SkillDescribeTable}.skill_index" +
        $"WHERE {SkillTable}.skill_index = {skillIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);
        Skill skill = new Skill();
        
        if (false == it.Read()) {
            return default;
        }
        skill.name.textKr = it.GetSafeValue<string>(1);
        skill.imagePath = it.GetSafeValue<string>(2);
        skill.cooldown = it.GetSafeValue<int>(3);
        skill.parent = it.GetSafeValue<int>(4);
        //skill.skillPath = it.GetSafeValue<string>(5);

        return skill;
    }
}

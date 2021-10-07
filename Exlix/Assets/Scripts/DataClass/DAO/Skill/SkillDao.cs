using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
public class SkillDao {
    public static List<Skill> GetSkillList() {
        string query = $"SELECT" +
              $"{DataBaseTableDefine.SkillTable}.skill_index AS 'skill_index', " +
              $"{DataBaseTableDefine.SkillNameTable}.ko_KR AS 'skill_name', " +
              $"{DataBaseTableDefine.SkillDescribeTable}.ko_KR AS 'skill_describe', " +
              $"{DataBaseTableDefine.SkillTable}.cooldown AS 'cooldown', " +
              $"{DataBaseTableDefine.IllustTable}.image_path AS 'image_path'," +
              $"{DataBaseTableDefine.SkillTable}.parent AS 'parent', " +
              $"{DataBaseTableDefine.SkillTable}.skill_path AS 'skill_path' " +
              $"FROM {DataBaseTableDefine.SkillTable} " +
              $"LEFT JOIN {DataBaseTableDefine.SkillNameTable} " +
              $"ON {DataBaseTableDefine.SkillTable}.skill_index = {DataBaseTableDefine.SkillNameTable}.skill_index " +
              $"LEFT JOIN {DataBaseTableDefine.IllustTable}" +
              $"ON {DataBaseTableDefine.SkillTable}.illust_index = {DataBaseTableDefine.IllustTable}.illust_index" +
              $"LEFT JOIN {DataBaseTableDefine.SkillDescribeTable} " +
              $"ON {DataBaseTableDefine.SkillTable}.skill_index = {DataBaseTableDefine.SkillDescribeTable}.skill_index";

        List<Skill> skillList = new List<Skill>();
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        while (true == it.Read()) {
            Skill skill = new Skill();
            skill.name.textKr = it.GetSafeValue<string>(1);
            skill.describe.textKr = it.GetSafeValue<string>(2);
            skill.cooldown = it.GetSafeValue<int>(3);
            skill.illustration.imagePath = it.GetSafeValue<string>(4);
            skill.parent = it.GetSafeValue<int>(5);
            //skill.skillpath = it.GetSafeValue<string>(6);

            skillList.Add(skill);
        }

        return skillList;
    }

    public static Skill GetSelectedSkill(int skillIndex) {
        string query = $"SELECT" +
            $"{DataBaseTableDefine.SkillTable}.skill_index AS 'skill_index', " +
            $"{DataBaseTableDefine.SkillNameTable}.ko_KR AS 'skill_name', " +
            $"{DataBaseTableDefine.SkillDescribeTable}.ko_KR AS 'skill_describe', " +
            $"{DataBaseTableDefine.SkillTable}.cooldown AS 'cooldown', " +
            $"{DataBaseTableDefine.IllustTable}.image_path AS 'image_path'," +
            $"{DataBaseTableDefine.SkillTable}.parent AS 'parent', " +
            $"{DataBaseTableDefine.SkillTable}.skill_path AS 'skill_path' " +
            $"FROM {DataBaseTableDefine.SkillTable} " +
            $"LEFT JOIN {DataBaseTableDefine.SkillNameTable} " +
            $"ON {DataBaseTableDefine.SkillTable}.skill_index = {DataBaseTableDefine.SkillNameTable}.skill_index " +
            $"LEFT JOIN {DataBaseTableDefine.IllustTable}" +
            $"ON {DataBaseTableDefine.IllustTable}.illust_index = {DataBaseTableDefine.IllustTable}.illust_index" +
            $"LEFT JOIN {DataBaseTableDefine.SkillDescribeTable} " +
            $"ON {DataBaseTableDefine.SkillTable}.skill_index = {DataBaseTableDefine.SkillDescribeTable}.skill_index" +
            $"WHERE {DataBaseTableDefine.SkillTable}.skill_index = {skillIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);
        Skill skill = new Skill();

        if (false == it.Read()) {
            return default;
        }
        skill.name.textKr = it.GetSafeValue<string>(1);
        skill.describe.textKr = it.GetSafeValue<string>(2);
        skill.cooldown = it.GetSafeValue<int>(3);
        skill.illustration.imagePath = it.GetSafeValue<string>(4);
        skill.parent = it.GetSafeValue<int>(5);
        //skill.skillpath = it.GetSafeValue<string>(6);
        
        return skill;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDao
{
    public static Area GetArea(int AreaIndex) {
        string query =
            $"SELECT" +
            $"{DataBaseTableDefine.AreaTable}.area_index AS 'area_index'," +
            $"{DataBaseTableDefine.AreaTable}.level AS 'level'," +
            $"{DataBaseTableDefine.AreaTable}.essential_event_list AS 'essential_event_list'," +
            $"{DataBaseTableDefine.AreaTable}.parent AS 'parent'," +
            $"{DataBaseTableDefine.IllustTable}.image_path AS 'image_path'," +
            $"{DataBaseTableDefine.AreaEnvironmentTable}.ko_KR AS 'area_environment'," +
            $"{DataBaseTableDefine.AreaDescribeTable}.ko_KR AS 'area_describe'," +
            $"{DataBaseTableDefine.AreaProbabilityTable}.main_probability AS 'main_probability'," +
            $"{DataBaseTableDefine.AreaProbabilityTable}.area_probability AS 'area_probability'," +
            $"{DataBaseTableDefine.AreaProbabilityTable}.sub_probability AS 'sub_probability'," +
            $"{DataBaseTableDefine.AreaNameTable}.ko_KR AS 'area_name'" +
            $"FROM {DataBaseTableDefine.AreaTable} "+
            $"LEFT JOIN {DataBaseTableDefine.AreaEnvironmentTable} "+
            $"ON {DataBaseTableDefine.AreaTable}.environment_index = {DataBaseTableDefine.AreaEnvironmentTable}.environment_index" +
            $"LEFT JOIN {DataBaseTableDefine.AreaDescribeTable} "+
            $"ON {DataBaseTableDefine.AreaTable}.area_index = {DataBaseTableDefine.AreaDescribeTable}.area_index" +
            $"LEFT JOIN {DataBaseTableDefine.AreaProbabilityTable} "+
            $"ON {DataBaseTableDefine.AreaTable}.area_index = {DataBaseTableDefine.AreaProbabilityTable}.area_index" +
            $"LEFT JOIN {DataBaseTableDefine.AreaNameTable} "+
            $"ON {DataBaseTableDefine.AreaTable}.area_index = {DataBaseTableDefine.AreaNameTable}.area_index" +
            $"LEFT JOIN {DataBaseTableDefine.IllustTable} "+
            $"ON {DataBaseTableDefine.AreaTable}.illust_index = {DataBaseTableDefine.IllustTable}.illust_index" +
            $"WHERE {DataBaseTableDefine.AreaTable}.area_index = {AreaIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        Area area = new Area();
        area.areaIndex = it.GetSafeValue<int>(0);
        area.level = it.GetSafeValue<int>(1);
        //essential_event_list = it.GetSafeValue<int>(2);
        //parent = it.GetSafeValue<int>(3);
        area.illustration.imagePath = it.GetSafeValue<string>(4);
        area.environment.textKr = it.GetSafeValue<string>(5);
        area.describe.textKr = it.GetSafeValue<string>(6);
        area.probability.mainProbability = it.GetSafeValue<int>(7);
        area.probability.areaProbability = it.GetSafeValue<int>(8);
        area.probability.subProbability = it.GetSafeValue<int>(9);
        area.name.textKr = it.GetSafeValue<string>(10);


        return default;
    }

}

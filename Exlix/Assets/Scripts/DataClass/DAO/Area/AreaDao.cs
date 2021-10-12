using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDao
{
    public static Area GetArea(int AreaIndex) {
        string query =
            $"SELECT " +
            $"{DataBaseTableDefine.AreaTable}.area_index AS 'area_index', " +
            $"{DataBaseTableDefine.AreaTable}.level AS 'level', " +
            $"{DataBaseTableDefine.AreaTable}.essential_event_list AS 'essential_event_list', " +
            $"{DataBaseTableDefine.AreaTable}.parent AS 'parent', " +
            $"{DataBaseTableDefine.IllustTable}.illust_index AS 'illust_index', " +
            $"{DataBaseTableDefine.AreaEnvironmentTable}.ko_KR AS 'area_environment', " +
            $"{DataBaseTableDefine.AreaDescribeTable}.ko_KR AS 'area_describe', " +
            $"{DataBaseTableDefine.AreaProbabilityTable}.main_probability AS 'main_probability', " +
            $"{DataBaseTableDefine.AreaProbabilityTable}.area_probability AS 'area_probability', " +
            $"{DataBaseTableDefine.AreaProbabilityTable}.sub_probability AS 'sub_probability', " +
            $"{DataBaseTableDefine.AreaNameTable}.ko_KR AS 'area_name' " +
            $"FROM {DataBaseTableDefine.AreaTable} "+
            $"LEFT JOIN {DataBaseTableDefine.AreaEnvironmentTable} "+
            $"ON {DataBaseTableDefine.AreaTable}.environment_index = {DataBaseTableDefine.AreaEnvironmentTable}.environment_index " +
            $"LEFT JOIN {DataBaseTableDefine.AreaDescribeTable} "+
            $"ON {DataBaseTableDefine.AreaTable}.area_index = {DataBaseTableDefine.AreaDescribeTable}.area_index " +
            $"LEFT JOIN {DataBaseTableDefine.AreaProbabilityTable} "+
            $"ON {DataBaseTableDefine.AreaTable}.area_index = {DataBaseTableDefine.AreaProbabilityTable}.area_index " +
            $"LEFT JOIN {DataBaseTableDefine.AreaNameTable} "+
            $"ON {DataBaseTableDefine.AreaTable}.area_index = {DataBaseTableDefine.AreaNameTable}.area_index " +
            $"LEFT JOIN {DataBaseTableDefine.IllustTable} "+
            $"ON {DataBaseTableDefine.AreaTable}.illust_index = {DataBaseTableDefine.IllustTable}.illust_index " +
            $"WHERE {DataBaseTableDefine.AreaTable}.area_index = {AreaIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);
        JsonParser jsonParser = new JsonParser();
        if (false == it.Read()) {
            return default;
        }

        Area area = new Area();

        area.areaIndex = it.GetSafeValue<int>(0);
        area.level = it.GetSafeValue<int>(1);
        area.essentialEventList = jsonParser.JsonToObject<List<int>>(it.GetSafeValue<string>(2));
        area.parentAreaList = jsonParser.JsonToObject<List<int>>(it.GetSafeValue<string>(3));
        area.illustration = IllustrationDao.GetIllust(it.GetSafeValue<int>(4));
        area.areaEnvironment = it.GetSafeValue<string>(5);
        area.areaDescribe = it.GetSafeValue<string>(6);
        area.probability = Area.SetAreaProbability(it.GetSafeValue<int>(7), it.GetSafeValue<int>(8), it.GetSafeValue<int>(9));
        area.name = it.GetSafeValue<string>(10);

        return area;
    }

}


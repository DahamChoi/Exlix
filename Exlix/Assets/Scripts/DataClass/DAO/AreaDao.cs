using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDao
{
    private static readonly string AreaTable = "area";
    private static readonly string AreaEnvironmentTable = "area_environment";
    private static readonly string AreaDescribeTable = "area_describe";
    private static readonly string AreaProbabilityTable = "area_probability";
    private static readonly string AreaNameTable = "area_name";
    private static readonly string IllustTable = "illust";

    public static Area GetArea(int AreaIndex) {
        string query =
            $"SELECT" +
            $"{AreaTable}.area_index AS 'area_index'," +
            $"{AreaTable}.level AS 'level'," +
            $"{AreaTable}.essential_event_list AS 'essential_event_list'," +
            $"{AreaTable}.parent AS 'parent'," +
            $"{IllustTable}.image_path AS 'image_path'," +
            $"{AreaEnvironmentTable}.ko_KR AS 'area_environment'," +
            $"{AreaDescribeTable}.ko_KR AS 'area_describe'," +
            $"{AreaProbabilityTable}.main_probability AS 'main_probability'," +
            $"{AreaProbabilityTable}.area_probability AS 'area_probability'," +
            $"{AreaProbabilityTable}.sub_probability AS 'sub_probability'," +
            $"{AreaNameTable}.ko_KR AS 'area_name'" +
            $"FROM {AreaTable} "+
            $"LEFT JOIN {AreaEnvironmentTable} "+
            $"ON {AreaTable}.environment_index = {AreaEnvironmentTable}.environment_index" +
            $"LEFT JOIN {AreaDescribeTable} "+
            $"ON {AreaTable}.area_index = {AreaDescribeTable}.area_index" +
            $"LEFT JOIN {AreaProbabilityTable} "+
            $"ON {AreaTable}.area_index = {AreaProbabilityTable}.area_index" +
            $"LEFT JOIN {AreaNameTable} "+
            $"ON {AreaTable}.area_index = {AreaNameTable}.area_index" +
            $"LEFT JOIN {IllustTable} "+
            $"ON {AreaTable}.illust_index = {IllustTable}.illust_index" +
            $"WHERE {AreaTable}.area_index = {AreaIndex}";

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

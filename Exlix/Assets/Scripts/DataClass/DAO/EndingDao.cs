using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDao
{
    private static readonly string EndingTable = "ending";
    private static readonly string EndingTitleTable = "ending_title";
    private static readonly string EndingDescribeTable = "ending_describe";

    public static Ending GetEnding() {
        string query =
            $"SELECT" +
            $"{EndingTable}.ending_index AS 'ending_index'," +
            $"{EndingTitleTable}.ko_KR AS 'ending_title'," +
            $"{EndingDescribeTable}.ko_KR AS 'ending_describe'," +
            $"{EndingTable}.illust_index AS 'illust_index',"+
            $"FROM {EndingTable}" +
            $"LEFT JOIN {EndingTitleTable}" +
            $"ON {EndingTable}.ending_index = {EndingTitleTable}.ending_index" +
            $"LEFT JOIN {EndingDescribeTable}" +
            $"ON {EndingTable}.ending_index = {EndingDescribeTable}.ending_index";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);
        
        if (false == it.Read()) {
            return default;
        }

        Ending ending = new Ending();

        ending.endingIndex = it.GetSafeValue<int>(1);
        ending.endingTitle = it.GetSafeValue<string>(2);
        ending.endingDescribe = it.GetSafeValue<string>(3);
        
        Illustration endingIllust = new Illustration();
        int illustIndex = it.GetSafeValue<int>(4);

        endingIllust = IllustrationDao.GetIllust(illustIndex);

        ending.illust = endingIllust;

        return ending;
    }
}

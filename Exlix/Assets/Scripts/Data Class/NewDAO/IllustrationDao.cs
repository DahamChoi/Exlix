﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
public class IllustrationDao 
{
    private static readonly string IllustrationTable = "illust";

    public static Illustration GetIllust(int IllustIndex) {
        string query = $"SELECT* FROM {IllustrationTable} WHERE illust_index = {IllustIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        Illustration illust = new Illustration();
        illust.illustNumber = it.GetSafeValue<int>(0);
        illust.imagePath = it.GetSafeValue<string>(1);

        return illust;
    }
}

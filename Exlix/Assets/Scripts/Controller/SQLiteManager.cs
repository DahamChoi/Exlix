using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SQLiteManager : MonoBehaviour {
    private SqliteConnection connection;
    private bool IsOpen = false;

    public SqliteDataReader SelectQuery(string query) {
        ConnectionOpen();

        var cmd = new SqliteCommand(query, connection);
        var result = cmd.ExecuteReader();
        return result;
    }

    public void InsertQuery(string query) {
        ConnectionOpen();

        SqliteCommand command = new SqliteCommand(query, connection);
        command.ExecuteNonQuery();
    }

    public void ConnectionOpen() {
        if (false == IsOpen) {
            string conn = "Data Source=" + Application.dataPath + "/db/sqlite.db;";
            connection = new SqliteConnection(conn);
            connection.Open();
            IsOpen = true;
        }
    }

    public void OnDestroy() {
        if (true == IsOpen) {
            connection.Close();
        }
    }
}

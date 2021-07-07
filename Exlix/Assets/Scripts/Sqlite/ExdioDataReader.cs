using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.ComponentModel;

public class ExdioDataReader {
    private readonly SqliteDataReader SqliteDataReader_;

    public ExdioDataReader(SqliteDataReader sqliteDataReader) {
        SqliteDataReader_ = sqliteDataReader;
    }

    public bool Read() {
        return SqliteDataReader_.Read();
    }

    public T GetSafeValue<T>(int colIndex) {
        object theValue = SqliteDataReader_.GetValue(colIndex);
        Type theValueType = typeof(T);

        if(DBNull.Value != theValue) {
            if(false == IsNullableType(theValueType)) {
                return (T)Convert.ChangeType(theValue, theValueType);
            } 
            else {
                NullableConverter theNullableConverter = new NullableConverter(theValueType);
                return (T)Convert.ChangeType(theValue, theNullableConverter.UnderlyingType);
            }
        }

        return default;
    }

    private static bool IsNullableType(Type theValueType) {
        bool result = (theValueType.IsGenericType && theValueType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
        return result;
    }
}

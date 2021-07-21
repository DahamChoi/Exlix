using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Information {
    private Dictionary<string, object> DataValue = new Dictionary<string, object>();

    public void UpsertData<T>(string key, T value) {
        if (DataValue.ContainsKey(key)) DataValue[key] = value;
        else DataValue.Add(key, value);
    }

    public T GetData<T>(string key) {
        if (DataValue.ContainsKey(key)) {
            Type theValueType = typeof(T);
            object theValue = DataValue[key];
            return (T)Convert.ChangeType(theValue, theValueType);
        }

        return default;
    }
}
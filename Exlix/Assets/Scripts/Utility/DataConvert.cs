using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataConvert<T> {
    public static string ListToString(List<T> _list) {
        if (_list == null) return null;
        string dataString = null;
        _list.Sort();
        foreach (var data in _list) {
            dataString += data;
            dataString += ',';
        }
        dataString.Remove(dataString.LastIndexOf(','));
        return dataString;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataConvert<T> {
    public static string ListToString(List<T> _list) {
        if (_list == null) return null;
        string dataString = null;
        _list.Sort();
        int count = 0;
        foreach (var data in _list) {
            count++;
            dataString += data;
            if (!(count == _list.Count)) dataString += ',';
        }
        return dataString;
    }
    
}

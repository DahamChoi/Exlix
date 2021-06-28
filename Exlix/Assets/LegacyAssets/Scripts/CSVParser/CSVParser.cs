using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CSVParser<T> {
    public readonly string Path;
    public List<T> DataList = new List<T>();
    public CSVParser(string path) {
        Path = path;
    }
    public abstract void ReadData();
}

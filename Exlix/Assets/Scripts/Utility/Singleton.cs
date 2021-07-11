using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour {
    protected Singleton() { }
    private static readonly Lazy<T> Instance = new Lazy<T>();

    public static T GetInstance() {
        return Instance.Value;
    }
}

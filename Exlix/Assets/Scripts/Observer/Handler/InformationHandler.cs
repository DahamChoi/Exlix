using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationHandler : ObserableHandler<Information> {
    public InformationHandler() {
        Information = new Information();
    }

    public void InsertData<T>(string key, T value) {
        Information.UpsertData<T>(key, value);
    }
    
    public T GetData<T>(string key) {
        return Information.GetData<T>(key);
    }
}

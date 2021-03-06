using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationHandler : ObserableHandler<Information> {
    public InformationHandler() {
        Information = new Information();
    }

    public void UpsertData<T>(string key, T value) {
        Information.UpsertData<T>(key, value);
    }
}
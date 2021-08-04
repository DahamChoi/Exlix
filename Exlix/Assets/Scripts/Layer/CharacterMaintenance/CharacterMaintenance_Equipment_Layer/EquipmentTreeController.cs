using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentTreeController : MonoBehaviour
{
    [SerializeField] ScrollRect scrollRect = null;

    void OnEnable() {
        scrollRect.content = (RectTransform)FactoryManager.GetInstance().CreateEquipmentTree(scrollRect.transform).transform;
    }
}

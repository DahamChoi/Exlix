using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterInfo : MonoBehaviour
{
    public GameObject CharacterInfo;
    public Image Arrow;

    bool IsOpened;

    private void Start()
    {
        IsOpened = true;
        OpenCloseCharacterInfo();
    }

    public void OpenCloseCharacterInfo()
    {
        if (IsOpened)
        {
            CharacterInfo.GetComponent<RectTransform>().anchoredPosition = new Vector2(-69.5f, -59.75f); //나중에 애니메이션으로 부드럽게 만들 예정
            Arrow.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, 0, 0);
            IsOpened = false;
        }
        else
        {
            CharacterInfo.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1056.8f, -59.75f); //나중에 애니메이션으로 부드럽게 만들 예정
            Arrow.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, 180, 0);
            IsOpened = true;
        }
            
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAreaButtonController : MonoBehaviour {
    [SerializeField] Sprite ActiveAreaSprite;
    [SerializeField] Sprite UnActiveAreaSprite;
    [SerializeField] Sprite ClearAreaSprite;

    [SerializeField] GameObject SelectAreaPopupObject;
    [SerializeField] Transform Parent;

    [SerializeField] Button SelectAreaButton;
    
    [SerializeField] int AreaNumber;

    private bool isActive = false;

    private void Start() {
        Init();
    }

    public void Init() {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
        AreaDTO area = AreaDAO.SelectArea(AreaNumber);

        if (characterInfo.UnLockedAreaList.Contains(AreaNumber)) {
            SelectAreaButton.image.sprite = ClearAreaSprite;
        }
        else {
            bool isContain = false;
            foreach(var it in area.ParentList) {
                if (characterInfo.UnLockedAreaList.Contains(it)) {
                    isActive = isContain = true;
                    break;
                }
            }

            SelectAreaButton.image.sprite = isContain ? ActiveAreaSprite : UnActiveAreaSprite;
        }

        SelectAreaButton.onClick.AddListener(() => {
            if (isActive) {
                GameObject popup = FactoryManager.GetInstance().CreateSelectAreaPopup(area, Parent);
                // ...
            }
        });
    }
}

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

    [SerializeField] SQLiteManager _SQLiteManager;

    private void Start() {
        Init();
    }

    public void Init() {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo(_SQLiteManager);
        AreaDTO area = AreaDAO.SelectArea(_SQLiteManager, AreaNumber);

        if (characterInfo.UnLockedAreaList.Contains(AreaNumber)) {
            SelectAreaButton.image.sprite = ClearAreaSprite;
        }
        else {
            bool isContain = false;
            foreach(var it in area.ParentList) {
                if (characterInfo.UnLockedAreaList.Contains(it)) {
                    isContain = true;
                    break;
                }
            }

            SelectAreaButton.image.sprite = isContain ? ActiveAreaSprite : UnActiveAreaSprite;
        }

        SelectAreaButton.onClick.AddListener(() => {
            GameObject popup = SelectAreaPopup.Create(SelectAreaPopupObject, Parent, area);
            // ...
        });
    }
}

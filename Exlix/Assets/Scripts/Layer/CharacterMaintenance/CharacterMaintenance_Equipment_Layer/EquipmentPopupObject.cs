using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentPopupObject : MonoBehaviour {
    [SerializeField] Button backgroundButton = null;
    [SerializeField] Button closeButton = null;
    [SerializeField] Button equipButton = null;
    [SerializeField] Image equipmentIconImage = null;
    [SerializeField] Image equipButtonImage = null;
    [SerializeField] Text title = null;
    [SerializeField] Text price = null;
    [SerializeField] Text description = null;
    [SerializeField] Text equipButtonText = null;
    EquipmentDTO equipmentData;

    // Start is called before the first frame update
    void Start() {

    }

    public void Init(EquipmentDTO _equipmentData) {
        equipmentData = _equipmentData;

        backgroundButton.onClick.AddListener(() => {
            Destroy(this.gameObject);
        });
        closeButton.onClick.AddListener(() => {
            Destroy(this.gameObject);
        });
        SetButton();

        equipmentIconImage.sprite = Resources.Load(equipmentData.ImagePath, typeof(Sprite)) as Sprite;
        
        title.text = $"{equipmentData.Name}";
        price.text = $"{equipmentData.Gold}";
        description.text = $"{equipmentData.Explain}";

    }

    void SetButton() {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
        equipButton.onClick.RemoveAllListeners();

        //장착중인 장비
        if (EquipmentType.GetSameEquipmentPartNumber(equipmentData.Number) == equipmentData.Number) {
            //버튼 이미지 변경...
            //equipButtonImage.sprite = Resources.Load(ImagePath..., typeof(Sprite)) as Sprite;
            equipButtonText.text = $"{CommonDefineKR.UnequipEquipmentString}";
            equipButton.interactable = true;
            
            equipButton.onClick.AddListener(() => {
                EquipmentType.GetSameEquipmentPartRefNumber(ref characterInfo, equipmentData.Number) = 0;
                CharacterInfoDAO.UpdatePlayerInfo(characterInfo);
                SceneState.GetInstance()._UIStateHandler.NotifyObservers();
                SetButton();
            });
        }
        //해금완료된 장비
        else if (characterInfo.HaveEquipmentList.Contains(equipmentData.Number)) {
            //버튼이미지 변경...
            //equipButtonImage.sprite = Resources.Load(ImagePath..., typeof(Sprite)) as Sprite;
            equipButtonText.text = $"{CommonDefineKR.EquipEquipmentString}";
            equipButton.interactable = true;

            equipButton.onClick.AddListener(() => {
                EquipmentType.GetSameEquipmentPartRefNumber(ref characterInfo, equipmentData.Number) = equipmentData.Number;
                //...
                //equipButtonImage.sprite = Resources.Load(ImagePath..., typeof(Sprite)) as Sprite;
                CharacterInfoDAO.UpdatePlayerInfo(characterInfo);
                SceneState.GetInstance()._UIStateHandler.NotifyObservers();
                SetButton();
            });
        }
        //해금이 가능한 장비
        else if (characterInfo.HaveEquipmentList.Contains(equipmentData.Parent)) {
            //버튼이미지 변경...
            //equipButtonImage.sprite = Resources.Load(ImagePath..., typeof(Sprite)) as Sprite;
            equipButtonText.text = $"{CommonDefineKR.UnlockEquipmentString}";
            equipButton.interactable = true;

            equipButton.onClick.AddListener(() => {
                characterInfo.HaveEquipmentList.Add(equipmentData.Number);
                //...
                CharacterInfoDAO.UpdatePlayerInfo(characterInfo);
                SceneState.GetInstance()._UIStateHandler.NotifyObservers();
                SetButton();
            });
        }
        //상위노드의 해금이 필요한 장비
        else {
            //버튼이미지 변경...
            //equipButtonImage.sprite = Resources.Load(ImagePath..., typeof(Sprite)) as Sprite;
            equipButtonText.text = $"{CommonDefineKR.LockedEquipmentString}";
            equipButton.interactable = false;
            equipButton.image.color = Color.black;//비활성화상태 처리

        }
        
    }

}

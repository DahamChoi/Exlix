using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PortraitObject : MonoBehaviour
{
    private PortraitDTO PortraitData;
    [SerializeField] Image Portrait;
    [SerializeField] Button PortraitButton;
    //[SerializeField] Text Name;
    string ImagePath;

    private void Start() {
        PortraitButton.onClick.AddListener(() => { 
            //해당 초상화의 번호를 넘겨줌. 어디에? 플레이어 스테이트 인포에.어떻게? 나도 몰라 시발
                
        });
    }
    public void init(PortraitDTO portraitData) {
        PortraitData = portraitData;
        ImagePath = PortraitData.ImagePath;
        //Name.text = PortraitData.Name;
        Portrait.sprite = Resources.Load(ImagePath, typeof(Sprite)) as Sprite;
    }
}

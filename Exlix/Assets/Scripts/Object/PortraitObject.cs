using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PortraitObject : MonoBehaviour
{
    private PortraitDTO PortraitData;
    [SerializeField] Image Portrait;
    //[SerializeField] Text Name;
    string ImagePath;
    public void init(PortraitDTO portraitData) {
        PortraitData = portraitData;

        ImagePath = PortraitData.ImagePath;
        //Name.text = PortraitData.Name;

        Portrait.sprite = Resources.Load(ImagePath, typeof(Sprite)) as Sprite;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOption : MonoBehaviour
{
    public GameObject OptionPopup;
    public GameObject PopupCloser;
    public void OpenSettingScreen() {
        OptionPopup.SetActive(true);
        PopupCloser.SetActive(true);
    }
    public void CloseSettingScreen() {
        OptionPopup.SetActive(false);
        PopupCloser.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStageSelect : MonoBehaviour
{
    public GameObject PopupScreen;
    public void OpenStagePopup() {
        PopupScreen.SetActive(true);
    }
    public void CloseStagePopup() {
        PopupScreen.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPortrait : MonoBehaviour
{
    public GameObject PortraitPopup;
    public GameObject PortraitPopupCloser;

    public void OpenPortraitScreen()
    {
        if (PortraitPopup.activeSelf == true)
        {
            PortraitPopup.SetActive(false);
            PortraitPopupCloser.SetActive(false);
        }
        else
        {
            PortraitPopup.SetActive(true);
            PortraitPopupCloser.SetActive(true);
        }
    }
    public void ClosePortraitScreen()
    {
        PortraitPopup.SetActive(false);
        PortraitPopupCloser.SetActive(false);
    }

    public void ConfirmPortrait()
    {
        PortraitPopup.SetActive(false);
        PortraitPopupCloser.SetActive(false);
    }

    public void SelectPortrait()
    {

    }
}

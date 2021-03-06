using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInputName : MonoBehaviour
{
    public GameObject InputNameScreen;
    public GameObject InputNameCloser;
    public Text InputNameText;
    public Text OutpuNameText;
    public List<string> RandomNames;

    string Title;

    public void OpenInputNameScreen()
    {
        if (InputNameScreen.activeSelf == true)
        {
            InputNameScreen.SetActive(false);
            InputNameCloser.SetActive(false);
        }
        else
        {
            InputNameScreen.SetActive(true);
            InputNameCloser.SetActive(true);
        }
    }
    public void CloseInputNameScreen()
    {
        InputNameScreen.SetActive(false);
        InputNameCloser.SetActive(false);
    }

    public void ConfirmName()
    {
        Title = InputNameText.text;
        OutpuNameText.text = Title;
    }

    public void InputRandomName()
    {
        int nameNum = Random.Range(0, RandomNames.Count);
        OutpuNameText.text = RandomNames[nameNum];
    }
}

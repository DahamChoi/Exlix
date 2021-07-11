using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBarController : MonoBehaviour {
    [SerializeField] GameObject OptionPopupScreen;
    [SerializeField] GameObject OptionPopupCloser;

    [SerializeField] Button OptionButton;
    [SerializeField] Button OptionCloseButton;
    [SerializeField] Button BackButton;

    void Start() {
        OptionButton.onClick.AddListener(() => {
            bool active = !OptionPopupScreen.activeSelf;
            OptionPopupScreen.SetActive(active);
            OptionPopupCloser.SetActive(active);
        });

        OptionCloseButton.onClick.AddListener(() => {
            OptionPopupScreen.SetActive(false);
            OptionPopupCloser.SetActive(false);
        });

        BackButton.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.BACK);
        });
    }
}

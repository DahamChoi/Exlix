using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testscript : MonoBehaviour
{
    [SerializeField] Button testButton = null;
    // Start is called before the first frame update
    void Start()
    {
        testButton.onClick.AddListener(() => {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.END_AREA_EVENT);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

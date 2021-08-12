using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Achieve_Card_Layer : MonoBehaviour
{
    [SerializeField] Button testbutton=null;

    void Start()
    {
        testbutton.onClick.AddListener(()=> {
            SceneState.GetInstance()._SceneStateHandler.ProcessEvent(GameStateMachine.TRIGGER.END_ACHEIVE_CARD);
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

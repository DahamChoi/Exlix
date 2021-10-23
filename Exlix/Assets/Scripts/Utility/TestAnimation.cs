using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    [SerializeField] Animator aTest = null;
    AnimatorController acTest;
    System.Action StartAction;
    System.Action EndAction;

    public void TestFuncStartAnimator() {
        Debug.Log("애니메이션 시작함");
    }

    public void TestFuncEndAnimator() {
        Debug.Log("애니메이션 끝남");
    }

        public void TestFuncMidAnimator() {
        Debug.Log("애니메이션 중간");
    }

    // Start is called before the first frame update
    void Start()
    {
        acTest = AnimatorController.Create(aTest, "slash_sfx", TestFuncStartAnimator, TestFuncEndAnimator);
        acTest.AddCallbackEvent("slash_sfx", 0.1f, TestFuncMidAnimator);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

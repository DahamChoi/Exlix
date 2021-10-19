using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {
    Animator controlledAnimator;
    AnimationClip animationClip;
    System.Action beginCallback;
    System.Action midCallback;
    System.Action endCallback;

    //Animation Event
    public void OnBeginEvent() {
        beginCallback?.Invoke();
    }

    public void OnMidEvent() {
        midCallback?.Invoke();
    }

    public void OnEndEvent() {
        endCallback?.Invoke();

    }

    public static AnimatorController Create(Animator _controlledAnimator, string _clipName = "", System.Action _beginCallback = null, System.Action _endCallback = null) {
        AnimatorController animationController = _controlledAnimator.gameObject.AddComponent<AnimatorController>();
        animationController.Init(_controlledAnimator, _clipName, _beginCallback, _endCallback);
        return animationController;
    }

    void Init(Animator _controlledAnimator, string _clipName = "", System.Action _beginCallback = null, System.Action _endCallback = null) {
        controlledAnimator = _controlledAnimator;
        beginCallback = _beginCallback;
        endCallback = _endCallback;
        AddInitCallbackEvents(_clipName);
    }

    void AddInitCallbackEvents(string _clipName) {
        foreach (var item in controlledAnimator.runtimeAnimatorController.animationClips) {
            if (_clipName == item.name) {
                animationClip = item;
            }
        }

        AnimationEvent _startAnimationEvents = new AnimationEvent();
        AnimationEvent _endAnimationEvents = new AnimationEvent();

        _startAnimationEvents.time = 0f;
        _startAnimationEvents.functionName = "OnBeginEvent";
        _endAnimationEvents.time = animationClip.length;
        _endAnimationEvents.functionName = "OnEndEvent";

        animationClip.AddEvent(_startAnimationEvents);
        animationClip.AddEvent(_endAnimationEvents);
    }

    public void AddCallbackEvent(string _clipName = "", float _time = 0, System.Action _midCallback = null) {

        midCallback = _midCallback;
        AnimationEvent _midAnimationEvents = new AnimationEvent();

        _midAnimationEvents.time = _time;
        _midAnimationEvents.functionName = "OnMidEvent";

        animationClip.AddEvent(_midAnimationEvents);
    }
}

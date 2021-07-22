using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {
    Animator controlledAnimator;
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
        Debug.Log("Animaton End Event");
        endCallback?.Invoke();
    }

    public static AnimatorController Create(Animator _controlledAnimator, int _clipIndex = 0, System.Action _beginCallback = null, System.Action _endCallback = null) {
        AnimatorController animationController = _controlledAnimator.gameObject.AddComponent<AnimatorController>();
        animationController.Init(_controlledAnimator, _clipIndex, _beginCallback, _endCallback);
        return animationController;
    }

    void Init(Animator _controlledAnimator, int _clipIndex = 0, System.Action _beginCallback = null, System.Action _endCallback = null) {
        controlledAnimator = _controlledAnimator;
        beginCallback = _beginCallback;
        endCallback = _endCallback;
        AddCallbackEvents(_clipIndex);
    }

    void AddCallbackEvents(int _clipIndex) {
        AnimationClip animationClip = controlledAnimator.runtimeAnimatorController.animationClips[_clipIndex];
        AnimationEvent _startAnimationEvents = new AnimationEvent();
        AnimationEvent _endAnimationEvents = new AnimationEvent();
        animationClip.AddEvent(_startAnimationEvents);
        animationClip.AddEvent(_endAnimationEvents);
        _startAnimationEvents.time = 0f;
        _startAnimationEvents.functionName = "OnBeginEvent";
        _endAnimationEvents.time = animationClip.length;
        _endAnimationEvents.functionName = "OnEndEvent";
    }

    // public void AddMidCallbackEvent(float _time, System.Action _midCallback) {
    //     midCallback = _midCallback;
    //     AnimationEvent _midAnimationEvents = new AnimationEvent();
    //     controlledAnimation.runtimeAnimatorController.animationClips[0].AddEvent(_midAnimationEvents);
    //     _midAnimationEvents.time = 0f;
    //     _midAnimationEvents.functionName = "OnMidEvent";
    // }
}

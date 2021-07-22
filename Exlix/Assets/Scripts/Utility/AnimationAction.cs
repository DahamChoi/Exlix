using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAction : MonoBehaviour {
    Animation controlledAnimation;
    System.Action beginCallback;
    System.Action endCallback;
    float animationTime;
    public AnimationAction(Animation _controlledAnimation, System.Action _beginCallback, System.Action _endCallback) {
        controlledAnimation = _controlledAnimation;
        beginCallback = _beginCallback;
        endCallback = _endCallback;
    }

    public void PlayAnimation() {
        controlledAnimation.Play();
        OnAnimationStart();
        animationTime = controlledAnimation.clip.length;
        StartCoroutine(Timer());
    }

    IEnumerator Timer() {
        yield return new WaitForSeconds(animationTime);
        OnAnimationEnd();
    }

    void OnAnimationStart() {
        beginCallback?.Invoke();
    }

    void OnAnimationEnd() {
        endCallback?.Invoke();
    }
}

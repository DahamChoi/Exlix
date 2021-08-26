using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ending_Layer : MonoBehaviour
{
    [SerializeField]GameObject buttonSet = null;
    [SerializeField]Button deckButton = null;
    [SerializeField]Button endButton = null;
    [SerializeField]Button collectionButton = null;
    [SerializeField] Text deckText = null;
    [SerializeField] Text endText = null;
    [SerializeField] Text collectionText = null;
    [SerializeField]Scrollbar scrollbar = null;

    bool isplaying = false;
    bool isfadeout = false;
    private void Start() {
        buttonSet.SetActive(false);
        scrollbar.value = 1;
    }
    private void Update() {
        if(scrollbar.value <=0.1 && !isplaying) {
            isplaying = true;
            buttonSet.SetActive(true);
            UpdateButtonAlpha(0);
            StartCoroutine(FadeIn());
        }
        else if(scrollbar.value >0.1){
                isplaying = false;
            if (deckButton.image.color.a>=1) {
                StartCoroutine(FadeOut());
            }
        }
    }

    IEnumerator FadeIn() {
        StopCoroutine(FadeOut());
        float fadeCount = deckButton.image.color.a;
        while (fadeCount < 1.0f) {
            fadeCount += 0.1f;
            yield return new WaitForSeconds(0.01f);
            UpdateButtonAlpha(fadeCount);
        }
    }

    IEnumerator FadeOut() {
        StopCoroutine(FadeIn());
        float fadeCount = deckButton.image.color.a;
        while (fadeCount > 0.0f) {
            fadeCount -= 0.1f;
            yield return new WaitForSeconds(0.01f);
            UpdateButtonAlpha(fadeCount);
        }
    }

    void UpdateButtonAlpha(float alpha) {
        deckButton.image.color = new Color(1, 1, 1, alpha);
        endButton.image.color = new Color(1, 1, 1, alpha);
        collectionButton.image.color = new Color(1, 1, 1, alpha);
        deckText.color = new Color(0, 0, 0, alpha);
        endText.color = new Color(0, 0, 0, alpha);
        collectionText.color = new Color(0, 0, 0, alpha);
    }
}

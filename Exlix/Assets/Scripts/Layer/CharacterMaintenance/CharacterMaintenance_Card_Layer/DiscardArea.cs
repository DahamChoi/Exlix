using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardArea : MonoBehaviour {
    public bool onDeleteArea = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        onDeleteArea = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        onDeleteArea = false;
    }
}

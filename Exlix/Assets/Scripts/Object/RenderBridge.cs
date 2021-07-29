using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderBridge : MonoBehaviour {
    Vector3 startPosition = Vector3.zero;
    Vector3 endPosition = Vector3.zero;
    
    

    public void Init(Vector3 start, Vector3 end) {
        startPosition = start;
        endPosition = end;
        this.GetComponent<LineRenderer>().SetPosition(0, startPosition);
        this.GetComponent<LineRenderer>().SetPosition(1, endPosition);
    }
}

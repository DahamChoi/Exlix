using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderBridge : MonoBehaviour {
    Vector3 startPosition = Vector3.zero;
    Vector3 endPosition = Vector3.zero;
    Vector3 parentPosition = Vector3.zero;//현재
    Vector3 parentPosition_2 = Vector3.zero;//과거
    Vector3 offset = Vector3.zero;
    bool initialized = false;
    private void Update() {
        if (initialized) {
            parentPosition = this.gameObject.transform.parent.position;
            offset.x = parentPosition.x - parentPosition_2.x;
            offset.y = parentPosition.y - parentPosition_2.y;
            parentPosition_2 = parentPosition;

            startPosition = new Vector3(startPosition.x + offset.x, startPosition.y + offset.y , startPosition.z + offset.z);
            endPosition = new Vector3(endPosition.x + offset.x, endPosition.y + offset.y, endPosition.z + offset.z);

            this.GetComponent<LineRenderer>().SetPosition(0, startPosition);  
            this.GetComponent<LineRenderer>().SetPosition(1, endPosition);
        }
    }

    public void Init(Vector3 start, Vector3 end) {
        parentPosition = this.gameObject.transform.parent.position;
        parentPosition_2 = this.gameObject.transform.parent.position;
        startPosition = start;
        endPosition = end;
        this.GetComponent<LineRenderer>().SetPosition(0, startPosition);
        this.GetComponent<LineRenderer>().SetPosition(1, endPosition);
        parentPosition = this.transform.parent.position;
        initialized = true;
    }
}

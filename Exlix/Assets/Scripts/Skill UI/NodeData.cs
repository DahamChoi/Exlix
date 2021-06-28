using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeData : MonoBehaviour {
    [SerializeField] NodeData pNode;
    [SerializeField] Image nodeImage;
    public int nodeId;
    public bool isActivated;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (!isActivated) {
            nodeImage.color = new Color(75, 75, 75);
        }
        else if (!isActivated) {
            nodeImage.color = new Color(255, 255, 255);
        }
        CheckPNode();
    }

    void CheckPNode() {
        if (pNode == null) return;
        if (!pNode.isActivated) isActivated = false;
    }
}

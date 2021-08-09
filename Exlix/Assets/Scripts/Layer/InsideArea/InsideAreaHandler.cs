using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideAreaHandler : ObserableHandler<InsideAreaState> {
    public InsideAreaHandler() {
        Information = new InsideAreaState();
    }

    public void AddSentence(int sentenceId) {
        Information.currentSentence = sentenceId;
        base.NotifyObservers();
    }

    public void ClearSelection() {
        Information.selectionList.Clear();
        base.NotifyObservers();
    }
}

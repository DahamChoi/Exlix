using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideAreaHandler : ObserableHandler<InsideAreaState> {
    public InsideAreaHandler() {
        Information = new InsideAreaState();
    }

    public void AddSentence(int sentenceId) {
        Information.currentSentence = sentenceId;
        Information.selectionList.Clear();
        if (SentenceDAO.GetSelectedSentenceInfo(Information.currentSentence).SelectionList != null) {
            Information.isSelected = false;
            foreach (int Key in SentenceDAO.GetSelectedSentenceInfo(Information.currentSentence).SelectionList) {
                Information.selectionList.Add(SelectionDAO.GetSelectedSelectionInfo(Key));
            }
        }
        base.NotifyObservers();
    }

    public void UpdateSelectionText(string selectionText) {
        Information.selectedSelectionText = selectionText;
    }

    public void ClearSelection() {
        Information.selectionList.Clear();
        Information.isSelected = true;
        base.NotifyObservers();
    }
}

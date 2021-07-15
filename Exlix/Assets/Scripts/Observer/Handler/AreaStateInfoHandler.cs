using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaStateInfoHandler : ObserableHandler<AreaStateInfo> {
    public AreaStateInfoHandler() {
        Information = new AreaStateInfo();
    }

    public void SelectSelection(SelectionDTO selection) {
        Information.selectionData = selection;
        Information.isSelected = true;
        base.NotifyObservers();
    }

    public void CreateSelection() {
        Information.isSelected = false;
    }
}

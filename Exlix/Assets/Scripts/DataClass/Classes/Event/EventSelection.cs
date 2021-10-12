using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSelection
{
    public int selectionIndex;
    public Battle battle;
    public Sentence nextSentence;
    public StatRequire requirement;
    public SelectionReward reward;
    public string text;

    static public StatRequire SetStatRequire(int hp, int str, int dex, int _int) {
        StatRequire statReq = new StatRequire();
        statReq.reqHp = hp;
        statReq.reqDex = dex;
        statReq.reqStr = str;
        statReq.reqInt = _int;
        return statReq;
    }

    static public SelectionReward SetSelectionReward(int gold, int exp, List<int> rewardCard, List<int> rewardEquip ) {
        SelectionReward selectionReward = new SelectionReward();

        selectionReward.rewardGold = gold;
        selectionReward.rewardExp = exp;

        List<Card> cardList = new List<Card>();

        for(int i=0; i<rewardCard.Count; i++) {
            Card card = CardDao.GetCard(rewardCard[i]);

            cardList.Add(card);
        }

        selectionReward.rewardCardList = cardList;

        List<Equipment> equipList = new List<Equipment>();

        for(int i=0; i<rewardEquip.Count; i++) {
            Equipment equip = EquipmentDao.GetEquipment(rewardEquip[i]);

            equipList.Add(equip);
        }

        selectionReward.rewardEquipmentList = equipList;

        return selectionReward;
    }
}

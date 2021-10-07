using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class SelectionDao
{
    public static EventSelection GetSelectedSelection(int selectionIndex) {
        string query = $"SELECT" +
              $"{DataBaseTableDefine.SelectionTable}.selection_index AS 'selection_index', " +
              $"{DataBaseTableDefine.SelectionTable}.battle_index AS 'battle_index', " +
              $"{DataBaseTableDefine.SelectionTable}.next_sentence_index AS 'next_sentence_index', " +
              $"{DataBaseTableDefine.StatRequireTable}.req_hp AS 'req_hp', " +
              $"{DataBaseTableDefine.StatRequireTable}.req_str AS 'req_str', " +
              $"{DataBaseTableDefine.StatRequireTable}.req_dex AS 'req_dex', " +
              $"{DataBaseTableDefine.StatRequireTable}.req_int AS 'req_int', " +
              $"{DataBaseTableDefine.SelectionRewardTable}.reward_gold AS 'reward_gold', " +
              $"{DataBaseTableDefine.SelectionRewardTable}.reward_exp AS 'reward_exp', " +
              $"{DataBaseTableDefine.SelectionRewardTable}.reward_card_fk_list AS 'reward_card_fk_list', " +
              $"{DataBaseTableDefine.SelectionRewardTable}.reward_equipment_fk_list AS 'reward_equipment_fk_list', " +
              $"{DataBaseTableDefine.SelectionTextTable}.ko_KR AS 'selection_text'" +
              $"FROM {DataBaseTableDefine.SelectionTable} " +
              $"LEFT JOIN {DataBaseTableDefine.StatRequireTable} " +
              $"ON {DataBaseTableDefine.SelectionTable}.selection_index = {DataBaseTableDefine.StatRequireTable}.selection_index " +
              $"LEFT JOIN {DataBaseTableDefine.SelectionRewardTable}" +
              $"ON {DataBaseTableDefine.SelectionTable}.selection_index = {DataBaseTableDefine.SelectionRewardTable}.selection_index" +
              $"LEFT JOIN {DataBaseTableDefine.SelectionTextTable} " +
              $"ON {DataBaseTableDefine.SelectionTable}.selection_index = {DataBaseTableDefine.SelectionTextTable}.selection_index" +
              $"WHERE {DataBaseTableDefine.SelectionTable}.selection_index = {selectionIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if(false == it.Read()) {
            return default;
        }

        EventSelection selection = new EventSelection();
        //selection.battle = it.GetSafeValue<int>(1);
        selection.nextSentence = SentenceDao.GetSelectecSentence(it.GetSafeValue<int>(2));
        selection.requirement.reqHp = it.GetSafeValue<int>(3);
        selection.requirement.reqStr = it.GetSafeValue<int>(4);
        selection.requirement.reqDex = it.GetSafeValue<int>(5);
        selection.requirement.reqInt = it.GetSafeValue<int>(6);
        selection.reward.rewardGold = it.GetSafeValue<int>(7);
        selection.reward.rewardExp = it.GetSafeValue<int>(8);
        //selection.reward.rewardCardList = it.GetSafeValue<int>(9);
        //selection.reward.rewardEquipmentList = it.GetSafeValue<int>(10);
        selection.text.textKr = it.GetSafeValue<string>(11);

        return selection;
    }

}

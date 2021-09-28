using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class SelectionDao
{
    private static readonly string SelectionTable = "selection";
    private static readonly string StatRequireTable = "selection_stat_req";
    private static readonly string SelectionRewardTable = "selection_reward";
    private static readonly string SelectionTextTable = "selection_text";

    public static EventSelection GetSelectedSelection(int selectionIndex) {
        string query = $"SELECT" +
              $"{SelectionTable}.selection_index AS 'selection_index', " +
              $"{SelectionTable}.battle_index AS 'battle_index', " +
              $"{SelectionTable}.next_sentence_index AS 'next_sentence_index', " +
              $"{StatRequireTable}.req_hp AS 'req_hp', " +
              $"{StatRequireTable}.req_str AS 'req_str', " +
              $"{StatRequireTable}.req_dex AS 'req_dex', " +
              $"{StatRequireTable}.req_int AS 'req_int', " +
              $"{SelectionRewardTable}.reward_gold AS 'reward_gold', " +
              $"{SelectionRewardTable}.reward_exp AS 'reward_exp', " +
              $"{SelectionRewardTable}.reward_card_fk_list AS 'reward_card_fk_list', " +
              $"{SelectionRewardTable}.reward_equipment_fk_list AS 'reward_equipment_fk_list', " +
              $"{SelectionTextTable}.ko_KR AS 'selection_text'" +
              $"FROM {SelectionTable} " +
              $"LEFT JOIN {StatRequireTable} " +
              $"ON {SelectionTable}.selection_index = {StatRequireTable}.selection_index " +
              $"LEFT JOIN {SelectionRewardTable}" +
              $"ON {SelectionTable}.selection_index = {SelectionRewardTable}.selection_index" +
              $"LEFT JOIN {SelectionTextTable} " +
              $"ON {SelectionTable}.selection_index = {SelectionTextTable}.selection_index" +
              $"WHERE {SelectionTable}.selection_index = {selectionIndex}";

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

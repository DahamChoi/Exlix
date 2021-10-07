using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentRewardDao
{
    public static EquipmentReward GetEquipmentReward(int rewardIndex) {
        string query =
       $"SELECT" +
       $"{DataBaseTableDefine.EquipmentRewardTable}.equipment_reward_index AS 'equipment_reward_index'," +
       $"{DataBaseTableDefine.EquipmentRewardTable}.equipment_index AS 'equipment_index'," +
       $"{DataBaseTableDefine.EquipmentRewardProbabilityTable}.probability AS 'probability'" +
       $"FROM {DataBaseTableDefine.EquipmentRewardTable} " +
       $"LEFT JOIN {DataBaseTableDefine.EquipmentRewardProbabilityTable}" +
       $"ON {DataBaseTableDefine.EquipmentRewardTable}.probability_index = {DataBaseTableDefine.EquipmentRewardProbabilityTable}.probability_index" +
       $"WHERE {DataBaseTableDefine.EquipmentRewardTable}.equipment_reward_index = {rewardIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        EquipmentReward reward = new EquipmentReward();

        reward.equipmentRewardIndex = it.GetSafeValue<int>(1);

        Equipment equipmentReward = new Equipment();
        int equipIndex = it.GetSafeValue<int>(2);
        reward.rewardEquipment = EquipmentDao.GetEquipment(equipIndex);

        reward.probability = it.GetSafeValue<int>(3);

        return reward;
    }
}

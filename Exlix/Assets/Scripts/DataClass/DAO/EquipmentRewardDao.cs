using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentRewardDao
{
    private static readonly string EquipmentRewardTable = "equipment_reward";
    private static readonly string EquipmentRewardProbabilityTable = "equipment_reward_probability";

    public static EquipmentReward GetEquipmentReward(int rewardIndex) {
        string query =
       $"SELECT" +
       $"{EquipmentRewardTable}.equipment_reward_index AS 'equipment_reward_index'," +
       $"{EquipmentRewardTable}.equipment_index AS 'equipment_index'," +
       $"{EquipmentRewardProbabilityTable}.probability AS 'probability'" +
       $"FROM {EquipmentRewardTable} " +
       $"LEFT JOIN {EquipmentRewardProbabilityTable}" +
       $"ON {EquipmentRewardTable}.probability_index = {EquipmentRewardProbabilityTable}.probability_index" +
       $"WHERE {EquipmentRewardTable}.equipment_reward_index = {rewardIndex}";

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

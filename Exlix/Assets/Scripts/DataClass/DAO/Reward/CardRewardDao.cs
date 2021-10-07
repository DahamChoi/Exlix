using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRewardDao
{
    public static CardReward GetCardReward(int rewardIndex) {
        string query =
            $"SELECT" +
            $"{DataBaseTableDefine.CardRewardTable}.card_reward_index AS 'card_reward_index'," +
            $"{DataBaseTableDefine.CardRewardTable}.card_number AS 'card_number'," +
            $"{DataBaseTableDefine.CardRewardProbability}.probability AS 'probability'" +
            $"FROM {DataBaseTableDefine.CardRewardTable} "+
            $"LEFT JOIN {DataBaseTableDefine.CardRewardProbability} "+
            $"ON {DataBaseTableDefine.CardRewardTable}.probability_index = {DataBaseTableDefine.CardRewardProbability}.probability_index" +
            $"WHERE {DataBaseTableDefine.CardRewardTable}.card_reward_index = {rewardIndex}";


        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        CardReward reward = new CardReward();

        reward.cardRewardIndex = it.GetSafeValue<int>(1);

        //Card cardReward = new Card();
        //int cardIndex = it.GetSafeValue<int>(2);
        //reward.cardReward = CardDao.GetCard(cardIndex);

        reward.probability = it.GetSafeValue<int>(3);

        return reward;
    }
}

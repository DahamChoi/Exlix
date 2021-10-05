using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRewardDao
{
    private static readonly string CardRewardTable = "card_reward";
    private static readonly string CardRewardProbability = "card_reward_probability";
    public static CardReward GetCardReward(int rewardIndex) {
        string query =
            $"SELECT" +
            $"{CardRewardTable}.card_reward_index AS 'card_reward_index'," +
            $"{CardRewardTable}.card_number AS 'card_number'," +
            $"{CardRewardProbability}.probability AS 'probability'" +
            $"FROM {CardRewardTable} "+
            $"LEFT JOIN {CardRewardProbability} "+
            $"ON {CardRewardTable}.probability_index = {CardRewardProbability}.probability_index" +
            $"WHERE {CardRewardTable}.card_reward_index = {rewardIndex}";


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

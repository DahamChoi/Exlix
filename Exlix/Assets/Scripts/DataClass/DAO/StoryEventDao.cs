using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class StoryEventDao {
    private static readonly string EventTable = "story_event";
    private static readonly string RegionTable = "story_event_region";
    private static readonly string EventTypeTable = "story_event_type";

    public static StoryEvent GetSelectedEvent(int eventIndex) {
        string query =
            $"SELECT" +
            $"{EventTable}.story_event_index AS 'story_event_index'," +
            $"{EventTable}.start_sentence_index AS 'start_sentence_index'," +
            $"{EventTypeTable}.ko_KR AS 'story_event_type'" +
            $"{EventTable}.story_event_level AS 'story_event_level'" +
            $"{RegionTable}.ko_KR AS 'story_event_region'" +
            $"FROM {EventTable} " +
            $"LEFT JOIN {EventTypeTable}" +
            $"ON {EventTable}.story_event_type_index = {EventTypeTable}.story_event_type_index" +
            $"LEFT JOIN {RegionTable}" +
            $"ON {EventTable}.story_event_region_index = {RegionTable}.story_event_region_index" +
            $"WHERE {EventTable}.equipment_reward_index = {eventIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        StoryEvent storyEvent = new StoryEvent();
        storyEvent.storyEventIndex = it.GetSafeValue<int>(0);
        storyEvent.startSentence = SentenceDao.GetSelectecSentence(it.GetSafeValue<int>(1));
        storyEvent.storyEventType.textKr = it.GetSafeValue<string>(2);
        storyEvent.storyEventLevel = it.GetSafeValue<int>(3);
        storyEvent.storyEventRegion.textKr = it.GetSafeValue<string>(4);

        return default;
    }
    
}

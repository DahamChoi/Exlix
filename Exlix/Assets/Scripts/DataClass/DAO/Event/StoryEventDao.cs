using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class StoryEventDao {
    public static StoryEvent GetSelectedEvent(int eventIndex) {
        string query =
            $"SELECT" +
            $"{DataBaseTableDefine.EventTable}.story_event_index AS 'story_event_index'," +
            $"{DataBaseTableDefine.EventTable}.start_sentence_index AS 'start_sentence_index'," +
            $"{DataBaseTableDefine.EventTypeTable}.ko_KR AS 'story_event_type'," +
            $"{DataBaseTableDefine.EventTable}.story_event_level AS 'story_event_level'," +
            $"{DataBaseTableDefine.RegionTable}.ko_KR AS 'story_event_region'" +
            $"FROM {DataBaseTableDefine.EventTable} " +
            $"LEFT JOIN {DataBaseTableDefine.EventTypeTable}" +
            $"ON {DataBaseTableDefine.EventTable}.story_event_type_index = {DataBaseTableDefine.EventTypeTable}.story_event_type_index" +
            $"LEFT JOIN {DataBaseTableDefine.RegionTable}" +
            $"ON {DataBaseTableDefine.EventTable}.story_event_region_index = {DataBaseTableDefine.RegionTable}.story_event_region_index" +
            $"WHERE {DataBaseTableDefine.EventTable}.story_event_index = {eventIndex}";

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

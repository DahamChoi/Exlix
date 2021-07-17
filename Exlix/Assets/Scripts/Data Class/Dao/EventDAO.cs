using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDAO {
    private readonly static string EventTableName = "event";

    public static List<EventDTO> SelectEventByQuery(string region, int level, bool isMain) {
        List<EventDTO> selectedEvent = new List<EventDTO>();

        string kind = isMain ? "main" : "sub";
        string query = $"SELECT * FROM {EventTableName} WHERE region = '{region}' AND level = {level} AND kind = '{kind}';";
        var it = SQLiteManager.GetInstance().SelectQuery(query);

        while(it.Read()) {
            EventDTO eventDTO = new EventDTO();
            eventDTO.Number = it.GetSafeValue<int>(0);
            eventDTO.StartSentece = it.GetSafeValue<int>(1);
            eventDTO.Kind = it.GetSafeValue<string>(2);
            eventDTO.Level = it.GetSafeValue<int>(3);
            eventDTO.Region = it.GetSafeValue<string>(4);
            selectedEvent.Add(eventDTO);
        }

        return selectedEvent;
    }
}

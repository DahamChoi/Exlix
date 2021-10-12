using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public class JsonParser
{
    public string ObjectToJson(object obj) {// 오브젝트 -> 문자열로 된 json (unity -> db)
        return JsonConvert.SerializeObject(obj);
    }

    public T JsonToObject<T>(string jsonData) {// 문자열로 된 json -> 원하는 타입의 객체 (db -> unity)
        return JsonConvert.DeserializeObject<T>(jsonData);
    }
}

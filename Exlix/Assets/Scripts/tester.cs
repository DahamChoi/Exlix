using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public class tester : MonoBehaviour
{
    public void test() {
        Sentence test = SentenceDao.GetSelectecSentence(1);

        Battle testBattle = BattleDao.GetBattle(1);
    }
}

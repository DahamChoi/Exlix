using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book_Layer_EnemyListController : MonoBehaviour
{
    [SerializeField] Transform enemyContainer = null;
    List<GameObject> enemyObjectList = new List<GameObject>();

    void OnEnable() {
        if(enemyObjectList != null) {
            foreach (GameObject enemyObject in enemyObjectList) {
                Destroy(enemyObject);
            }
            enemyObjectList.Clear();
        }

        List<int> enemyEntireList = new List<int>();
        //... 리스트 불러오기
        if (enemyEntireList != null) return;
        foreach(var enemyData in enemyEntireList) {
        //... Add List 팩토리 매니져
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCardText : MonoBehaviour {
	CardDataTemplate cardData;
	[SerializeField] int cardNum;

	[SerializeField] Text property;
	[SerializeField] Text cost;
	[SerializeField] Text name;
	[SerializeField] Text explain;

	// Start is called before the first frame update
	void Start() {
		cardData = GameObject.Find("GameManager").GetComponent<GameManager>().CardParser.DataList[cardNum];
		property.text = cardData.Property;
		cost.text = cardData.Cost.ToString();
		name.text = cardData.Name;
		explain.text = cardData.Explanation;
		explain.text.Replace("다음", "asd");
	}

	// Update is called once per frame
	void Update() {

	}
}

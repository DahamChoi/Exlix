using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCardText : MonoBehaviour {

	[SerializeField] Text property = null;
	[SerializeField] Text cost = null;
	[SerializeField] Text title = null;
	[SerializeField] Text explain = null;

	public void ReadText(CardDataTemplate cardData) {
		property.text = cardData.GetCardData("Property");
		cost.text = cardData.GetCardData("Cost");
		title.text = cardData.GetCardData("Title");
		explain.text = cardData.GetCardData("Explanation").Replace("<br>", "\n");
	}

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}
}

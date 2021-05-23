using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCardText : MonoBehaviour {

	[SerializeField] Text property;
	[SerializeField] Text cost;
	[SerializeField] Text name;
	[SerializeField] Text explain;

	public void ReadText(CardDataTemplate cardData) {
		property.text = cardData.Property;
		cost.text = cardData.Cost.ToString();
		name.text = cardData.Name;
		explain.text = cardData.Explanation.Replace("<br>", "\n");
	}

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCardScreen : MonoBehaviour {
	[SerializeField] GameObject ExampleCard;
	[SerializeField] GameObject Pannel;
	// Start is called before the first frame update
	void Start() {
		GameObject gameManager = GameObject.Find("GameManager");
		foreach (var cardData in gameManager.GetComponent<GameManager>().CardParser.DataList) {
			GameObject tempCard = Instantiate(ExampleCard, transform.position, transform.rotation);
			tempCard.GetComponent<TestCardText>().ReadText(cardData);
			tempCard.transform.SetParent(Pannel.transform);
		}
	}

	// Update is called once per frame
	void Update() {

	}
}

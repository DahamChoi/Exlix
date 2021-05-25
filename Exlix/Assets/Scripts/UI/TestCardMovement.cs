using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCardMovement : MonoBehaviour {

	[SerializeField] List<GameObject> testCards = new List<GameObject>();
	[SerializeField] GameObject ExampleCard;
	public Transform CardPosition;
	int maxCard = 10;

	CardDataTemplate tCard;
	// Start is called before the first frame update
	void Start() {
		tCard = GameObject.Find("GameManager").GetComponent<GameManager>().CardParser.DataList[0];
	}

	// Update is called once per frame
	void Update() {

	}


	public void addCard() {
		GameObject tempCard = Instantiate(ExampleCard, CardPosition.position, CardPosition.rotation, CardPosition.transform);
		tempCard.GetComponent<TestCardText>().ReadText(tCard);
		testCards.Add(tempCard);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardHand : MonoBehaviour
{
    public float rotateAngle = 2.0f;
    public float rotateSpeed = 80.0f;
    public float slowMoveSpeed = 6.0f;
    public float cardBigScale = 0.9f;
    public float scaleSpeed = 10000.0f;
    public float moveSpeed = 10000.0f;
    public float offsetAngleDelta = 1.8f;
    public float cardNormalScale = 0.8f;
    public float slowScaleSpeed = 1.0f;
    public float mouseOnInterval = 0.5f;
    public float nonInteractDelay = 0.5f;
    public float leftPushAngle = 2.0f;
    public float rightPushAngle = 2.0f;
    public float sendCardMoveSpeed = 20.0f;
    public float sendCardScaleSpeed = 10.0f;
    public Vector3 centerPoint = new Vector3(0.0f, -50.0f, 0.0f);

    public List<int> handData = new List<int>();
    public List<Card> myHands = new List<Card>();
    public Transform HandPosition;
    public Transform DeckPosition;
    public Transform GravePosition;

    public float centerRadius = 46.0f;//centerPoint로부터 카드의 postition까지의 반지름
    public float popUpOffsetY = 1.0f;
    public float popUpOffsetZ = -5.0f;

    public GameObject HandPrefab;
    public GameObject cardPrefab;
    
    public Button drawBtn;

    private Queue<Card> myDeck = new Queue<Card>();
    private Queue<Card> myGraveYard = new Queue<Card>();

    private const int HAND_LIMIT = 10;
    public void InitDeckCards() {
        AddCardToDeck();
        AddCardToDeck();
        AddCardToDeck();
        AddCardToDeck();
        AddCardToDeck();
        AddCardToDeck();
        AddCardToDeck();
        AddCardToDeck();
        AddCardToDeck();
        AddCardToDeck();
        AddCardToDeck();
    }

    private void AddCardToDeck() {//덱에 카드를 추가하는 함수
        Card card = new Card();
        //card info 넣어주는 부분 추가 필요.
        card.Instance = (GameObject)Instantiate(cardPrefab);
        card.Instance.SetActive(false);
        myDeck.Enqueue(card);
    }
    public void AddCardToHand() {
        if (myDeck.Count == 0) {
            //덱에 카드가 없을때 메세지 출력
            //return;
        }
        if(myHands.Count >= HAND_LIMIT) {
            //핸드에 카드가 가득할때 메세지 출력
            //return;
        }

        Card card = DrawCardFromDeck();
        card.MoveSpeed = sendCardMoveSpeed;
        card.TargetScale = cardNormalScale;
        card.ScaleSpeed = sendCardScaleSpeed;
        card.Instance.transform.position = new Vector3(DeckPosition.position.x, DeckPosition.position.y, -0.1f);//카드를 뽑았을때 덱 위에서 생성
        card.Instance.transform.localScale = new Vector3(0.5f, 0.5f, 0.0f);
        card.Instance.name = "Card:" + (myHands.Count).ToString();
        card.Instance.GetComponent<SpriteRenderer>().sortingOrder = myHands.Count;//카드 레이어 정렬
        myHands.Add(card);

        CalCardsTransform();
    }

    private Card DrawCardFromDeck() {
        var card = myDeck.Dequeue();
        card.Instance.SetActive(true);
        return card;
    }

    void CalCardsTransform() {
            Card card = null;
            for (int i = 0; i < myHands.Count; i++) {     
                card = myHands[i];
                card.TargetAngle = OriginalAngle(i);
                card.TargetPosition = FallDownPosition(i);
                card.Instance.transform.position = new Vector3(card.Instance.transform.position.x, card.Instance.transform.position.y, 0.0f);
        }
    }
    private float OriginalAngle(int idx) {
        float leftAngle = (myHands.Count - 1) * rotateAngle / 2;
        return leftAngle - idx * rotateAngle;
    }
    private Vector3 FallDownPosition(int idx) {
        float angle = OriginalAngle(idx) + myHands[idx].OffsetAngle;
        return new Vector3(centerPoint.x - centerRadius * Mathf.Sin(ConvertAngleToArc(angle)), centerPoint.y + centerRadius * Mathf.Cos(ConvertAngleToArc(angle)), 0.0f);
    }

    private void UpdateCardRotate() {
        foreach (Card card in myHands) {
            Transform transform = card.Instance.transform;
            if (Mathf.Abs(card.CurAngle - card.TargetAngle) <= Time.fixedDeltaTime * rotateSpeed) {
                card.CurAngle = card.TargetAngle;
                transform.rotation = Quaternion.Euler(0, 0, card.TargetAngle);
            }
            else if (card.CurAngle > card.TargetAngle) {
                card.CurAngle -= Time.fixedDeltaTime * rotateSpeed;
                transform.Rotate(0, 0, -Time.fixedDeltaTime * rotateSpeed);
            }
            else {
                card.CurAngle += Time.fixedDeltaTime * rotateSpeed;
                transform.Rotate(0, 0, Time.fixedDeltaTime * rotateSpeed);
            }
        }
    }
    private void UpdateCardPosition() {
        foreach (var card in myHands) {
            Transform transform = card.Instance.transform;
            Debug.Log(card.TargetPosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, card.TargetPosition.z);
            if ((transform.position - card.TargetPosition).magnitude <= Time.fixedDeltaTime * card.MoveSpeed) {
                transform.position = card.TargetPosition;
                card.MoveSpeed = slowMoveSpeed;
            }
            else {
                transform.position = Vector3.MoveTowards(transform.position, card.TargetPosition, Time.fixedDeltaTime * card.MoveSpeed);
            }
        }
    }

    public static float ConvertAngleToArc(float angle) {
        return angle * Mathf.PI / 180;
    }

    public static float GetAngleByVector(float len_x, float len_y) {
        if (len_y == 0) {
            if (len_x < 0) {
                return 270;
            }
            else if (len_x > 0) {
                return 90;
            }
            return 0;
        }
        if (len_x == 0) {
            if (len_y >= 0) {
                return 0;
            }
            else if (len_y < 0) {
                return 180;
            }
        }

        float angle = 0;
        if (len_y > 0 && len_x > 0) {
            angle = 270 + Mathf.Atan2(Mathf.Abs(len_y), Mathf.Abs(len_x)) * 180 / Mathf.PI;
        }
        else if (len_y > 0 && len_x < 0) {
            angle = 90 - Mathf.Atan2(Mathf.Abs(len_y), Mathf.Abs(len_x)) * 180 / Mathf.PI;
        }
        else if (len_y < 0 && len_x > 0) {
            angle = 270 - Mathf.Atan2(Mathf.Abs(len_y), Mathf.Abs(len_x)) * 180 / Mathf.PI;
        }
        else if (len_y < 0 && len_x < 0) {
            angle = Mathf.Atan2(Mathf.Abs(len_y), Mathf.Abs(len_x)) * 180 / Mathf.PI + 90;
        }
        return angle;
    }

    private void AddButtonListener() {
        drawBtn.GetComponent<Button>().onClick.AddListener(()=> AddCardToHand());
    }

    private void Awake() {
        AddButtonListener();
    }
    void Start()
    {
        InitDeckCards();
    }

    void Update()
    {
    }
    private void FixedUpdate() {
            UpdateCardRotate();
            UpdateCardPosition();
    }
}

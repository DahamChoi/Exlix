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
    public Vector3 centerPoint = new Vector3(0.0f, -50.0f, 0.0f);
    private int focusOnCard = -1;
    private float cardHalfSize = 0.0f;
    private int lastFrameMouseOn = -1;
    private int mouseClickCard = -1;
    public float offsetAngleDelta = 1.8f;
    public float cardNormalScale = 0.8f;
    public float slowScaleSpeed = 1.0f;
    public float mouseOnInterval = 0.5f;
    public float nonInteractDelay = 0.5f;
    public float leftPushAngle = 2.0f;
    public float rightPushAngle = 2.0f;
    public float sendCardMoveSpeed = 20.0f;
    public float sendCardScaleSpeed = 10.0f;

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

    }

    private void AddCardToDeck() {//덱에 카드를 추가하는 함수
        Card card = new Card();
        //card info 넣어주는 부분 추가 필요.
        card.Instance = (GameObject)Instantiate(this.cardPrefab);
        card.Instance.SetActive(false);
        this.myDeck.Enqueue(card);
    }
    public void AddCardToHand() {
        if (this.myDeck.Count == 0) {
            //덱에 카드가 없을때 메세지 출력
            //return;
        }
        if(this.myHands.Count >= HAND_LIMIT) {
            //핸드에 카드가 가득할때 메세지 출력
            //return;
        }

        Card card = this.DrawCardFromDeck();
        card.MoveSpeed = this.sendCardMoveSpeed;
        card.TargetScale = this.cardNormalScale;
        card.ScaleSpeed = this.sendCardScaleSpeed;
        card.NonInteractBegin = Time.time;
        card.Instance.transform.position = new Vector3(this.DeckPosition.position.x, this.DeckPosition.position.y, -0.1f);//카드를 뽑았을때 덱 위에서 생성
        card.Instance.transform.localScale = new Vector3(0.5f, 0.5f, 0.0f);
        card.Instance.transform.parent = this.HandPosition.transform;
        card.Instance.name = "Card:" + (this.myHands.Count).ToString();
        card.Instance.GetComponent<SpriteRenderer>().sortingOrder = this.myHands.Count;//카드 레이어 정렬
        this.myHands.Add(card);

        this.CalCardsTransform(true);
    }

    private Card DrawCardFromDeck() {
        var card = this.myDeck.Dequeue();
        card.Instance.SetActive(true);
        return card;
    }

    void CalCardsTransform(bool force_update = false) {
        int idx = this.MouseOnCard();

        if (idx >= -1 || force_update == true) {//
            Card card = null;
            for (int i = 0; i < myHands.Count; i++) {
                if (i == idx) continue;           
                card = myHands[i];
                card.TargetAngle = OriginalAngle(i);
                card.TargetPosition = FallDownPosition(i);
                card.Instance.transform.position = new Vector3(card.Instance.transform.position.x, card.Instance.transform.position.y, 0.0f);
            }
            if (idx >= 0) {
                card = myHands[idx];
                card.TargetPosition = PushUpPosition(idx);
                card.Instance.transform.position = new Vector3(card.Instance.transform.position.x, card.Instance.transform.position.y, -10.0f);
                card.TargetAngle = 0.0f;
                card.CurAngle = 0.0f;
                card.Instance.transform.rotation = Quaternion.Euler(0, 0, card.TargetAngle);
            }
        }
    }
    private float OriginalAngle(int idx) {
        float leftAngle = (myHands.Count - 1) * rotateAngle / 2;
        return leftAngle - idx * rotateAngle;
    }
    private Vector3 FallDownPosition(int idx) {
        float angle = OriginalAngle(idx) + this.myHands[idx].OffsetAngle;
        return new Vector3(centerPoint.x - centerRadius * Mathf.Sin(ConvertAngleToArc(angle)), centerPoint.y + centerRadius * Mathf.Cos(ConvertAngleToArc(angle)), 0.0f);
    }

    private Vector3 PushUpPosition(int idx) {
        Vector3 fall_down_position = FallDownPosition(idx);
        return new Vector3(fall_down_position.x, popUpOffsetY, popUpOffsetZ);
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


    private void MouseOnCard(int idx) {
        Card card = myHands[idx];
        GameObject cardgo = card.Instance;
        card.SortOrder = cardgo.GetComponent<SpriteRenderer>().sortingOrder;
        cardgo.GetComponent<SpriteRenderer>().sortingOrder = 100;   
        card.TargetScale = cardBigScale;
        card.MoveSpeed = moveSpeed;
        card.ScaleSpeed = scaleSpeed;
    }
    private int MouseOnCard() {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject.name.StartsWith("Card:")) {
            GameObject cardd = hit.collider.gameObject;
            int idx = int.Parse(hit.collider.gameObject.name.Split(':')[1]);
            Debug.Log(idx);
            if (lastFrameMouseOn != idx) {
                MouseOffCard(lastFrameMouseOn);
                float currentTime = Time.time;
                if (currentTime - myHands[idx].LastOnTime > mouseOnInterval && currentTime - myHands[idx].NonInteractBegin >= nonInteractDelay) {
                    MouseOnCard(idx);
                    OffsetSideCards(idx, leftPushAngle, rightPushAngle);
                    lastFrameMouseOn = idx;
                    myHands[idx].LastOnTime = currentTime;
                    return idx;
                }
                if (lastFrameMouseOn >= 0) {
                    OffsetSideCards(lastFrameMouseOn, 0.0f, 0.0f);
                }
                lastFrameMouseOn = -1;
                return -1;
            }
        }
        else if (lastFrameMouseOn != -1) {
            MouseOffCard(lastFrameMouseOn);
            OffsetSideCards(lastFrameMouseOn, 0.0f, 0.0f);
            lastFrameMouseOn = -1;
            return -1;
        }
        return -2;
    }
    private void MouseOffCard(int idx) {
        if (idx == -1) return;
        Card card = myHands[idx];
        GameObject cardgo = card.Instance;
        cardgo.GetComponent<SpriteRenderer>().sortingOrder = card.SortOrder;
        card.TargetScale = cardNormalScale;
        card.MoveSpeed = slowMoveSpeed;
        card.ScaleSpeed = slowScaleSpeed;
    }

    void OffsetSideCards(int idx, float front_angle, float end_angle) {
        int front = idx - 1;
        int end = idx + 1;
        Card card = myHands[idx];
        card.OffsetAngle = 0.0f;
        while (front >= 0) {
            card = myHands[front];
            card.OffsetAngle = front_angle;
            front_angle = Mathf.Max(0.0f, front_angle - offsetAngleDelta);  
            front--;
        }
        while (end < myHands.Count) {
            card = myHands[end];
            card.OffsetAngle = -end_angle;
            end_angle = Mathf.Max(0.0f, end_angle - offsetAngleDelta);   
            end++;
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

    private void DrawButtonClick() {
        this.drawBtn.GetComponent<Button>().onClick.AddListener(()=> this.AddCardToHand());
    }

    private void UpdateOnBoardCard() {
        if (mouseClickCard == -1) return;
        var mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mouse_pos.y >= -3.0f + cardHalfSize / 2) {
            var card = myHands[mouseClickCard];
            focusOnCard = mouseClickCard;
            card.NonInteractBegin = Time.time;
            card.TargetAngle = 0.0f;
            card.Instance.transform.position = new Vector3(card.Instance.transform.position.x, card.Instance.transform.position.y, -10.0f);
            card.TargetPosition = new Vector3(0, -3.0f, -10.0f);
            card.MoveSpeed = (card.Instance.transform.position - FallDownPosition(mouseClickCard)).magnitude * 2 / nonInteractDelay;
        }
        else if (focusOnCard != -1) {
            if (lastFrameMouseOn != -1) {
                this.MouseOffCard(lastFrameMouseOn);
                this.OffsetSideCards(lastFrameMouseOn, 0.0f, 0.0f);
                lastFrameMouseOn = -1;
            }

            var card = myHands[mouseClickCard];
            card.NonInteractBegin = Time.time;
            card.Instance.transform.position = new Vector3(card.Instance.transform.position.x, card.Instance.transform.position.y, 0);
            card.MoveSpeed = (card.Instance.transform.position - FallDownPosition(mouseClickCard)).magnitude * 2 / nonInteractDelay;
            card.ScaleSpeed = slowScaleSpeed;
            this.CalCardsTransform(true);
            mouseClickCard = -1;
            focusOnCard = -1;
        }
    }


    private void Awake() {
        this.DrawButtonClick();
    }
    void Start()
    {
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

    void Update()
    {
        if(this.mouseClickCard == -1) {
            this.CalCardsTransform();
        }

        this.UpdateOnBoardCard();
    }
    private void FixedUpdate() {
            this.UpdateCardRotate();
            this.UpdateCardPosition();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveScene : MonoBehaviour
{
    Stack<int> PreviousScenes = new Stack<int>();
    //캐릭터 처음 생성시 정비씬으로 안가고 인게임씬으로 바로 감. else 정비씬으로 감.
    public void MoveToPreviousScene() {
        SceneManager.LoadScene(PreviousScenes.Pop());
    }
    public void MoveToCreateCharacterScene() {
        PreviousScenes.Push(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("CreateCharacter");
    }
    public void MoveToMainScreenScene() {
        PreviousScenes.Push(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MainScreen");
    }
    public void MoveToSelectDeckScene() {
        PreviousScenes.Push(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("SelectDeck");
    }
    public void MoveToSelectStageScene() {
        PreviousScenes.Push(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("SelectStage");
    }
    public void MoveToMaintenanceScene() {
        PreviousScenes.Push(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Maintenance");
    }
    public void MoveToInGameScene() {
        PreviousScenes.Push(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("InGame");
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

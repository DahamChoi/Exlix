using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveScene : MonoBehaviour
{
    const int MainScreen = 0;
    const int CreateCharacter = 1;
    const int SelectDeck = 2;
    Scene previousScene;
    public void MoveToPreviousScene() {
        SceneManager.LoadScene(previousScene.buildIndex);
    }
    public void MoveToCreateCharacter() {
        SceneManager.LoadScene(CreateCharacter);
    }
    
    public void MoveToMainScene() {
        SceneManager.LoadScene(MainScreen);
    }

    public void MoveToDeckSelectScene() {
        SceneManager.LoadScene(SelectDeck);
    }


    // Start is called before the first frame update
    void Start()
    {
        previousScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

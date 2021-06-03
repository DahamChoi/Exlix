using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveScene : MonoBehaviour
{
    public void MoveToCreateCharacter() {
        SceneManager.LoadScene("CreateCharacter");
    }
    
    public void MoveToMainScene() {
        SceneManager.LoadScene("MainScreen");
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

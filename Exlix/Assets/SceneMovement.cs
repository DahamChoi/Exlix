using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMovement : MonoBehaviour
{
    public void MoveToMainScreen() {
        SceneManager.LoadScene("MainMenu");
    }

    public void MoveToCreateCharacter() {
        SceneManager.LoadScene("CreateCharacter");
    }
}

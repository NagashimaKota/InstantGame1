using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGameButton : MonoBehaviour {

    public void OnButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeforeScene : MonoBehaviour
{ 
    public void BeforeSceneBtn()

    {
        SceneManager.LoadScene("Game Explanation");

    }
}
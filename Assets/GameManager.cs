using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //private scSoundManager scSound;

    #region singleton
    static public GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        //scSound = GetComponent<scSoundManager>();
    }
    #endregion singleton

    // Start is called before the first frame update
    void Start()
    {
        scSoundManager.instance.PlayBGM("BGM_main");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

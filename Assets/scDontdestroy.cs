using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scDontdestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);   
    }
  
}

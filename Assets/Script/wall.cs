using System.Collections;

using UnityEngine;


public class wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("wall9",2f);
       
    }

    void wall9()
    {
        Destroy(gameObject);
    }
}

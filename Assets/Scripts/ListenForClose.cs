using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenForClose : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }       
    }
}

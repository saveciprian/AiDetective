using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LLMUnity;

public class Test : MonoBehaviour
{
    public LLM llm;
  
    void HandleReply(string reply){
        // do something with the reply from the model
        Debug.Log(reply);
    }
  
    void Game(){
        // your game function

        string message = "Hello there! Do you, by any chance, know where I can find a bakery?";
        _ = llm.Chat(message, HandleReply);
    }

    private void Start()
    {
        Game();
    }
}

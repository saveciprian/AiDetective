using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LLMUnity;
using TMPro;

public class AiReply : MonoBehaviour
{
    public LLM llm;
    public GameObject messagePrefab;
    public GameObject targetArea;
    public int waiting = 0;

    private TextMeshProUGUI _destinationTextArea;

    void HandleReply(string reply){
        // do something with the reply from the model
        _destinationTextArea.text = reply;
    }
  
    void Game(){
        string message = "Describe the following scene: a police woman is found dead in a dark alleyway, under neon lights. There is an eerie silence filling the air. People are lurking anxiously, waiting to see what will happen next";
        
        GameObject textArea = Instantiate(messagePrefab, targetArea.transform);
        _destinationTextArea = textArea.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        
        _ = llm.Chat(message, HandleReply);
    }
    

    private void Awake()
    {
        Game();
    }
}

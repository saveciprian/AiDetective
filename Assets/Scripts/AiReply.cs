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
    public GameObject playerMessagePrefab;
    public GameObject targetArea;
    public int waiting = 0;
    public string InitialMessage;
    public string CharacterName;

    private TextMeshProUGUI _destinationTextArea;

    void HandleReply(string reply)
    {
        // do something with the reply from the model
        _destinationTextArea.text = reply;
    }
  
    void Game()
    {
        NewAiMessage(InitialMessage);
    }

    public void AddMessage(GameObject prefabType, string inputMessage)
    {
        GameObject newMessage = Instantiate(prefabType, targetArea.transform);
        TextMeshProUGUI _destinationMessage = newMessage.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _destinationMessage.text = inputMessage;
        NewAiMessage(inputMessage);
    }

    public void NewAiMessage(string newMessage)
    {
        llm.CancelRequests();  
        GameObject textArea = Instantiate(messagePrefab, targetArea.transform);
        textArea.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = CharacterName + ":";
        _destinationTextArea = textArea.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _ = llm.Chat(newMessage, HandleReply);
    }
    

    private void Awake()
    {
        Game();
        InputManager.Instance.playerInConversation = true;
    }

    public void EndInteraction()
    {
        // llm.CancelRequests();
        gameObject.SetActive(false);
        
    }
}

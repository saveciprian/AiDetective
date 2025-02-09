using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractableCharacter : MonoBehaviour, IInteractable
{
    public Animator anim;
    public GameObject _dialoguePanel;
    private bool tooltipOn = false;
    public SO_CharacterPanel CharacterDetails;

    public TMP_InputField playerInput;
    private AiReply aiReply;

    private void Start() {
        aiReply = _dialoguePanel.GetComponent<AiReply>();
    }

    public void StartInteraction()
    {
        anim.SetBool("Visible", true);
        tooltipOn = true;
    }

    public void StopInteraction()
    {
        if (tooltipOn)
        {
            anim.SetBool("Visible", false);
        }

        _dialoguePanel.GetComponent<AiReply>().EndInteraction();
    }

    public void Interact()
    {
        Transform _characterImage = _dialoguePanel.transform.GetChild(0).GetChild(0);
        
        _characterImage.GetComponent<UnityEngine.UI.Image>().sprite = CharacterDetails.image;
        _characterImage.GetComponent<RectTransform>().anchoredPosition = new Vector3(CharacterDetails.posX, CharacterDetails.posY, 0);
        _characterImage.GetComponent<RectTransform>().sizeDelta = new Vector2(CharacterDetails.width, CharacterDetails.height);
        _dialoguePanel.GetComponent<UnityEngine.UI.Image>().color = CharacterDetails.hexCodeMenu;
        Scrollbar _scrollbar = _dialoguePanel.transform.GetChild(1).GetChild(1).GetComponent<Scrollbar>();
        _scrollbar.colors = CharacterDetails.scrollBarColors;

        anim.SetBool("Visible", false);
        _dialoguePanel.SetActive(true);
    }

    public void submitPlayerMessage()
    {
        
        if(Input.GetKeyDown(KeyCode.Return))
        {
            _dialoguePanel.GetComponent<AiReply>().AddMessage(aiReply.playerMessagePrefab, playerInput.text);
            playerInput.text = "";
        }
        
    }

}

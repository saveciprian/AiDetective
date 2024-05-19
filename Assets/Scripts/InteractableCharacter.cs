using UnityEngine;

public class InteractableCharacter : MonoBehaviour, IInteractable
{
    public Animator anim;
    public GameObject _dialoguePanel;
    private bool tooltipOn = false;

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
    }

    public void Interact()
    {
        anim.SetBool("Visible", false);
        _dialoguePanel.SetActive(true);
    }
}

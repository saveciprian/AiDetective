using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private Collider2D _interactableObject;
    private IInteractable _interactable;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetComponent<IInteractable>() != null)
        {
            _interactable = other.transform.GetComponent<IInteractable>();
            _interactable.StartInteraction();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.GetComponent<IInteractable>() == null && _interactable == null)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            _interactable.Interact();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _interactable.StopInteraction();
        
        _interactableObject = null;
        _interactable = null;
    }
}

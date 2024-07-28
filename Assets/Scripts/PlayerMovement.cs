using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;

    [SerializeField]
    private float m_Speed = 4f;

    private Transform _graphic;
    private bool _flipped = false;

    void Start()
    {
        m_Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _graphic = transform.GetChild(0).transform;
    }

    private void FixedUpdate()
    {
        if(InputManager.Instance.playerInConversation) return;

        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        if (m_Input.x < 0 && !_flipped)
        {
            _flipped = true;
            Vector3 graphicScale = _graphic.localScale;
            _graphic.localScale = new Vector3(-graphicScale.x, graphicScale.y, graphicScale.z);
        }
        else if (m_Input.x > 0 && _flipped)
        {
            _flipped = false;
            Vector3 graphicScale = _graphic.localScale;
            _graphic.localScale = new Vector3(-graphicScale.x, graphicScale.y, graphicScale.z);
        }
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
        
    }
    

}

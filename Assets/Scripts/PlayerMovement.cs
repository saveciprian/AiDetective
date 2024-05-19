using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;

    [SerializeField]
    private float m_Speed = 4f;

    void Start()
    {
        m_Rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);

    }
    

}

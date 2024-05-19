using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraTrack : MonoBehaviour
{
    private CapsuleCollider2D _playerCollider;
    private Vector3 _playerPosition;
    [SerializeField]
    private BoxCollider2D cameraBounds;

    private float[] _outerBounds;
    private Vector3 newPosition;
     
    void Start()
    {
        _playerCollider = GameObject.FindWithTag("Player").GetComponent<CapsuleCollider2D>();
        Bounds camBounds = cameraBounds.bounds;
        _outerBounds = new[]
        {
            camBounds.min.x,
            camBounds.min.y,
            camBounds.max.x,
            camBounds.max.y
        };
    }

    void Update()
    {
        _playerPosition = _playerCollider.bounds.center;
        newPosition = new Vector3(
            Mathf.Clamp(_playerPosition.x, _outerBounds[0], _outerBounds[2]),
            Mathf.Clamp(_playerPosition.y, _outerBounds[1], _outerBounds[3]),
            transform.position.z);
        transform.position = newPosition;

    }
}

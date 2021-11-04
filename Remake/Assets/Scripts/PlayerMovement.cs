using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 4;
    public float JumpHeight = 8;


    private Rigidbody2D _rigidbody;
    private float _movement;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        VerticalMovement();
        Rotation();
    }
    private void HorizontalMovement()
    {
        _movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(_movement, 0, 0) * Time.deltaTime * MovementSpeed;
    }
    private void VerticalMovement()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpHeight), ForceMode2D.Impulse);
        }
    }
    private void Rotation()
    {
        if(!Mathf.Approximately(0, _movement))
        {
            transform.rotation = _movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
    }
}

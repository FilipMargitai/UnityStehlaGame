using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxRunSpeed = 5;
    public float jumpSpeed = 5;
    private bool _onGround = false;
    private bool _facingRight = true;

    private Rigidbody2D _rb;
    private Collider2D _coll;
    private SpriteRenderer _sr;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _coll = GetComponent<Collider2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _onGround = _coll.IsTouchingLayers();
        float move = Input.GetAxis("Horizontal");
        if (move != 0) _facingRight = (move < 0);
        _sr.flipX = _facingRight;
        _rb.velocity = new Vector2(move * maxRunSpeed, _rb.velocity.y);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && _onGround)
        {
            _rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("PickUp"))
        {
            collider.gameObject.SetActive(false);
        }
    }
}

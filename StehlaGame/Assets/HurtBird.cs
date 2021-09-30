using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBird : MonoBehaviour
{
    public Sprite damaged;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D()
    {
        spriteRenderer.sprite = damaged;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    private int Cow;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelociry;
    //public Text TextCow;
    public float laserLength = 3f;
    public float GravityForce = -0.5f;
    public Button RestartLevel;
    
    void Start()
    {
        Cow = 0;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        moveVelociry = moveInput.normalized * speed;
        rb.MovePosition(rb.position + moveVelociry * Time.deltaTime);
        rb.gravityScale = 0;
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, laserLength);

        for (int i = 0; i < hits.Length; ++i)
        {
            if(hits[i].collider.tag == "Cow")
                hits[i].rigidbody.gravityScale = GravityForce;
        }
        Debug.DrawRay(transform.position, Vector2.down * laserLength, Color.red);
    }

    private void OnCollisionEnter2D(Collision2D CoinOb)
    {
        if (CoinOb.gameObject.tag == "Cow")
        {
            Cow++;
            //Debug.Log("Cow" + Cow);
            //TextCow.text = "COWS: " + Cow.ToString();
            Destroy(CoinOb.gameObject);
        }

        if (CoinOb.gameObject.tag == "Rocket")
        {
            RestartLevel.gameObject.SetActive(true);
            Destroy(CoinOb.gameObject);
            Destroy(this.gameObject);
        }
    }
}

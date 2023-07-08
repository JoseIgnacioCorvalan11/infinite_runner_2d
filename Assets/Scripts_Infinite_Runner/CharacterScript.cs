using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public static CharacterScript instance;
    public enum CharacterStates {Normal, Hit, Return, Death }
    public CharacterStates state;
    Animator anim;
    Vector3 ogPos;
    Rigidbody2D rb2d;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float knockBack = 3f;
    [SerializeField] float returnSpeed = 1.5f;
    [SerializeField] float walkSpeed = 5f;
    bool onFloor = true;

    private void Awake()
    {
        if (instance == null) 
        { 
           instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        ogPos = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case CharacterStates.Normal:
                Jump();
                Move();
                break;
            case CharacterStates.Hit:
                ReturnToPosition();
                break;
            case CharacterStates.Return:
                if (state == CharacterStates.Return)
                {
                    state = CharacterStates.Normal;
                }
                break;
            case CharacterStates.Death:
                if (state == CharacterStates.Death)
                {   
                    state = CharacterStates.Normal;
                }
                break;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onFloor)
            {
                anim.Play("Jump");
                rb2d.velocity = Vector2.up * jumpForce;
                onFloor = false;
            }
        }
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb2d.velocity = Vector2.right * walkSpeed;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb2d.velocity = Vector2.left * walkSpeed;
        }
    }
    

    bool ReturnToPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, ogPos, returnSpeed * Time.deltaTime);
        return transform.position.magnitude == ogPos.magnitude;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Harm")
        {
            anim.Play("Hurt");
            onFloor = false;
            rb2d.velocity = (Vector2.up + Vector2.left).normalized * knockBack;
            state = CharacterStates.Hit;
            anim.Play("Running");
        }

        if (collision.transform.tag == "Floor")
        {
            onFloor = true;
            if (state == CharacterStates.Hit)
            {
                state = CharacterStates.Return;
                
            }
        }

        if (collision.transform.tag == "Death")
        {
            anim.Play("Dead");
            state = CharacterStates.Death;
            InfiniteRun_GameManager.Instance.state = InfiniteRun_GameManager.GameStates.game_over;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2f;
    public bool canMove;
    public int emote_state;

    private Animator m_Animator;
    private EmoteManager _emote;
   
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        emote_state = 1;
    }

    // Update is called once per frame
    void Update()
    {
        m_Animator = GetComponent<Animator>();

        CalculateMovement();

    }
    void SetEmoteState(int state)
    {
        emote_state = state;
    
    }
    public int getEmoteState()
    {
        return emote_state;
    }
    void DisplayEmote()
    {
        _emote = GameObject.FindGameObjectWithTag("EmoteManager").GetComponent<EmoteManager>();
        _emote.Emote();
    }
    
    public void CanMove()
    {
        canMove = true;
    }
    public void CanNotMove()
    {
        canMove = false;
    }
    void CalculateMovement()
    {
        if (!canMove)
        {
            return;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            m_Animator.SetBool("is_back_move", true);



        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            m_Animator.SetBool("is_back_move", false);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            m_Animator.SetBool("is_front_move", true);



        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            m_Animator.SetBool("is_front_move", false);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {


            m_Animator.SetBool("is_left_move", true);

        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            m_Animator.SetBool("is_left_move", false);

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            m_Animator.SetBool("is_right_move", true);


        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            m_Animator.SetBool("is_right_move", false);
        }


        float horizontalInput = Input.GetAxis("Horizontal"), verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -15f, 15.8f), Mathf.Clamp(transform.position.y, -9.5f, 10f), 0);
    }
}

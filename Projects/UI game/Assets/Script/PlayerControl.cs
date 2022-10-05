using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationDirection
{
    Front,
    Right,
    Left,
    Back
}

public class PlayerControl : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rigidBody;
    public Vector2 movement;

    public KeyCode jumpKey;

    public Animator playerAnimator;
    private string _currentState;
    private AnimationDirection _playerDirection;

    #region Animation Clips
    public string IDLE_FRONT;
    public string IDLE_RIGHT;
    public string IDLE_LEFT;
    public string IDLE_BACK;

    #endregion


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");



        /*
        if (Input.GetKeyDown(jumpKey))
        {
            playerAnimator.SetBool("movingRight", true);

        }

        if (Input.GetKeyUp(jumpKey))
        {
            playerAnimator.SetBool("movingRight", false);
        }*/
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * movementSpeed);


        if (_playerDirection == AnimationDirection.Front)
            ChangeAnimationState(IDLE_FRONT);
        else if (_playerDirection == AnimationDirection.Right)
            ChangeAnimationState(IDLE_RIGHT);
        else if (_playerDirection == AnimationDirection.Left)
            ChangeAnimationState(IDLE_LEFT);
        else if (_playerDirection == AnimationDirection.Back)
            ChangeAnimationState(IDLE_BACK);

        if (movement.x > 0) //right
        {
            ChangeAnimationState(IDLE_RIGHT);
            _playerDirection = AnimationDirection.Right;
        }
        else if (movement.y < 0) // down
        {
            ChangeAnimationState(IDLE_FRONT);
            _playerDirection = AnimationDirection.Front;
        }
        else if (movement.y > 0) // up
        {
            ChangeAnimationState(IDLE_BACK);
            _playerDirection = AnimationDirection.Back;
        }
        else if (movement.x < 0) // left
        {
            ChangeAnimationState(IDLE_LEFT);
            _playerDirection = AnimationDirection.Left;
        }

    }

    void ChangeAnimationState(string newState)
    {
        if (_currentState == newState)
            return;

        playerAnimator.Play(newState);


        _currentState = newState;
    }
}

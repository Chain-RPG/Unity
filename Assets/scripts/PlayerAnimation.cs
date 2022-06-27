using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState { 
    Stand,
    Walk
}

public class PlayerAnimation : MonoBehaviour
{
    public PlayerState PS;
    public Vector3 lookDirection;
    public float speed = 0f;
    public const float standSpeed = 0f;
    public const float walkSpeed = 2f;

    public Animator animator;
    public AnimationClip Stand_Ani;
    public AnimationClip Walk_Ani;

    public float x;
    public float z;

    public ButtonClick uiManager;

    public void AnimationUpdate() {
        if (PS == PlayerState.Stand) {
            animator.SetBool("Walk", false);
        }
        if (PS == PlayerState.Walk)
        {
            animator.SetBool("Walk", true);
        }
    }

    private void KeyBoardInput() {
        if (x != 0  || z != 0) {
            lookDirection = z * Vector3.forward + x * Vector3.right;
            speed = walkSpeed;
            PS = PlayerState.Walk;
        }

        if (x == 0 && z == 0 && PS != PlayerState.Stand) {
            PS = PlayerState.Stand;
            speed = standSpeed;
        }
    }

    private void LookUpdata() {
        Quaternion R = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, R, 10f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Start(){
        animator = GetComponent<Animator>();
        uiManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ButtonClick>();
        uiManager.init();
    }

    void Update()
    {
        KeyBoardInput();
        LookUpdata();
        AnimationUpdate();
    }
}

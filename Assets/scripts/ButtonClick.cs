using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public GameObject player;
    public PlayerAnimation playerAnimation;
    public void init(){
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimation = player.GetComponent<PlayerAnimation>();
    }

    public void left() {
        playerAnimation.x = -1;
        playerAnimation.z = 0;
    }
    public void right(){
        playerAnimation.x = 1;
        playerAnimation.z = 0;
    }
    public void up(){
        playerAnimation.x = 0;
        playerAnimation.z = 1;
    }
    public void down(){
        playerAnimation.x = 0;
        playerAnimation.z = -1;
    }
    public void upLeft(){
        playerAnimation.x = -1;
        playerAnimation.z = 1;
    }
    public void upRight(){
        playerAnimation.x = 1;
        playerAnimation.z = 1;
    }
    public void downLeft(){
        playerAnimation.x = -1;
        playerAnimation.z = -1;
    }
    public void downRight(){
        playerAnimation.x = 1;
        playerAnimation.z = -1;
    }
    public void leftUp(){
        playerAnimation.x = 0;
        playerAnimation.z = 0;
    }
    public void rightUp()
    {
        playerAnimation.x = 0;
        playerAnimation.z = 0;
    }
    public void upUp()
    {
        playerAnimation.x = 0;
        playerAnimation.z = 0;
    }
    public void downUp()
    {
        playerAnimation.x = 0;
        playerAnimation.z = 0;
    }
    public void upLeftUp()
    {
        playerAnimation.x = 0;
        playerAnimation.z = 0;
    }
    public void upRightUp()
    {
        playerAnimation.x = 0;
        playerAnimation.z = 0;

    }
    public void downLeftUp()
    {
        playerAnimation.x = 0;
        playerAnimation.z = 0;
    }
    public void downRightUp()
    {
        playerAnimation.x = 0;
        playerAnimation.z = 0;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class PlayerInfo : MonoBehaviour
{
    public Animator animator;
    public bool isJump = false;
    public bool isMove = false;
    public bool isCar = false;
    public SpriteRenderer SpriteRenderer;
    public GameObject playerObject;
    public GameObject carObject;
    public float dirX { get; set; }
    public float dirY { get; set; }
    public float speed = 2.0f;
    public void PlayerMovement(Transform transform)
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirX = -1;
            dirY = 0;
            isMove = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            dirX = 1;
            dirY = 0;
            isMove = true;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            dirX = 0;
            dirY = 1;
            isMove = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dirX = 0;
            dirY = -1;
            isMove = true;
        }
        else
        {
            isMove = false;
        }
        if (isMove == true)
        {
            transform.position += new Vector3(dirX, dirY) * Time.deltaTime * speed;
        }
    }
    public void TakeCar()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isCar = !isCar;
            playerObject.SetActive(!isCar);
            carObject.SetActive(isCar);
            speed = isCar ? 4 : 2;
        }
    }
    public void JumpPlayer(Transform transform)
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJump == false)
        {
            isJump = true;
            transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
        }
    }
}

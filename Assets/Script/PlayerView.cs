using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView
{
    public void UpdateAnimation(Animator animator, float x, float y, bool isMove)
    {
        animator.SetFloat("DirectionX", x);
        animator.SetFloat("DirectionY", y);
        animator.SetBool("IsMove", isMove);
    }

    public void CarRender(SpriteRenderer spriteRenderer, Sprite[] sprite, float dirX, float dirY)
    {
        if (sprite == null)
        {
            Debug.Log("tlqkf");
            return;
        }
        if (dirX == 1)
        {
            spriteRenderer.sprite = sprite[2];
        }
        else if (dirX == -1)
        {
            spriteRenderer.sprite = sprite[0];
        }
        else if (dirY == 1)
        {
            spriteRenderer.sprite = sprite[1];
         }
        else if (dirY == -1)
        {
            spriteRenderer.sprite = sprite[3];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Sprite[] sprites;
    PlayerInfo playerInfo;
    PlayerView playerView;
    Transform playerTransform;
    public GameObject interactionUI;
    void Start()
    {
        playerInfo = new PlayerInfo();
        gameObject.AddComponent<PlayerInfo>();
        playerInfo.animator = gameObject.GetComponentInChildren<Animator>();
        Debug.Log(transform.GetChild(2).name);
        playerInfo.playerObject = transform.GetChild(1).gameObject;
        playerInfo.carObject = transform.GetChild(2).gameObject;
        playerInfo.SpriteRenderer = transform.GetChild(2).GetComponent<SpriteRenderer>();
        playerTransform = transform.parent;
        playerInfo.dirY = -1;
        playerView = new PlayerView();
    }

    // Update is called once per frame

    void Update()
    {
        playerInfo.PlayerMovement(playerTransform);
        playerInfo.TakeCar();
        if (playerInfo.isCar)
        {
            playerView.CarRender(playerInfo.SpriteRenderer, sprites, playerInfo.dirX, playerInfo.dirY);
        }
        else
        {
            playerInfo.JumpPlayer(transform);
            playerView.UpdateAnimation(playerInfo.animator, playerInfo.dirX, playerInfo.dirY, playerInfo.isMove);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Npc"))
        {
            Vector3 normalVec = (collision.transform.position - transform.position).normalized;
            normalVec.z = 0;
            playerTransform.position -= normalVec * Time.deltaTime * playerInfo.speed;
        }
        else if (collision.CompareTag("Npc"))
        {
            interactionUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                UIManager.instance.ActiveTextUI(collision.gameObject.name, "게임 하실레요?");
            }
        }
        if(collision.CompareTag("Trigger"))
        {
            SceneManager.LoadScene("FlyingBird");
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Npc"))
        {
            interactionUI.SetActive(false);

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            playerInfo.isJump = false;
            return;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BirdPlayer : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f;
    public float forwordSpeed = 3f;
    public bool isDead = false;
    GameManager gameManager;
    float deathCooldown = 0f;

    bool isFlap = false;
    bool isGameStart = false;
    public bool isGodBod = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstance;
        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.isKinematic = true;
        if (animator == null)
            Debug.LogError("애니메이터 버그");

        if (_rigidbody == null)
            Debug.LogError("리지드바디 버그");
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isGameStart == false)
        {
            isGameStart = true;
            gameManager.StartGame();
            _rigidbody.isKinematic = false;
        }
        else if (isGameStart == true)
        {

            if (isDead)
            {
                if (deathCooldown <= 0f)
                {
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                    {
                        gameManager.RestartGame();
                    }
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        gameManager.BackGame();
                    }
                }
                else
                {
                    deathCooldown -= Time.deltaTime;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    isFlap = true;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead || isGameStart == false) return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwordSpeed;
        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }
        Debug.Log(forwordSpeed);
        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp(_rigidbody.velocity.y * 10, -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGodBod) return;

        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetBool("IsDie", isDead);
        gameManager.GameOver();
    }
}

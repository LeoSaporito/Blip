using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] GameObject startText;
    [SerializeField] float normalGravity;
    [SerializeField] float startGravity;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] float gameOverPanelDelay;

    Rigidbody2D rb;

    bool isAlive;
    bool isStart;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        isAlive = true;
        isStart = false;

        rb.gravityScale = startGravity;

        gameOverPanel.SetActive(false);
    }
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (!isStart) { rb.gravityScale = startGravity; }
        else { rb.gravityScale = normalGravity; }
        
        Vector2 playerVelocity = new Vector2(0f, rb.linearVelocity.y);
        rb.linearVelocity = playerVelocity;
    }
    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }

        if (value.isPressed)
        {
            isStart = true;
            startText.SetActive(false);
            rb.linearVelocity = new Vector2(0f, jumpForce);
        }
    }    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe Triggers"))
        {
            Die();

            Invoke("GameOverPanel", gameOverPanelDelay);
        }
    }
    private void Die()
    {
        isAlive = false;
    }
    void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    public bool GetIsAlive()
    {
        return isAlive;
    }
    public bool GetIsGameStart()
    {
        return isStart;
    }
}

using UnityEngine;

public class ENVMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    void Update()
    {
        bool isPlayerAlive = playerMovement.GetIsAlive();

        if (!isPlayerAlive) { return; }

        EnvironmentMovement();
    }

    void EnvironmentMovement()
    { 
        Vector2 position = transform.position;

        position.x -= moveSpeed * Time.deltaTime;

        transform.position = position;
    }
}

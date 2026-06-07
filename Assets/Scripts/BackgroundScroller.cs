using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;

    Material material;
    PlayerMovement playerMovement;
    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;

        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    private void Update()
    {
        bool isAlive = playerMovement.GetIsAlive();

        if (!isAlive) { return; }

        offset += moveSpeed * Time.deltaTime;

        material.mainTextureOffset = offset;
    }
}

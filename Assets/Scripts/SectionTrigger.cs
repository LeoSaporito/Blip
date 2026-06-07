using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    [SerializeField] GameObject groundPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            Instantiate(groundPrefab, new Vector2(6.25f, -4.5f), Quaternion.identity);            
        }
    }
}

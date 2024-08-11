using System;
using System.Collections;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public string text = "";
    private bool cartelMostrado = false;
    public static event Action<bool> OnShowText;

    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !cartelMostrado)
        {
            gameManager.ShowText(text);
            cartelMostrado = true;
            OnShowText?.Invoke(true);

            StartCoroutine(DestroyEdgeColliderAfterDelay(3f));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && cartelMostrado)
        {
            gameManager.HideText();
            OnShowText?.Invoke(false);
        }
    }

    private IEnumerator DestroyEdgeColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();
        if (edgeCollider != null)
        {
            Destroy(edgeCollider);
        }
    }
}

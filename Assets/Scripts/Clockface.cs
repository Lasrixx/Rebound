using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clockface : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private float rotationSpeed;
    private bool forwardsRun;
    private Color forwardsColor;
    private Color backwardsColor;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 region = transform.position;

        Color forwardsColor = new Color(0.8962264f, 0.8962264f, 0.8962264f, 1f);
        Color backwardsColor = new Color(0.1320f, 0.1320f, 0.1320f, 1f);

        if (region.y > -6)
        {
            Color color = new Color(0.8490f, 0.8490f, 0.8490f, 0.66f);
            forwardsRun = true;
            spriteRenderer.color = forwardsColor;
        }
        else
        {
            forwardsRun = false;
            spriteRenderer.color = backwardsColor;
        }
    }
}

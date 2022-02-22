using System;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private float destroyDelay;

    private bool _hasPackage = false;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Package") && !_hasPackage)
        {
            Debug.Log("Package picked up");
            _hasPackage = true;
            _spriteRenderer.color = hasPackageColor;
            Destroy(col.gameObject, destroyDelay);
        }

        if (col.CompareTag("Customer") && _hasPackage)
        {
            Debug.Log("Package Delivered");
            _hasPackage = false;
            _spriteRenderer.color = noPackageColor;
        }
    }
}
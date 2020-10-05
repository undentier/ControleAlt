using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollSpaceBG : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.1f;
    float xScroll;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        xScroll = Time.time * scrollSpeed;

        Vector2 offset = new Vector2(xScroll, 0f);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBackground : MonoBehaviour {

    public float scrollSpeed = 0.5f;
    private Renderer rend;
    float offset;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }
    void Update()
    {
        offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(offset, 0.01f);
    }
}

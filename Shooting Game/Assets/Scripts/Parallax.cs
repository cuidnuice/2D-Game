using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    private RawImage rawImage;
    [SerializeField] Rect rect;

    [SerializeField] float speed = 0.25f;

    void Start()
    {
        rawImage = GetComponent<RawImage>();
    }

    void Update()
    {
        rect = rawImage.uvRect;
        rect.y += speed * Time.deltaTime;

        rawImage.uvRect = rect;
    }
}

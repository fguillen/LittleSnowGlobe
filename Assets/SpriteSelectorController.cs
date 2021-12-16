using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSelectorController : MonoBehaviour
{
    [SerializeField] List<Sprite> spritesCatalog = new List<Sprite>();
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        spriteRenderer.sprite = RandomSprite();
    }

    Sprite RandomSprite() {
        return spritesCatalog[Random.Range(0, spritesCatalog.Count)];
    }
}

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

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = RandomSprite();
    }

    // Update is called once per frame
    void Update()
    {

    }

    Sprite RandomSprite() {
        return spritesCatalog[Random.Range(0, spritesCatalog.Count)];
    }
}

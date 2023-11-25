using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer sprite1 = null;

    [SerializeField]
    private SpriteRenderer sprite2 = null;

    [SerializeField]
    private Camera cameraManager = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckSprite(sprite1);
        CheckSprite(sprite2);
    }

    void CheckSprite(SpriteRenderer sprite)
    {
        Vector3 position = sprite.transform.position;
        position.y -= GameManager.instance.gameSpeed;
        if (cameraManager.WorldToViewportPoint(position).y < -1)
        {
            position.y += (sprite.size.y * 2) - 5;
        }
        sprite.transform.position = position;
    }
}

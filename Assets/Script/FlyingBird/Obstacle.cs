using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float hightPosY = 1f;
    public float lowPosY = -1f;
    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;
    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;
    // Start is called before the first frame update
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.GetInstance;
    }
    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halHoleSize = holeSize / 2f;

        topObject.localPosition = new Vector3(0, halHoleSize);
        bottomObject.localPosition = new Vector3(0, -halHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, hightPosY);
        transform.position = placePosition;
        return placePosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BirdPlayer player))
        {
            gameManager.AddScore(1);
        }
    }
}

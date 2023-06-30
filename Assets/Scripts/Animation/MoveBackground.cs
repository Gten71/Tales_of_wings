using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
	[SerializeField] private GameObject image;
	[SerializeField] private float moveSpeed;
	[SerializeField] private float moveMaxTime;
	[SerializeField] private Transform startPosition;
	private float moveTimer;

	void Start()
    {
        moveTimer = moveMaxTime;
    }

    void Update()
    {
        MoveImage();
    }

    void MoveImage()
    {
        if (moveTimer > 0)
        {
			image.transform.Translate(transform.right * moveSpeed);
			moveTimer -= Time.deltaTime;
		}
        else
        {
            image.transform.position = startPosition.position;
            moveTimer = moveMaxTime;
        }
    }
}

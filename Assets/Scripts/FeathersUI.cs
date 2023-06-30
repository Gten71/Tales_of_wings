using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeathersUI : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Sprite spentFeatherSprite;
	[SerializeField] private Sprite readyFeatherSprite;

	// Start is called before the first frame update
	void Start()
    {
	}

    void Update()
    {
		FeathersDarkening();
	}

    //Затемняет перья если использовано определённое кол-во патронов.

    private void FeathersDarkening()
    {
		FeatherIDHolder[] featherReferences = FindObjectsOfType<FeatherIDHolder>();
		foreach (FeatherIDHolder refence in featherReferences)
        {
            if (refence.ID > characterController.currentAmmo) 
                refence.gameObject.GetComponent<SpriteRenderer>().sprite = spentFeatherSprite;
            else if (characterController.currentAmmo != 0)
                refence.gameObject.GetComponent<SpriteRenderer>().sprite = readyFeatherSprite;
            else
				refence.gameObject.GetComponent<SpriteRenderer>().sprite = spentFeatherSprite;
		}
	}
}

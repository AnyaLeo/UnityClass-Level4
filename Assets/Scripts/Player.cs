using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    private int fishCounter;
    public TextMeshProUGUI fishCounterText;

    public bool scalingEnabled = true;
    public float scaleIncrease = 0.01f;
    public float scaleDecrease = 10f;

    // Start is called before the first frame update
    void Start()
    {
        fishCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            movement = Vector3.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement = movement + Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement = movement + Vector3.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement = movement + Vector3.right;
        }

        transform.Translate(movement * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool didCollideWithFish = other.gameObject.CompareTag("Fish");
        if (didCollideWithFish)
        {
            Destroy(other.gameObject);

            fishCounter = fishCounter + 1;

            if (scalingEnabled)
            {
                Vector3 scale = transform.localScale;
                scale.x += scaleIncrease;
                scale.y += scaleIncrease;
                transform.localScale = scale;
            }

            GameManager.Instance.fishEatSound.Play();
        }

        bool didCollideWithPoisonFish = other.gameObject.CompareTag("Poison");
        if (didCollideWithPoisonFish)
        {
            Destroy(other.gameObject);

            fishCounter = fishCounter - 100;

            if (scalingEnabled)
            {
                Vector3 scale = transform.localScale;
                scale.x -= scaleDecrease;
                scale.y -= scaleDecrease;

                if (scale.x <= 1f)
                {
                    scale.x = 1f;
                    scale.y = 1f;
                }

                transform.localScale = scale;
            }
            GameManager.Instance.poisonFishSound.Play();
        }

        fishCounterText.text = "Fish eaten: " + fishCounter.ToString();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        
    }
}

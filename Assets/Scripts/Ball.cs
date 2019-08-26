using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xLaunch = 2f;
    [SerializeField] float yLaunch = 12f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    // cache ref
    Rigidbody2D myRigidbody;

    // state
    Vector2 paddleToBallVector;
    bool beginGame = false;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (!beginGame)
        {
            LockBallToPaddle();
            LaunchOnClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidbody.velocity = new Vector2(xLaunch, yLaunch);
            beginGame = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 velocityTweak = new Vector2
        (Random.Range(0f, randomFactor),
        Random.Range(0f, randomFactor));
        if (beginGame)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            GetComponent<AudioSource>().PlayOneShot(clip);
            myRigidbody.velocity += velocityTweak;
        }
    }
}

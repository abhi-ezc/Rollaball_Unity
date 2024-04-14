using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public new Rigidbody rigidbody;

    private float movementX;
    private float movementZ;
    private float movementY;
    public float movementSpeed = 10;

    private int playerScore = 0;

    private bool bTimerStarted = false;

    private float startTime = 0;

    private float currentTime = 0;

    public float maxTime = 100;

    private bool bGameOver = false;

    public TMP_Text ScoreText;
    public TMP_Text TimerText;
    public TMP_Text StateText;
    public TMP_Text DescriptionText;

    public GameObject RetryButton;




    // Start is called before the first frame update
    void Start()
    {
        startTime = 0;
        currentTime = 0;
        // Collect maximum pickups in 100 seconds.
        DescriptionText.SetText("Collect maximum pickups in " + maxTime + " seconds");

        StateText.SetText("Move to Start");
        StateText.fontSize = 48;
        StateText.color = Color.green;

        ScoreText.gameObject.SetActive(false);
        TimerText.gameObject.SetActive(false);
        RetryButton.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        if (!bTimerStarted)
        {
            OnTimerStarted();
        }

        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementZ = movementVector.y;


    }

    void OnJump(InputValue inputValue)
    {

    }

    // Update is called at fixed interval
    void FixedUpdate()
    {
        if (!bGameOver && bTimerStarted)
        {
            currentTime = Time.realtimeSinceStartup;
            if (maxTime <= currentTime - startTime)
            {
                OnGameOver();
            }
            TimerText.SetText("Time : " + Math.Round(currentTime - startTime));
            rigidbody.AddForce(new Vector3(movementX * movementSpeed, movementY * movementSpeed, movementZ * movementSpeed));
        }
        else
        {
            rigidbody.AddForce(new Vector3(0, 0, 0));
        }
    }

    IEnumerator StopJump()
    {
        yield return new WaitForSeconds(.1f); //wait 10 seconds
        movementY = 0;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Pickup") && !bGameOver)
        {
            playerScore += 1;
            ScoreText.SetText("Score : " + playerScore, true);
            collider.gameObject.SetActive(false);
            collider.gameObject.SetActive(true);
            Debug.Log(currentTime - startTime + " - " + playerScore);
        }
    }

    void OnTimerStarted()
    {
        bTimerStarted = true;
        startTime = Time.realtimeSinceStartup;

        StateText.gameObject.SetActive(false);
        DescriptionText.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(true);
        TimerText.gameObject.SetActive(true);

        ScoreText.SetText("Score : " + playerScore, true);
    }
    void OnGameOver()
    {
        bGameOver = true;

        StateText.gameObject.SetActive(true);
        ScoreText.gameObject.SetActive(false);
        TimerText.gameObject.SetActive(false);

        StateText.SetText("SCORE : " + playerScore);
        StateText.color = Color.red;
        RetryButton.SetActive(true);

    }
}

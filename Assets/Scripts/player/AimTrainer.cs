using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AimTrainer : MonoBehaviour
{





    // public vars
    [SerializeField] public PlayerMovement playerMovement;
    public GameObject circle;
    public GameObject startButton;
    public static int playerScore;
    public static int bestScore;
    public TMP_Text aimScoreText;






    // private vars


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("playerCharacter").GetComponent<PlayerMovement>();
        circle.SetActive(false);

        playerScore = 0;

        bestScore = PlayerPrefs.GetInt("bestScore", bestScore);
        PlayerPrefs.Save();
    }


    // Update is called once per frame
    void Update()
    {
        StartText();
        AimTrainingGame();
        BestScore();
        PlayerScoreText();

    }

    // StartText() checks if the player is sitting and has pressed the
    // left mouse button, then checks if the player is looking at the start
    // button and if so, destroys the start button and activates the circle.
    public void StartText()
    {
        if (playerMovement.isSitting && playerMovement.isMouse0Pressed)
        {
            RaycastHit hit;
            Ray ray = playerMovement.playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 5) && hit.collider.tag == "startButton")
            {
                startButton.gameObject.SetActive(false);
                circle.SetActive(true);
            }
        }
    }
    // AimTrainingGame() checks if the player is sitting and has pressed the left
    // mouse button, then checks if the player is looking at the circle and if so, moves the circle to a random position.
    // no he usao ia es que me daba palo hacer el resumen
    public void AimTrainingGame()
    {

        if (playerMovement.isSitting && playerMovement.isMouse0Pressed)
        {
            RaycastHit hit;
            Ray ray = playerMovement.playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 5) && hit.collider.tag == "circle")
            {
                playerScore += 1;



                float x = UnityEngine.Random.Range(-2.2724f, -1.8286f);
                float y = UnityEngine.Random.Range(1.02f, 1.2027f);
                circle.transform.position = new Vector3(x, y, -3.4994f);
            }
        }
        else if (!playerMovement.isSitting)
        {
            startButton.gameObject.SetActive(true);
            circle.SetActive(false);
            aimScoreText.text = "";
            playerScore = 0;
        }
    }


    public void PlayerScoreText()
    {
        aimScoreText.text = "Score: " + playerScore.ToString() + "  Best: " + bestScore.ToString();
    }

    public void BestScore()
    {
        if (playerScore > bestScore)
        {
            bestScore = playerScore;
        }
    }


    void OnDestroy()
    {
        PlayerPrefs.SetInt("bestScore", bestScore);
        PlayerPrefs.Save();
    }

}

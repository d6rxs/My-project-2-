using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AimTrainer : MonoBehaviour
{





    // public vars
    public PlayerMovement playerMovement;
    public GameObject circle;
    public float playerScore = 0;
    public TMP_Text aimScoreText;




    // private vars





    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("playerCharacter").GetComponent<PlayerMovement>();
        circle.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        StartText();
        AimTrainingGame();
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
                Destroy(GameObject.Find("startButton"));
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
                PlayerScoreText();

                float x = UnityEngine.Random.Range(-2.2724f, -1.8286f);
                float y = UnityEngine.Random.Range(1.02f, 1.2027f);
                circle.transform.position = new Vector3(x, y, -3.4994f);
            }
        }
    }


    public void PlayerScoreText()
    {
        aimScoreText.text = "Score: " + playerScore.ToString();
    }

}

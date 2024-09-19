using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPM : MonoBehaviour
{
    public int playerScore, gold, playerHealth;                      //Ints = whole numbers
    public float encumberance, movementSpeed;                        // Floats = decimal numbers
    public string dialogue, statusMessage, characterName;                           //strings = words/text
    public bool enemyAlive, playerHealthMax, isGrounded;                         //bools = true or false values
    public Vector2 currentPlayerPosition, playerRotation, playerSize;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Welcome to Doug's Legendary Pawn Shop " + characterName);

        if (isGrounded)
        {
            Debug.Log("JUMP!!!!");
        }
       

    }

    // Update is called once per frame
    void Update()
    {
      


    }
}

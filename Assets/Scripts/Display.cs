using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public static int score;
    public static int lives;

    public Text scoreText;
    public Text livesText;

    private void Start() {
        score = 0;
        lives = 3;
    }

    private void Update() {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }
}

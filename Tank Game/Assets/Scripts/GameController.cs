using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    // Start is called before the first frame update
    private GameObject[] players;
    public Text uiObject;
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        checkNumPlayers();
        resetGame();
    }

    void checkNumPlayers() {
        players = GameObject.FindGameObjectsWithTag ("Player");
        if (players.Length <= 1) {
            string winner = players[0].ToString();
            string player = winner.Split(' ')[0];
            string number = winner.Split(' ')[1];

            uiObject.text = player + " " + number + " WINS" + "\n" + "Press A to Restart";

            if ((Input.GetButton("MReset")) || (Input.GetButton("WReset"))) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void resetGame() {
        if (Input.GetButton("Reset")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

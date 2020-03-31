using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    // Start is called before the first frame update
    private GameObject[] players;
    void Start() {
        players = GameObject.FindGameObjectsWithTag ("Player");
        Debug.Log(players.Length);
    }

    // Update is called once per frame
    void Update() {
        
    }
}

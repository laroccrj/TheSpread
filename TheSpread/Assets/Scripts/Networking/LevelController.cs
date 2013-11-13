using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	void OnConnectedToServer() {
        Application.LoadLevel("Lobby");
    }
	
	void OnServerInitialized() {
        Application.LoadLevel("Lobby");
    }
}

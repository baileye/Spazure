using UnityEngine;
using System.Collections;

public class RandomMatchMaker : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't join random room!");
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        GameObject fighter = PhotonNetwork.Instantiate("Fighter", Vector3.zero, Quaternion.identity, 0);
        PlayerController controller = fighter.GetComponent<PlayerController>();
        controller.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

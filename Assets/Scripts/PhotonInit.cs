using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PhotonInit : MonoBehaviourPunCallbacks
{
    public InputField NickName1;
    public GameObject ConnectPanel;
    int num;

    private void Awake()
    {
        Screen.SetResolution(960, 540, false);
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
        
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    

    public override void OnConnectedToMaster()
    {
        
        PhotonNetwork.LocalPlayer.NickName = NickName1.text;
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 2 }, null);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) &&PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
            ConnectPanel.SetActive(true);
        }
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Player", new Vector3(-3, 0, 0), Quaternion.identity);

        } else
        {
            PhotonNetwork.Instantiate("Player", new Vector3(3, 0, 0), Quaternion.identity);

        }
        ConnectPanel.SetActive(false);
    }

}

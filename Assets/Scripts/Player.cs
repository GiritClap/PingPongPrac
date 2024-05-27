using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class Player : MonoBehaviourPunCallbacks
{
    Rigidbody rigid;
    public float power = 10;
    public Text NickName;

    private void Awake()
    {
        NickName.text = photonView.IsMine ? PhotonNetwork.NickName : photonView.Owner.NickName;
        NickName.color = photonView.IsMine ? Color.green : Color.red;

    }
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        if(!photonView.IsMine)
        {
            return;
        }
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(h,v,0)*power*Time.deltaTime);
    }
    
}

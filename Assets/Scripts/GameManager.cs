using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public int score1 = 0;
    public int score2 = 0;

    private static GameManager m_instance; // 싱글톤이 할당될 static 변수

    public static GameManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<GameManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // 네트워크를 통해 score 값을 보내기
            stream.SendNext(score1);
            stream.SendNext(score2);

        }
        else
        {
            // 리모트 오브젝트라면 읽기 부분이 실행됨         

            // 네트워크를 통해 score 값 받기
            score1 = (int)stream.ReceiveNext();
            score2 = (int)stream.ReceiveNext();

            // 동기화하여 받은 점수를 UI로 표시
            UIManager.instance.CurrentScore(score1, score2);
        }
    }

    private void Update()
    {
        UIManager.instance.CurrentScore(score1, score2);

    }
    public void SetScore1()
    {
        score1++;
    }
    public void SetScore2()
    {
        score2++;
    }

    public int GetScore1()
    {
        return score1;
    }
    public int GetScore2()
    {
        return score2;
    }
}

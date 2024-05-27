using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public int score1 = 0;
    public int score2 = 0;

    private static GameManager m_instance; // �̱����� �Ҵ�� static ����

    public static GameManager instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<GameManager>();
            }

            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // ��Ʈ��ũ�� ���� score ���� ������
            stream.SendNext(score1);
            stream.SendNext(score2);

        }
        else
        {
            // ����Ʈ ������Ʈ��� �б� �κ��� �����         

            // ��Ʈ��ũ�� ���� score �� �ޱ�
            score1 = (int)stream.ReceiveNext();
            score2 = (int)stream.ReceiveNext();

            // ����ȭ�Ͽ� ���� ������ UI�� ǥ��
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

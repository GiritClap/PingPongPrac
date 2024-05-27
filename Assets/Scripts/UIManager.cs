using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager m_instance; // ΩÃ±€≈Ê¿Ã «“¥Áµ… ∫Øºˆ
    public Text scoreTxt1;
    public Text scoreTxt2;

    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }

            return m_instance;
        }
    }
    
    public void CurrentScore(int score1, int score2)
    {
        scoreTxt1.text = score1.ToString();
        scoreTxt2.text = score2.ToString();
    }

}

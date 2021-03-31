using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;


public class CSimpleCalcUI : MonoBehaviour
{

    
    [SerializeField] Text m_txtResult;              // ������� �ؽ�Ʈ

    [SerializeField] Button m_Button_1;        // ��ư
    [SerializeField] Button m_Button_2;        // ��ư
    [SerializeField] Button m_Button_Plus;     // ��ư
    [SerializeField] Button m_Button_Equal;   // ��ư
    [SerializeField] Button m_Button_Clear;   // ��ư


    private string m_strNum1 = "";      // ������
    private string m_strNum2 = "";      // ������
    private bool m_bPlusClick = false;

    //----------------
    private int m_nLeft = 0;
    //private int m_nRight = 0;


    // Start is called before the first frame update
    void Start()
    {
        m_Button_1.onClick.AddListener(OnClicked_Num1);
        m_Button_2.onClick.AddListener(OnClicked_Num2);
        m_Button_Plus.onClick.AddListener(OnClicked_Pluse);
        m_Button_Equal.onClick.AddListener(OnClicked_Equal);
        m_Button_Clear.onClick.AddListener(OnClicked_Clear);
    }


    public void OnClicked_Num1()
    {

        if( m_bPlusClick  )
        {
            m_strNum2 += "1";
        }
        else
        {
            m_strNum1 += "1";
        }

    }

    public void OnClicked_Num2()
    {

        if (m_bPlusClick)
        {
            m_strNum2 += "2";
        }
        else
        {
            m_strNum1 += "2";
        }
    }

    public void OnClicked_Pluse()
    {
        if (m_bPlusClick)
        {
            m_nLeft += int.Parse(m_strNum2);
            m_strNum2 = "";
        }
        else
        {
            m_bPlusClick = true;
            m_nLeft += int.Parse(m_strNum1);
            m_strNum1 = "";
        }

    }

    public void OnClicked_Equal()
    {
        Debug.Log( " m_strNum1 = " + m_strNum1 );
        int nLeft = m_nLeft; // int.Parse(m_strNum1);
        int nRight = int.Parse(m_strNum2);

        m_txtResult.text = (nLeft + nRight).ToString();
        ClearNum();

    }

    public void OnClicked_Clear()
    {
        ClearNum();
        m_txtResult.text = "0";
    }

    public void ClearNum()
    {
        m_nLeft = 0;
        m_strNum1 = "";
        m_strNum2 = "";
        m_bPlusClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

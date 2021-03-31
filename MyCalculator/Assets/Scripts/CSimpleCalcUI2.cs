using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;


public class CSimpleCalcUI2 : MonoBehaviour
{

    // 버튼 타입
    public enum EBtn
    {
        e0 = 0,
        e1,
        e9 = 9,
        ePoint,
        eEqual,
        ePlus,
        eMinus,
        eMutiply,
        eDevide,
        eBack,
        eClear,
        eClearAll,
        eMod,

        eMax,
    }

    public enum EOP
    {
        eNone = 0,
        ePlus = 1,
        eMinus,
        eMultiply,
        eDevide
    }


    [SerializeField] Text m_txtResult;              // 최종결과 텍스트

    [SerializeField] List<Button> m_BtnNums;        // 버튼

    [SerializeField] Button m_Button_Plus;      // 버튼
    [SerializeField] Button m_Button_Minus;     // 버튼
    [SerializeField] Button m_Button_Equal;     // 버튼
    [SerializeField] Button m_Button_Clear;     // 버튼

    private string m_strNum1 = "";              // 좌측값
    private string m_strNum2 = "";              // 우측값
    private bool m_bOperatorClick = false;      // 연산자 클릭
    private EOP m_eOperator = EOP.eNone;                // 연산자 타입    
    
    //----------------
    private float m_nLeft = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < m_BtnNums.Count; i++)
        {
            int idx = i;
            m_BtnNums[i].onClick.AddListener(() => OnClicked_Num(idx));
        }

        m_Button_Plus.onClick.AddListener(OnClicked_Pluse);
        m_Button_Minus.onClick.AddListener(OnClicked_Minus);
        m_Button_Equal.onClick.AddListener(OnClicked_Equal);
        m_Button_Clear.onClick.AddListener(OnClicked_Clear);
      
    }


    public void OnClicked_Num(int idx)
    {
        m_txtResult.text = "";
        string str = "";
        if (m_bOperatorClick){
            m_strNum2 += idx.ToString();
            str = m_strNum2;
        }
        else{
            m_strNum1 += idx.ToString();
            str = m_strNum1;
        }
       
        m_txtResult.text = str;
    }



    public void OnClicked_Pluse()
    {
        if (m_bOperatorClick)
        {
            m_nLeft = CalculateNumber(m_nLeft, int.Parse(m_strNum2));
            m_strNum2 = "";
        }
        else
        {
            m_bOperatorClick = true;
            m_nLeft = (float)int.Parse(m_strNum1); 
            m_strNum1 = "";
        }

        m_eOperator = EOP.ePlus;
    }
    public void OnClicked_Minus()
    {
        if (m_bOperatorClick)
        {
            m_nLeft = CalculateNumber( m_nLeft, int.Parse(m_strNum2));
            m_strNum2 = "";
        }
        else
        {
            m_bOperatorClick = true;
            m_nLeft = (float)int.Parse(m_strNum1);
            m_strNum1 = "";
        }
        m_eOperator = EOP.eMinus;
    }

    public void OnClicked_Equal()
    {
        Debug.LogFormat(" m_strNum1 = {0}, m_strNum2 = {1}", m_nLeft, m_strNum2);
        float nLeft = m_nLeft; // int.Parse(m_strNum1);
        int nRight = int.Parse(m_strNum2);

        float fResult = CalculateNumber(nLeft, nRight);

        m_txtResult.text = string.Format("{0:#.#}", fResult);
        ClearNum();

    }


    public float CalculateNumber(float nLeft, float nRight)
    {
        float nRes = 0;
        switch( m_eOperator )
        {
            case EOP.ePlus:
                nRes = nLeft + nRight;
                break;
            case EOP.eMinus:
                nRes = nLeft - nRight;
                break;
            case EOP.eMultiply:
                nRes = nLeft * nRight;
                break;
            case EOP.eDevide:
                nRes = (float)nLeft / nRight;
                break;
        }

        return nRes;
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
        m_bOperatorClick = false;
        m_eOperator = EOP.eNone;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

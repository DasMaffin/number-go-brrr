using System;
using System.Numerics;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class NumberValueUIListener : MonoBehaviour
{
    private TMP_Text m_Text;

    private void Awake()
    {
        m_Text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        GameManager.Instance.Number.AddListener(UpdateNumberUI);
    }

    private void UpdateNumberUI(BigInteger integer)
    {
        m_Text.text = integer.ToString("N0");
    }
}

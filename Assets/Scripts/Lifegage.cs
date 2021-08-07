using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifegage : MonoBehaviour
{
    [SerializeField] private bool test = false;
    [SerializeField] private float m_maxvalue = 10;
    [SerializeField] private float m_minvalue = 2;
    private Slider m_slider;

    void Start()
    {
        m_slider = gameObject.transform.Find("Slider").GetComponent<Slider>();
        ValueSet(m_maxvalue, m_maxvalue);
    }


    public void ValueSet(float maxValue, float minValue)
    {
        m_slider.value = minValue / maxValue;
    }
}

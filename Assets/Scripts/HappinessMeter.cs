using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HappinessMeter : MonoBehaviour
{
    [SerializeField] private float maxValue = 100f;
    [SerializeField] private float initialValue = 100f;
    [SerializeField] private float refillRate = 20f;
    [SerializeField] private float[] decreaseRates = {2, 5, 10};

    private bool meterStart = false;
    private float meter;
    private int index = 0;

    private void Awake()
    {
        EventManager.ON_GAMESTART += StartMeter;
        EventManager.ON_LAUGH += AddMeter;
        EventManager.ON_DIFFICULTYINCREASE += ModifyDecrease;
    }

    private void Update()
    {
        if (!meterStart) return;
        DecreaseMeter();
        MeterChecker();
    }

    private void DecreaseMeter()
    {
        meter -= decreaseRates[index] * Time.deltaTime;
        EventManager.ON_METERCHANGE?.Invoke(meter);
    }

    private void MeterChecker()
    {
        if (meter > 0) return;
        meter = 0;
        meterStart = false;
        EventManager.ON_GAMEEND?.Invoke();
    }

    private void StartMeter()
    {
        meter = initialValue;
        EventManager.ON_METERCHANGE?.Invoke(meter);
        meterStart = true;
    }

    private void AddMeter()
    {
        meter += refillRate;
        meter = Mathf.Clamp(meter, 0, maxValue);
    }

    private void ModifyDecrease()
    {
        index++;
        index = Mathf.Clamp(index, 0, decreaseRates.Length - 1);
    }

    private void OnDestroy()
    {
        EventManager.ON_GAMESTART -= StartMeter;
        EventManager.ON_LAUGH -= AddMeter;
        EventManager.ON_DIFFICULTYINCREASE -= ModifyDecrease;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HappyMeterUI : MonoBehaviour
{
    [SerializeField] private Gradient meterColor;
    [SerializeField] private Image fill;

    private Slider meter;

    private void Awake()
    {
        meter = GetComponent<Slider>();

        fill.color = meterColor.Evaluate(1);
        EventManager.ON_METERCHANGE += UpdateMeter;
    }

    private void UpdateMeter(float happinessLevel)
    {
        meter.value = happinessLevel;
        fill.color = meterColor.Evaluate(meter.normalizedValue);
    }

    private void OnDestroy()
    {
        EventManager.ON_METERCHANGE -= UpdateMeter;
    }
}

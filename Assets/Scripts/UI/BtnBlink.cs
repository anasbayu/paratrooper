using UnityEngine;
using DG.Tweening;
using TMPro;

/// <summary>
/// This class is responsible for making UI buttons blink effects.
/// </summary>

public class BtnBlink : MonoBehaviour
{
    [SerializeField] private float blinkDuration = 0.5f;
    [SerializeField] private float blinkDelay = 0.1f;

    private void OnEnable()
    {
        StartBlinking();
    }

    private void OnDisable()
    {
        StopBlinking();
    }

    private void StartBlinking()
    {
        // Start the blinking effect
        transform.DOScale(Vector3.one * 1.1f, blinkDuration)
            .SetEase(Ease.OutSine)
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(blinkDelay);
    }

    private void StopBlinking()
    {
        // Stop the blinking effect
        transform.DOKill();
        transform.localScale = Vector3.one;
    }
}

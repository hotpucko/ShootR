using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    [SerializeField] private Image foregroundImage;
    [SerializeField] private float updateSpeedSeconds = 0.5f;
    [SerializeField] private Canvas canvas;
    [SerializeField] private float yOffsetFromPlayer;
    
    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        HandleHealthChanged(currentHealthPct);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ModifyHealth(-10);
    }

    private void LateUpdate()
    {
        canvas.transform.position = transform.position + Vector3.up * yOffsetFromPlayer;
        //canvas.transform.rotation = Quaternion.Euler(0, 0, 0);
        canvas.transform.LookAt(Camera.main.transform);
        canvas.transform.Rotate(new Vector3(0, 180, 0));
    }

    private void HandleHealthChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = foregroundImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        foregroundImage.fillAmount = pct;
    }
}
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    public Image damageScreen;
    
    public float currentAlpha = 0;

    public float duration = 0.5f;
    public bool isDamaged = false;
    private void Update()
    {
        if (isDamaged)
        {
            currentAlpha -= Time.deltaTime / duration;
            damageScreen.color = new Color(1,0,0,currentAlpha);
            if(currentAlpha <= 0)
            {
                isDamaged = false;
            }
        }
    }

    public void TriggerFlash()
    {
        currentAlpha = 0.5f;
        Color color = damageScreen.color;
        color.a = currentAlpha;
        damageScreen.color = color;
        isDamaged = true;
    }
}


using UnityEngine;
using UnityEngine.UI;
public class PowerUp : MonoBehaviour
{
    public Slider slider;
    public void setMaxTime(float time)
    {
        slider.maxValue = time;
        slider.value = time;
    }

    public void setTime(float time)
    {
        slider.value = time;
    }

    private void Update()
    {
        transform.parent.rotation = Quaternion.identity;
    }
}

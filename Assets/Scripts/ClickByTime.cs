using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickByTime : MonoBehaviour
{
    Coroutine startedCorountine;
    static Image image;
    float currentTime = 0;
    bool loadCircleTime = false;
    const float duration = 3f;

    void Awake()
    {
        if (!image)
        {
            image = GameObject.FindGameObjectWithTag("CircleTimer").GetComponent<Image>();
        }
    }

    void Update()
    {
        if (loadCircleTime)
        {
            image.fillAmount = FillAmountByTime(duration);
        }
    }

    public void PointerEnter()
    {
        startedCorountine = StartCoroutine(CountByClick());
    }

    public void PointerExit()
    {
        loadCircleTime = false;
        currentTime = 0;
        image.fillAmount = 0;
        StopCoroutine(startedCorountine);
    }

    IEnumerator CountByClick()
    {
        loadCircleTime = true;
        yield return new WaitForSeconds(duration);
        ExecuteEvents.Execute<IPointerClickHandler>(this.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        PointerExit();
    }

    float FillAmountByTime(float duration)
    {
        currentTime += Time.deltaTime;
        float proportion = currentTime / duration;
        return Mathf.Clamp01(proportion);
    }
}

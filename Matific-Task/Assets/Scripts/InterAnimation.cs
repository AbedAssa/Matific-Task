using System.Collections;
using UnityEngine;

public class InterAnimation : MonoBehaviour
{
    [SerializeField] RectTransform _blackBox;
    [SerializeField] RectTransform _circle;


    private void Start()
    {
        _circle.gameObject.SetActive(true);
        _blackBox.sizeDelta = new Vector2(Screen.width, Screen.height);
        _circle.sizeDelta = new Vector2(0, 0);


        StartCoroutine("AnimateCircle");
    }

    private IEnumerator AnimateCircle()
    {
        float time= 1f;
        float timeCount = 0;
        float count = 0f;
        Vector2 maxValue = Screen.width > Screen.height ? Vector2.one * Screen.width : Vector2.one * Screen.height;
        while(timeCount < time)
        {
            _circle.sizeDelta = Vector2.Lerp(Vector2.zero,maxValue, timeCount);
            timeCount += (0.0005f * 5 * count);
            count += 1;
            yield return null;

        }
        _circle.gameObject.SetActive(false);
        yield return null;

    }
}

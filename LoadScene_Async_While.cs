using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadScene_Async_While : MonoBehaviour {
    public Text text;
    public Image image;
    AsyncOperation ao;

	void Start () {
        image.fillAmount = 0;
        StartCoroutine(Loading());
	}

    IEnumerator Loading()
    {
        int currentValue = 0;
        int wantValue = 0;

        ao = SceneManager.LoadSceneAsync("Demo2_towers");
        ao.allowSceneActivation = false;

        while (ao.progress < 0.9f)
        {
            wantValue =(int) ao.progress * 100;
            while (currentValue < wantValue)
            {
                ++currentValue;
                image.fillAmount = currentValue / 100f;
                text.text = currentValue + "%";
                yield return new WaitForSeconds(0.05f);
            }
        }

        wantValue = 100;

        while (currentValue < wantValue)
        {
            ++currentValue;
            image.fillAmount = currentValue / 100f;
            text.text = currentValue + "%";
            yield return new WaitForSeconds(0.05f);
        }

        text.text = (image.fillAmount * 100).ToString("0") + "%";
        Debug.Log("加载完成");
        ao.allowSceneActivation = true;
    }
}

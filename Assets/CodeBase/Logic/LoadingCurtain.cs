using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Logic
{
    public class LoadingCurtain : MonoBehaviour
    {
        public CanvasGroup Curtain;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            Curtain.alpha = 1;
        }

        public void Hide() => StartCoroutine(DoFadeIn());

        private IEnumerator DoFadeIn()
        {
            transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Loading";
            yield return new WaitForSeconds(0.25f);
            transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Loading.";
            yield return new WaitForSeconds(0.25f);
            transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Loading..";
            yield return new WaitForSeconds(0.25f);
            transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Loading...";
            yield return new WaitForSeconds(0.25f);
            gameObject.SetActive(false);
        }
    }
}
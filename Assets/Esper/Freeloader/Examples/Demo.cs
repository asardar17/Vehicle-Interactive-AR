using System.Collections;
using UnityEngine;

namespace Esper.Freeloader.Examples
{
    public class Demo : MonoBehaviour
    {
        private static float progress;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            progress = 0;
            StartCoroutine(Test());
        }

        private IEnumerator Test()
        {
            // Give Freeloader a moment to initialize its UI
            yield return new WaitForSeconds(0.5f);

            if (!LoadingScreen.Instance.IsLoading)
            {
                var process = new LoadingProgressTracker(
                    "Loading...",
                    () => progress
                );

                LoadingScreen.Instance.Load("SampleScene", process);
            }

            // 10-second loading progress
            while (progress < 100)
            {
                progress += 10;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
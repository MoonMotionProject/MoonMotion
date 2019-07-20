using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.Threading
{
    public class EZThreadDemoScript : MonoBehaviour
    {
        public GameObject CircleSync;
        public GameObject CircleNonSync;
        public UnityEngine.UI.Text BackgroundResultLabel;

        private Vector3 circleSyncScale;
        private float circleSyncMultiplier = 1.1f;
        private Vector3 circleNonSyncScale;
        private float circleNonSyncMultiplier = 1.1f;

        private void ScaleCircle(ref Vector3 scale, ref float multiplier)
        {
            if (scale.x > 3.0f)
            {
                multiplier = 0.9f;
                scale = new Vector3(3.0f, 3.0f, 3.0f);
            }
            else if (scale.x < 0.25f)
            {
                multiplier = 1.1f;
                scale = new Vector3(0.25f, 0.25f, 0.25f);
            }
            else
            {
                scale *= multiplier;
            }
        }

        private void ScaleSyncThread()
        {
            // note- this function is called over and over, eliminating the need for a while (running) loop here
            ScaleCircle(ref circleSyncScale, ref circleSyncMultiplier);
        }

        private void ScaleNonSyncThread()
        {
            // note- this function is called over and over, eliminating the need for a while (running) loop here
            ScaleCircle(ref circleNonSyncScale, ref circleNonSyncMultiplier);
        }

        private object CalculateRandomNumberInBackgroundThread()
        {
            System.Random r = new System.Random();

#if NETFX_CORE

            System.Threading.Tasks.Task.Delay(500).Wait();

#else

            System.Threading.Thread.Sleep(500); // simulate a long running background task

#endif

            return r.Next();
        }

        private void CalculateRandomNumberInBackgroundCompletionOnMainThread(object result)
        {
            BackgroundResultLabel.text = "Your random number was " + result.ToString();
        }

        private void Start()
        {
            // start scaling the circle where the background thread runs in sync with the Update method
            // this would be great for something like pathfinding where the path needs to update every frame in the background
            circleSyncScale = CircleSync.transform.localScale;
            EZThread.BeginThread(ScaleSyncThread, true);

            // start scaling the circle where the background thread runs as fast as possible
            // this could be useful for something like network calls or other external resource loading
            // you will notice this circle appears to randomly change size, that is because
            // the background thread is scaling the circle super fast so when the update method
            // executes to set the actual scale, it will essentially be a random value.
            circleNonSyncScale = CircleNonSync.transform.localScale;
            EZThread.BeginThread(ScaleNonSyncThread, false);
        }

        private void Update()
        {
            // set the scales from the background thread calculations
            CircleSync.transform.localScale = circleSyncScale;
            CircleNonSync.transform.localScale = circleNonSyncScale;
        }

        public void ReloadScene()
        {
            // reload scene, causes all threads to be stopped
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        public void CalculateRandomNumberInBackground()
        {
            // execute a one-time background operation and call a completion on the main thread
            // completion is optional and could be null if desired
            EZThread.ExecuteInBackground(CalculateRandomNumberInBackgroundThread, CalculateRandomNumberInBackgroundCompletionOnMainThread);

            // ExecuteInBackground can be called with a single void function if you don't care about completion or the return result, i.e.
            // EZThread.ExecuteInBackground(() => DoBackgroundStuff());
        }
    }
}

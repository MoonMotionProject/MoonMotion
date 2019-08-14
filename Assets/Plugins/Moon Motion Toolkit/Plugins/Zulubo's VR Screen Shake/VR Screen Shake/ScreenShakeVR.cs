using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ScreenShakeVR : MonoBehaviour
{

    public static ScreenShakeVR instance;

    Material material;

    public float shakeMagnitude = 0.1f;
    public float shakeFrequency = 20f;

    private float shakeVal;
    float shakeCumulation;

    [Tooltip("Shake the screen when the space key is pressed")]
    public bool debug = false;

    public class ShakeEvent
    {
        public float magnitude;
        public float length;

        public bool finished { get { return time >= length; } }
        public float currentStrength { get { return magnitude * Mathf.Clamp01(1 - time / length); } }

        public ShakeEvent(float mag, float len, float exp = 2)
        {
            magnitude = mag;
            length = len;
        }

        private float time;

        public void Update(float deltaTime)
        {
            time += deltaTime;
        }
    }

    public List<ShakeEvent> activeShakes = new List<ShakeEvent>();

    // Creates a private material used to the effect
    void Awake()
    {
        instance = this;

        if (material != null)
        {
            material.shader = Shader.Find("Hidden/ScreenShakeVR");
        }
        else
        {
            material = new Material(Shader.Find("Hidden/ScreenShakeVR"));
        }
    }

    private void OnEnable()
    {
        Awake();
    }

    /// <summary>
    /// Trigger a shake event
    /// </summary>
    /// <param name="magnitude">Magnitude of the shaking. Should range from 0 - 1</param>
    /// <param name="length">Length of the shake event.</param>
    /// <param name="exponent">Falloff curve of the shaking</param>
    public void Shake(float magnitude, float length, float exponent = 2)
    {
        activeShakes.Add(new ShakeEvent(magnitude, length, exponent));
    }


    /// <summary>
    /// Trigger a global shake event
    /// </summary>
    /// <param name="magnitude">Magnitude of the shaking. Should range from 0 - 1</param>
    /// <param name="length">Length of the shake event.</param>
    /// <param name="exponent">Falloff curve of the shaking</param>
    public static void TriggerShake(float magnitude, float length, float exponent = 2)
    {
        if(instance == null)
        {
            Debug.LogWarning("No ScreenShakeVR Component in scene. Add one to a camera.");
        }
        else
        {
            instance.Shake(magnitude, length, exponent);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && debug)
        {
            Shake(0.5f, 1.0f);
        }

        shakeCumulation = 0;
        //iterate through all active shake events
        for (int i = activeShakes.Count - 1; i >= 0; i--)
        {
            //accumulate their current magnitude
            activeShakes[i].Update(Time.deltaTime);
            shakeCumulation += activeShakes[i].currentStrength;
            //and remove them if they've finished
            if (activeShakes[i].finished)
            {
                activeShakes.RemoveAt(i);
            }
        }

        if (shakeCumulation > 0)
        {
            shakeVal = Mathf.PerlinNoise(Time.time * shakeFrequency, 10.234896f) * shakeCumulation * shakeMagnitude;
        }
        else
        {
            shakeVal = 0;
        }
    }

    // Postprocess the image
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (Mathf.Approximately(shakeVal, 0) == false)
        {
            material.SetFloat("_ShakeFac", shakeVal);
            Graphics.Blit(source, destination, material);
        }
        else
        {
            //no shaking currently
            Graphics.Blit(source, destination);
        }
    }
}

using UnityEngine;

namespace Zen
{
    public class WebPlayerManager : MonoBehaviour
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public static void SetCaptureAllKeyboardInput(int value)
        {
            if (value == 1) WebGLInput.captureAllKeyboardInput = true;
            else WebGLInput.captureAllKeyboardInput = false;
        }

        public static void Sample()
        {
            Debug.Log("SAMPLE HIT");
        }
#endif
    }
}

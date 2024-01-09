using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Zen
{
    public class SampleUI : MonoBehaviour
    {
        public string ScenePath;

        void OnEnable()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;
            var buttonSample = root.Q<Button>("ButtonSample");
            buttonSample.clicked += () =>
            {
                SceneManager.LoadSceneSingle(ScenePath);
            };
        }
    }
}


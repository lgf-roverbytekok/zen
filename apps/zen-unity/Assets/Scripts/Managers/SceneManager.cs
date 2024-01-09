using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Zen
{
    public class SceneManager : MonoBehaviour
    {
        private static bool hasLoadedAScene = false;
        private static AsyncOperationHandle<SceneInstance> currentScene;

        public static AsyncOperationHandle<SceneInstance> LoadSceneSingle(string assetPath)
        {
            var handle = Addressables.LoadSceneAsync(assetPath, LoadSceneMode.Single);
            handle.Completed += OnLoadCompleted;
            return handle;
        }

        private static void OnLoadCompleted(AsyncOperationHandle<SceneInstance> handle)
        {
            if (hasLoadedAScene)
            {
                currentScene.Completed -= OnLoadCompleted;
                Addressables.UnloadSceneAsync(currentScene);
            }

            currentScene = handle;
            hasLoadedAScene = true;
        }
    }
}

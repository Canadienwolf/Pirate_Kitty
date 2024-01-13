using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Blobbers.Management
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        #region Init
        void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);

            Instance = this;
            DontDestroyOnLoad(gameObject);

            //Temp
            ShowCursor(false);
        }

        void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        #endregion

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            
        }

        void ShowCursor(bool visible)
        {
            Cursor.visible = visible;
            Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}

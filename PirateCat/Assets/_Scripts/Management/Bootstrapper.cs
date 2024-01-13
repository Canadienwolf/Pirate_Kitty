using UnityEngine;

namespace Blobbers.Bootstrapper
{
    public class Bootstrapper : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Init()
        {
            GameObject spawn = Resources.Load("System") as GameObject;
            GameObject.Instantiate(spawn);
        }
    }
}

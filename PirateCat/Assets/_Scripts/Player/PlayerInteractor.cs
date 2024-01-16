using UnityEngine;

namespace Blobbers.Player
{
    public class PlayerInteractor : MonoBehaviour
    {
        [Header("Camera")]
        [SerializeField] Transform cameraTrans;

        [Header("Interaction")]
        [SerializeField] float interactDistance = 2;
        [SerializeField] float castRadius = 0.2f;

        void Update()
        {
            RaycastHit _hit;

            if (Physics.SphereCast(cameraTrans.position, castRadius, cameraTrans.forward, out _hit, interactDistance))
            {
                //TODO: Add 
            }
        }
    }
}

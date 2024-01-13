using UnityEditor.ShortcutManagement;
using UnityEditor;
using UnityEngine;

namespace Blobbers
{
    public class ShortcutsScene
    {
        #region Reset Selected
        //Reset local position
        [ClutchShortcut("Blobbers/Reset Position", typeof(SceneView), KeyCode.W, ShortcutModifiers.Alt)]
        static void ResetPosition()
        {
            if (Selection.activeGameObject == null)
                return;

            Undo.RecordObject(Selection.activeTransform, "Selection Pos Reset");
            Selection.activeTransform.localPosition = Vector3.zero;
        }

        //Reset local rotation
        [ClutchShortcut("Blobbers/Reset Rotation", typeof(SceneView), KeyCode.R, ShortcutModifiers.Alt)]
        static void ResetRotation()
        {
            if (Selection.activeGameObject == null)
                return;

            Undo.RecordObject(Selection.activeTransform, "Selection Rot Reset");
            Selection.activeTransform.localEulerAngles = Vector3.zero;
        }

        //Reset local scale
        [ClutchShortcut("Blobbers/Reset Scale", typeof(SceneView), KeyCode.S, ShortcutModifiers.Alt)]
        static void ResetScale()
        {
            if (Selection.activeGameObject == null)
                return;

            Undo.RecordObject(Selection.activeTransform, "Selection Scale Reset");
            Selection.activeTransform.localScale = Vector3.one;
        }

        //Reset local transform
        [ClutchShortcut("Blobbers/Reset Transform", typeof(SceneView), KeyCode.T, ShortcutModifiers.Alt)]
        static void ResetTransform()
        {
            if (Selection.activeGameObject == null)
                return;

            ResetPosition();
            ResetRotation();
            ResetScale();
        }
        #endregion

        #region Rotate Selected
        static void Rotate(Vector3 dir)
        {
            if (Selection.activeGameObject == null) return;

            Selection.activeTransform.localEulerAngles += dir;
        }

        [ClutchShortcut("Blobbers/Rotate Left", typeof(SceneView), KeyCode.Q, ShortcutModifiers.Shift)]
        static void RotateLeft(ShortcutArguments args)
        {
            if(args.stage != ShortcutStage.Begin) return;

            Rotate(new Vector3(0, -90, 0));
        }

        [ClutchShortcut("Blobbers/Rotate Right", typeof(SceneView), KeyCode.E, ShortcutModifiers.Shift)]
        static void RotateRight(ShortcutArguments args)
        {
            if (args.stage != ShortcutStage.Begin) return;

            Rotate(new Vector3(0, 90, 0));
        }
        #endregion
    }
}

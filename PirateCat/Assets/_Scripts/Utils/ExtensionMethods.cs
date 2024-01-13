using System.Collections.Generic;
using UnityEngine;

namespace Blobbers
{
    public static class ExtensionMethods
    {
        #region Transform
        public static List<Transform> GetChildren(this Transform transform)
        {
            List<Transform> _children = new List<Transform>();

            foreach (Transform trans in transform)
            {
                _children.Add(trans);
            }

            return _children;
        }

        public static void UnparentChildren(this Transform transform)
        {
            Transform _parent = transform.parent;
            List<Transform> _children = transform.GetChildren();

            for (int i = 0; i < _children.Count; i++)
            {
                _children[i].parent = _parent;
            }
        }

        public static Vector3 TranformDirectionHorizontal(this Transform transform, Vector3 dir)
        {
            Vector3 _dir = transform.TransformDirection(dir);
            _dir.y = 0;
            _dir.Normalize();

            return _dir;
        }
        #endregion
    }
}

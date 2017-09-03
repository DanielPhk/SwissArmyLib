﻿using Archon.SwissArmyLib.ResourceSystem;
using UnityEditor;
using UnityEngine;

namespace Archon.SwissArmyLib.Editor.ResourceSystem
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ResourcePool), true)]
    public class ResourcePoolEditor : UnityEditor.Editor
    {
        private float _addVal = 50;
        private float _removeVal = 50;

        /// <inheritdoc />
        public override void OnInspectorGUI()
        {
            if (targets.Length == 1)
            {
                var resourcePool = (ResourcePool)target;
                EditorGUILayout.Separator();
                var containerRect = EditorGUILayout.BeginHorizontal();
                var barRect = GUILayoutUtility.GetRect(containerRect.width, 20);
                EditorGUI.ProgressBar(barRect, resourcePool.Percentage, string.Format("{0:F1} / {1:F1}", resourcePool.Current, resourcePool.Max));
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Separator();
            }

            DrawDefaultInspector();

            if (Application.isPlaying)
            {
                EditorGUILayout.Separator();

                EditorGUILayout.BeginHorizontal();
                _addVal = EditorGUILayout.FloatField(_addVal);
                if (GUILayout.Button("Add")) Add(_addVal);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                _removeVal = EditorGUILayout.FloatField(_removeVal);
                if (GUILayout.Button("Remove")) Remove(_removeVal);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("Empty")) Empty();
                if (GUILayout.Button("Fill")) Fill();
                if (GUILayout.Button("Renew")) Renew();
                EditorGUILayout.EndHorizontal();
            }
        }

        protected void Add(float amount)
        {
            for (var i = 0; i < targets.Length; i++)
                ((ResourcePool)targets[i]).Add(amount);
        }

        protected void Remove(float amount)
        {
            for (var i = 0; i < targets.Length; i++)
                ((ResourcePool)targets[i]).Remove(amount);
        }

        protected void Empty()
        {
            for (var i = 0; i < targets.Length; i++)
                ((ResourcePool)targets[i]).Empty();
        }

        protected void Fill()
        {
            for (var i = 0; i < targets.Length; i++)
                ((ResourcePool) targets[i]).Fill();
        }

        protected void Renew()
        {
            for (var i = 0; i < targets.Length; i++)
                ((ResourcePool)targets[i]).Renew();
        }
    }
}

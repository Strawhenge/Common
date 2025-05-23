using System;
using UnityEditor;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    [CustomEditor(typeof(LoggerScript))]
    public class LoggerScriptEditor : UnityEditor.Editor
    {
        LoggerScript _target;
        bool _foldoutLogMessages;
        string _message;

        void OnEnable()
        {
            _target = target as LoggerScript;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            _foldoutLogMessages = EditorGUILayout.Foldout(_foldoutLogMessages, "Messages");
            if (_foldoutLogMessages)
            {
                EditorGUI.BeginDisabledGroup(!Application.isPlaying);

                _message = EditorGUILayout.TextField("Message", _message);

                EditorGUILayout.BeginHorizontal();

                if (GUILayout.Button("Information"))
                    _target.LogInformation(_message);

                if (GUILayout.Button("Warning"))
                    _target.LogWarning(_message);

                if (GUILayout.Button("Error"))
                    _target.LogError(_message);

                if (GUILayout.Button("Exception"))
                    _target.LogException(new Exception(_message));

                EditorGUILayout.EndHorizontal();
                EditorGUI.EndDisabledGroup();
            }
        }
    }
}
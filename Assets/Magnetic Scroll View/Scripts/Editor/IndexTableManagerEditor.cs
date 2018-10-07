﻿using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace MagneticScrollView
{
    [CustomEditor (typeof (IndexTableManager))]
    [CanEditMultipleObjects]
    public class IndexTableManagerEditor : Editor
    {
        SerializedProperty indexPrefab;
        SerializedProperty indicatorPrefab;
        SerializedProperty alignment;
        SerializedProperty indicatorSize;

        MethodInfo ChangeLayoutGroup;
        MethodInfo ReplaceIndexes;
        MethodInfo ReplaceIndicator;
        MethodInfo ResizeIndicator;

        IndexTableManager myTarget;

        private void OnEnable ()
        {
            myTarget = (IndexTableManager)target;

            indexPrefab = serializedObject.FindProperty ("indexPrefab");
            indicatorPrefab = serializedObject.FindProperty ("indicatorPrefab");
            alignment = serializedObject.FindProperty ("m_alignment");
            indicatorSize = serializedObject.FindProperty ("indicatorSize");

            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            System.Type type = typeof (IndexTableManager);
            ChangeLayoutGroup = type.GetMethod ("ChangeLayoutGroup", bindingFlags);
            ReplaceIndexes = type.GetMethod ("ReplaceIndexes", bindingFlags);
            ReplaceIndicator = type.GetMethod ("ReplaceIndicator", bindingFlags);
            ResizeIndicator = type.GetMethod ("ResizeIndicator", bindingFlags);
        }

        public override void OnInspectorGUI ()
        {
            serializedObject.Update ();

            EditorUtility.SetDirty (myTarget.gameObject);

            EditorGUI.BeginChangeCheck (); // BEGIN CHECK
            EditorGUILayout.PropertyField (alignment);
            if (EditorGUI.EndChangeCheck ()) // END CHECK
            {                
                serializedObject.ApplyModifiedProperties ();
                ChangeLayoutGroup.Invoke (myTarget, null);
                GUIUtility.ExitGUI ();
            }
            EditorGUILayout.LabelField (new GUIContent ("Indicator Size", "Two flaot values between 0.1 - 2.0, used to scale the indicator size"), GUI.skin.label);

            EditorGUI.indentLevel ++;
            EditorGUI.BeginChangeCheck (); // BEGIN CHECK
            EditorGUILayout.Slider (indicatorSize.FindPropertyRelative("x"), 0.1f, 2f, new GUIContent("Width", "Scale indicator Width"));
            EditorGUILayout.Slider (indicatorSize.FindPropertyRelative ("y"), 0.1f, 2f, new GUIContent ("Height", "Scale indicator Height"));
            if (EditorGUI.EndChangeCheck ()) // END CHECK
            {
                serializedObject.ApplyModifiedProperties ();
                ResizeIndicator.Invoke (myTarget, null);
            }
            EditorGUI.indentLevel--;
            EditorGUI.BeginChangeCheck (); // BEGIN CHECK
            EditorGUILayout.PropertyField (indexPrefab);
            if(EditorGUI.EndChangeCheck ()) // END CHECK
            {                
                serializedObject.ApplyModifiedProperties ();
                ReplaceIndexes.Invoke (myTarget, null);
            }

            EditorGUI.BeginChangeCheck (); // BEGIN CHECK
            EditorGUILayout.PropertyField (indicatorPrefab);
            if (EditorGUI.EndChangeCheck ()) // END CHECK
            {
                serializedObject.ApplyModifiedProperties ();
                ReplaceIndicator.Invoke (myTarget, null);
            }

            serializedObject.ApplyModifiedProperties ();
        }
    }
}


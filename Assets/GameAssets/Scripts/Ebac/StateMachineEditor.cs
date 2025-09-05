using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FSMExemple))]
public class StateMachineEditor : Editor
{
    public bool ShowFoldout;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        FSMExemple fsm = (FSMExemple)target;

        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("StateMachine");
        if (fsm.stateMachine == null) return;

        if(fsm.stateMachine.CurrentState != null)
            EditorGUILayout.LabelField("Current State: ", fsm.stateMachine.CurrentState.ToString());
        ShowFoldout = EditorGUILayout.Foldout(ShowFoldout, "Available States");
        if (ShowFoldout)
        {
            if (fsm.stateMachine.dictionaryState != null)
            {
            
                var keys = fsm.stateMachine.dictionaryState.Keys.ToArray();
                var vals = fsm.stateMachine.dictionaryState.Values.ToArray();

                for (int i = 0; i < keys.Length; i++) 
                {
                    EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[1], vals[1]));
                }
            }
        }
    }


}

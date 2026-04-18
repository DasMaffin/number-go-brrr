#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Generator), true)]
public class GeneratorDrawer : PropertyDrawer
{
    private static readonly BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        label.text = property.managedReferenceValue?.GetType().Name ?? label.text;
        EditorGUI.PropertyField(position, property, label, true);

        if (property.managedReferenceValue is Generator generator)
        {
            EditorGUI.indentLevel++;

            var number = generator.GetType().BaseType.GetField("number", flags)?.GetValue(generator);
            var timer = generator.GetType().BaseType.GetField("timer", flags)?.GetValue(generator);

            var numberRect = new Rect(position.x, position.y + EditorGUI.GetPropertyHeight(property, true), position.width, EditorGUIUtility.singleLineHeight);
            var timerRect = new Rect(position.x, numberRect.y + EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight);

            GUI.enabled = false;
            EditorGUI.TextField(numberRect, "Number", number?.ToString() ?? "N/A");
            EditorGUI.TextField(timerRect, "Timer", timer?.ToString() ?? "N/A");
            GUI.enabled = true;

            EditorGUI.indentLevel--;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, true) + EditorGUIUtility.singleLineHeight * 2;
    }
}
#endif
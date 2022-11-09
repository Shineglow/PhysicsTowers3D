using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.UI;

#if UNITY_EDITOR
public class AdditionUIObjects {

    [MenuItem("GameObject/UI/Groups/VerticalLayout", false, 0)]
    public static void CreateVerticalLayoutObject()
    {
        var newHierarchiObject = new GameObject("VerticalLayout");
        newHierarchiObject.AddComponent<VerticalLayoutGroup>();
        newHierarchiObject.transform.SetParent(Selection.activeTransform, false);
    }

    [MenuItem("GameObject/UI/Groups/HorizontalLayout", false, 0)]
    public static void CreateHorizontalLayoutObject()
    {
        var newHierarchiObject = new GameObject("HorizontalLayout");
        newHierarchiObject.AddComponent<HorizontalLayoutGroup>();
        newHierarchiObject.transform.SetParent(Selection.activeTransform, false);
    }

    [MenuItem("GameObject/UI/Groups/GridLayout", false, 0)]
    public static void CreateGridLayoutObject()
    {
        var newHierarchiObject = new GameObject("GridLayout");
        newHierarchiObject.AddComponent<GridLayoutGroup>();
        newHierarchiObject.transform.SetParent(Selection.activeTransform, false);
    }
}
#endif
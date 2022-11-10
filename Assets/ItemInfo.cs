using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    [SerializeField]
    private string Text;
    [SerializeField]
    private TextMeshProUGUI textField;

    private void OnValidate()
    {
        textField.text = Text;
    }
}

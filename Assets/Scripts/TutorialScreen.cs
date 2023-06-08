using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textField;

    private void OnEnable()
    {
        textField.text = $"Keep running for as long as possible!\r\nUse space to {PlayerPrefs.GetString("JumpKey")}, and {PlayerPrefs.GetString("SwitchElementKey")} to change elements.\r\nMake sure your character's element matches that of the obstacles you come up against.";
    }
}

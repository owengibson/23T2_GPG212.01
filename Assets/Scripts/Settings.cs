using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GPG212_01
{
    public class Settings : MonoBehaviour
    {
        private bool isAwaitingInput = false;

        private GameObject activeButton;
        private TextMeshProUGUI activeButtonText;

        private void Start()
        {
            PlayerPrefs.SetString("JumpKey", "Space");
            PlayerPrefs.SetString("SwitchElementKey", "E");

        }

        private void Update()
        {
            if (isAwaitingInput)
            {
                foreach(KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(keyCode))
                    {
                        activeButtonText.text = keyCode.ToString();
                        if (activeButton.name == "Jump Key") PlayerPrefs.SetString("JumpKey", keyCode.ToString());
                        else PlayerPrefs.SetString("SwitchElementKey", keyCode.ToString());
                        isAwaitingInput = false;
                    }
                }
            }
        }

        public void RebindKey()
        {
            isAwaitingInput = true;
            activeButton = EventSystem.current.currentSelectedGameObject;
            activeButtonText = activeButton.GetComponentInChildren<TextMeshProUGUI>();
            activeButtonText.text = "Awaiting input...";
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCreateButton : MonoBehaviour
{
    [SerializeField] PlayerNameInputField nameField;

    public void EnterMainScene()
    {
        if (nameField?.canCreateName ?? false)
            SceneManager.LoadScene("MainScene");
    }
}

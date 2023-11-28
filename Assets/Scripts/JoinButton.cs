using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoinButton : MonoBehaviour
{
    [SerializeField] PlayerNameInputField nameField;

    public void EnterMainScene()
    {
        if ((nameField?.canCreateName ?? false) && (DataManager.Instance != null))
            SceneManager.LoadScene("MainScene");
        else
            nameField?.SetMessage("");
    }
}

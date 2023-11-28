using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterInstantiator : MonoBehaviour
{
    static CharacterInstantiator instance;
    [SerializeField] CharacterChanger characterChanger;
    public GameObject player;

    public static CharacterInstantiator Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = new GameObject(nameof(CharacterInstantiator));
                instance = obj.AddComponent<CharacterInstantiator>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        if (player == null)
            CreateCharacter(DataManager.Instance.SelectCharacterIndex);
        characterChanger.OnSelected += CreateCharacter;
    }

    public void CreateCharacter(int selectedIndex)
    {
        Vector2 position = Vector2.zero;
        if (player != null)
        {
            position = player.transform.position;
            Destroy(player);
        }
        player = Instantiate(DataManager.Instance.characterPrefabs[selectedIndex], position, Quaternion.identity);
    }
}
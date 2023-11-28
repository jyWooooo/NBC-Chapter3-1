using UnityEngine;
using TMPro;

public class SpeechBubble : MonoBehaviour
{
    public string script;
    public float lifeTime = 2f;
    [SerializeField] TextMeshPro textMesh;

    float t;

    private void OnDisable()
    {
        textMesh.text = script = "";
        t = 0f;
    }

    private void Update()
    {
        t += Time.deltaTime;
        if (t > lifeTime)
            gameObject.SetActive(false);
    }

    public void Enable(string script)
    {
        t = 0;
        textMesh.text = script;
        gameObject.SetActive(true);
    }
}
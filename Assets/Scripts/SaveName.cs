using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{

    public static SaveName save_Names;
    public InputField inputField;
    public string userName;

    private void Awake()
    {
        if (save_Names == null)
        {
            save_Names = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Update()
    {
        if (userName != inputField.text)
        {
            userName = inputField.text;
        }
    }
}
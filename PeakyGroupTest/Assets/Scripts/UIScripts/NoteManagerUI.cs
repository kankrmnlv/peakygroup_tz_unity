using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class NoteManagerUI : MonoBehaviour
{
    private Keyboard keyboard;

    public static NoteManagerUI Instance;

    public GameObject note;
    public TMP_Text noteText;
    public PlayerMovement playerMovement;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        keyboard = Keyboard.current;
    }

    private void Update()
    {
        if(note.activeSelf && keyboard.escapeKey.wasPressedThisFrame)
        {
            CloseNote();
        }
    }
    public void ShowNote(string text)
    {
        noteText.text = text;
        note.SetActive(true);
        playerMovement.enabled = false;
    }

    public void CloseNote()
    {
        note.SetActive(false);
        playerMovement.enabled = true;
    }
}

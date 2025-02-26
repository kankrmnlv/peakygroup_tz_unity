using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandlerUI : MonoBehaviour
{
    private Keyboard keyboard;

    public NoteManagerUI noteManager;
    public ItemsUI items;

    private void Start()
    {
        keyboard = Keyboard.current;
    }

    private void Update()
    {
        if(noteManager.note.activeSelf && keyboard.escapeKey.wasPressedThisFrame)
        {
            noteManager.CloseNote();
        }
        if (keyboard.eKey.wasPressedThisFrame)
        {
            items.ToggleItemsScreen();
        }
    }
}

using UnityEngine;

public class Note : Interactable
{
    public string[] noteText;
    public override void Interact(Player player)
    {
        if(noteText.Length > 0)
        {
            string showText = noteText[Random.Range(0, noteText.Length)];
            NoteManagerUI.Instance.ShowNote(showText);
        }

        ItemSaver.Instance.ItemPickup(gameObject.name);

        Destroy(gameObject);
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "NewNPC", menuName = "NPC/New NPC")]
public class NPC : ScriptableObject
{
    [SerializeField] private Sprite model;
    [SerializeField] private Sprite npcIcon;
    [SerializeField] private string npcName;
    [SerializeField] private string npcDescription;
    [SerializeField] private string[] dialogue;
    public Sprite Model { get { return model; } }
    public Sprite NPCIcon { get { return npcIcon; } }
    public string NPCName { get { return npcName; } }
    public string NPCDescription { get { return npcDescription; } }
    public string[] Dialogue { get { return dialogue; } }


}

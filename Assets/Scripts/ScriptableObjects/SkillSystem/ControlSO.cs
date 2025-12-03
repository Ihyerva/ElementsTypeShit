using UnityEngine;

[CreateAssetMenu(fileName = "ControlSO", menuName = "Scriptable Objects/ControlSO")]
public class ControlSO : ScriptableObject
{
    [field: SerializeField] public SkillSO bindedSkill { get; set; }
    [field: SerializeField] public string bindingName { get; set; }
}
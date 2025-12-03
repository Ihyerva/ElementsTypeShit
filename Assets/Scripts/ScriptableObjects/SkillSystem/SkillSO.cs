using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillSO", menuName = "Scriptable Objects/SkillSO")]
public class SkillSO : ScriptableObject
{
    [SerializeField]
    private string skillCode;
    [SerializeField]
    private string skillName;
    [SerializeField]
    private Sprite skillIcon;
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float currentCooldown;
    public void CastSkill()
    {
        Debug.Log("Casting skill: " + skillName);
    }

    internal string GetSkillCode()
    {
        return skillCode;
    }
}

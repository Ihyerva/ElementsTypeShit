using UnityEngine;

[CreateAssetMenu(fileName = "CombinationSO", menuName = "Scriptable Objects/CombinationSO")]
public class CombinationSO : ScriptableObject
{
    private const byte skillsPerCombination = 4;
    [SerializeField]
    private string elementCode;
    public string []skillCodes = new string[skillsPerCombination];
    public SkillSO []skills = new SkillSO[skillsPerCombination];

    public string GetElementCode()
    {
        return elementCode;
    }
}

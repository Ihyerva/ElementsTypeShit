using UnityEngine;

[CreateAssetMenu(fileName = "ElementSO", menuName = "Scriptable Objects/ElementSO")]
public class ElementSO : ScriptableObject
{
    [SerializeField]
    private string elementCode;
    private const byte skillsPerElement = 2;
    private const byte maxCombinations = 3;
    public SkillSO []skills = new SkillSO[skillsPerElement];
    public CombinationSO[] possibleCombinations = new CombinationSO[maxCombinations];

    public string GetElementCode()
    {
        return elementCode;
    }
}

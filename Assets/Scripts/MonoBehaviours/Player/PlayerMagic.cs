using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMagic : MonoBehaviour
{
    public ElementSO testElement1;
    public ElementSO testElement2;

    private List<ElementSO> elements = new List<ElementSO>();
    private Dictionary<string, SkillSO> skills = new Dictionary<string, SkillSO>();
    
    [SerializeField]
    private InputActionReference comboSpellInputAction;
    [SerializeField]
    private List<ControlSO> comboConfigs;
    private bool isCasting = false;
    private string currentCastingSkillCode = "";


    void Start()
    {
        AddElement(testElement1);
        AddElement(testElement2);
        foreach(var skill in skills)
        {
            Debug.Log("Skill: " + skill.Key + " -> " + skill.Value.name);
        }
    }
    void OnEnable()
    {
        if(comboSpellInputAction != null)
        {
            comboSpellInputAction.action.Enable();
            comboSpellInputAction.action.performed += onSkillButtonPressed;
        }
    }
    void OnDisable()
    {
        if (comboSpellInputAction != null)
        {
            comboSpellInputAction.action.Disable();
            comboSpellInputAction.action.performed -= onSkillButtonPressed;
        }
    }

    private void onSkillButtonPressed(InputAction.CallbackContext context)
    {

        if(context.control.IsPressed() == false)
        {
            if (isCasting)
            {
                isCasting = false;
                currentCastingSkillCode = new string(currentCastingSkillCode.OrderBy(c => c).ToArray());
                if (skills.ContainsKey(currentCastingSkillCode))
                {
                    SkillSO skillToCast = skills[currentCastingSkillCode];
                    skillToCast.CastSkill();
                }
                else
                {
                    Debug.Log("No skill found for code: " + currentCastingSkillCode);
                }
            }
        }
        else
        {
            if (!isCasting)
            {
                isCasting = true;
                currentCastingSkillCode = "";
            }
            for(int i = 0;i< comboConfigs.Count;i++)
                if(comboConfigs[i].bindingName == context.control.name)
                {
                    if(comboConfigs[i].bindedSkill != null)
                        currentCastingSkillCode += comboConfigs[i].bindedSkill.GetSkillCode();
                }
        }


    }
    

    public void AddElement(ElementSO newElement)
    {
        elements.Add(newElement);
        //Add base element skills
        for(int i = 0;i<newElement.skills.Length;i++)
        skills.Add(newElement.skills[i].GetSkillCode(),newElement.skills[i]);
        //Add combinations
        int combinationIndex = elements.IndexOf(newElement);
        for(int i = combinationIndex - 1;i>=0;i--)
        {
            ElementSO otherElement = elements[i];
            foreach(CombinationSO combination in newElement.possibleCombinations)
            {   
                string newCombinationElementCode = new string((newElement.GetElementCode() + otherElement.GetElementCode()).OrderBy(c => c).ToArray());
                if(combination != null && newCombinationElementCode == combination.GetElementCode())
                {
                    for(int j = 0;j<combination.skills.Length;j++)
                        skills.Add(combination.skillCodes[j],combination.skills[j]);
                }
            }
        }
    }
}

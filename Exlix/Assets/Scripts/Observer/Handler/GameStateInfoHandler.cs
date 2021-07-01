using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateInfoHandler : ObserableHandler<GameStateInfo>
{
    public GameStateInfoHandler()
    {
        Information = new GameStateInfo();
    }

    public void SetSkillDataTamplateList(List<SkillDataTemplate> skillDataTemplateList)
    {
        Information.skillDataTemplateList = skillDataTemplateList;
        base.NotifyObservers();
    }
    public void SetCardDataTamplateList(List<CardDataTemplate> cardDataTemplateList)
    {
        Information.cardDataTemplateList = cardDataTemplateList;
        base.NotifyObservers();
    }

    public SkillDataTemplate GetSkillDataTamplate(string Number)
    {
        foreach (var template in Information.skillDataTemplateList) {
            if (template.Data["Number"] == Number) return template;
        }
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateInfoHandler : ObserableHandler<GameStateInfo>
{
    public GameStateInfoHandler()
    {
        Information = new GameStateInfo();
    }

    public void SetSkillDataTamplate(SkillDataTemplate skillDataTemplate)
    {
        Information.skillDataTemplate = skillDataTemplate;
        base.NotifyObservers();
    }
    public void SetCardDataTamplate(SkillDataTemplate skillDataTemplate)
    {
        Information.skillDataTemplate = skillDataTemplate;
        base.NotifyObservers();
    }
    public void SetItemDataTamplate(SkillDataTemplate skillDataTemplate)
    {
        Information.skillDataTemplate = skillDataTemplate;
        base.NotifyObservers();
    }

    public SkillDataTemplate GetSkillDataTamplate()
    {
        return Information.skillDataTemplate;
    }
}

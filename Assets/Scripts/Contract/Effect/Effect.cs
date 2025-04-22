using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// 这个定义优先级，类似于执行的顺序
// 后面的有个关于这个计算
public enum EffectPriority
{
    None,
    Low,
    Medium,
    High,
}
public enum EffectType
{
    None,
    SpecialEffect,
    DataEffect,
}

public abstract class Effect<T> : IEffect
{
    
    protected EffectType effectType;
    protected EffectPriority priority;
    protected bool isActive = false;

    protected Effect( EffectPriority priority, EffectType effectType)
    {
        this.effectType = effectType;
        this.priority = priority;
        isActive = false;
    }

    public void Apply()
    {
        isActive = true;
    }

    public void Cancel()
    {
        isActive = false;
    }


    public EffectPriority GetEffectPriority()
    {
        return priority;
    }

}


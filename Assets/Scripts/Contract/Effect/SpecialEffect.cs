using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public abstract class SpecialEffect : Effect
{
    protected SpecialEffect(Action action, EffectPriority priority,EffectType effectType = EffectType.SpecialEffect) : base(action, priority, effectType)
    {
        
    }
}
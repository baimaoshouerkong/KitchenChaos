using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class SpecialEffect<T> : Effect<T>
{
    public Action action;
    protected SpecialEffect(EffectPriority priority, EffectType effectType = EffectType.SpecialEffect) : base(priority, effectType)
    {

    }
}
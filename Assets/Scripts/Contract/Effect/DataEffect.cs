using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public abstract class DataEffect : Effect
{
    protected DataEffect(Action action, EffectPriority priority, EffectType effectType = EffectType.DataEffect) : base(action, priority, effectType)
    {

    }
}

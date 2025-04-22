using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// 对于数据来说优先级先先对优先级的进行运算
public class DataEffect<T> : Effect<T>
{
    protected DataEffect(EffectPriority priority, EffectType effectType = EffectType.DataEffect) : base( priority, effectType)
    {

    }
}

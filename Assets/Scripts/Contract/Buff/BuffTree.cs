using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Buff树
/// 对于如何管理这棵树
/// 只有数值的先放在左边，只有效果的放在右边
/// 中间就是又有数值又有效果的
/// </summary>
/// <typeparam name="T"></typeparam>
public class BuffTree<T>
{
    public int level = 0;
    public BuffTree<T> parent;
    public List<Buff<T>> list = new List<Buff<T>>();
    public BuffTree<T> left;
    public BuffTree<T> middle;
    public BuffTree<T> right;
    public Buff<T> buff;

    public BuffTree(Buff<T> buff, int level = 0)
    {
        this.level = level;
        this.buff = buff;
    }

    public void AddChild(BuffType buffType, Buff<T> buff)
    {
        CatorizeBuff(buffType, buff);
    }

    public void CatorizeBuff(BuffType buffType, Buff<T> buff)
    {
        if (buffType == BuffType.DataEffect)
        {
            left.list.Add(buff);
            left.level = level + 1;
            CatorizePriority(left, buff);
        }
        else if (buffType == BuffType.SpecialEffect)
        {
            right.list.Add(buff);
            right.level = level + 1;
            CatorizePriority(right, buff);
        }
        else if (buffType == BuffType.DataAndSpecialEffect)
        {
            middle.list.Add(buff);
            middle.level = level + 1;
            CatorizePriority(middle, buff);
        }
    }
    public void CatorizePriority(BuffTree<T> buffTree, Buff<T> buff)
    {
        if (buff.buffType == BuffType.DataEffect)
        {
            buffTree.left.list.Add(buff);
            buffTree.left.level = level + 1;
        }
        else if (buff.buffType == BuffType.SpecialEffect)
        {
            buffTree.right.list.Add(buff);
            buffTree.right.level = level + 1;
        }
        else if (buff.buffType == BuffType.DataAndSpecialEffect)
        {
            buffTree.middle.list.Add(buff);
            buffTree.middle.level = level + 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    private IList<int> stones;

    public Lake(IList<int> stones)
    {
        this.stones = stones;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.stones.Count; i += 2)
        {
            yield return this.stones[i];
        }

        int stonesCounterHelper;
        if (stones.Count % 2 == 0)
        {
            stonesCounterHelper = 1;
        }
        else
        {
            stonesCounterHelper = 2;
        }

        for (int j = this.stones.Count - stonesCounterHelper; j >= 0; j -= 2)
        {
            yield return this.stones[j];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}

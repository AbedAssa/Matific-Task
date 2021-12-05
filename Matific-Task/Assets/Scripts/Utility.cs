using System.Collections.Generic;

/// <summary>
/// Class for sorting.
/// </summary>
public static class  Utility
{
    public static void IntArrayQuickSort(List<CustomObjectConfig> data, int l, int r)
    {
        int i, j;
        int x;

        i = l;
        j = r;

        x = data[(l + r) / 2].order; /* find pivot item */
        while (true)
        {
            while (data[i].order < x)
                i++;
            while (x < data[j].order)
                j--;
            if (i <= j)
            {
                Swap(data, i, j);
                i++;
                j--;
            }
            if (i > j)
                break;
        }
        if (l < j)
            IntArrayQuickSort(data, l, j);
        if (i < r)
            IntArrayQuickSort(data, i, r);
    }

    public static void IntArrayQuickSort(List<CustomObjectConfig> data)
    {
        IntArrayQuickSort(data, 0, data.Count - 1);
    }

    public static void Swap(List<CustomObjectConfig> data, int l, int r)
    {
        CustomObjectConfig left = data[l];
        data[l] = data[r];
        data[r] = left;
    }
}

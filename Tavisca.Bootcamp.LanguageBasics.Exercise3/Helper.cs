using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise3
{
    class Helper
    {
        public static void minimum(bool[] ar, int[] val, int size)
        {
            int minval = int.MaxValue;
            for (int i = 0; i < size; i++)
            {
                if (ar[i] && minval > val[i])
                    minval = val[i];
            }

            for (int i = 0; i < size; i++)
            {
                if (ar[i] && minval != val[i])
                    ar[i] = false;
            }

        }

        public static void maximum(bool[] ar, int[] val, int size)
        {
            int maxval = int.MinValue;
            for (int i = 0; i < size; i++)
            {
                if (ar[i] && maxval < val[i])
                    maxval = val[i];
            }

            for (int i = 0; i < size; i++)
            {
                if (ar[i] && maxval != val[i])
                    ar[i] = false;
            }

        }
    }
}

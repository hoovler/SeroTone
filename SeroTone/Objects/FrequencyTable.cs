using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeroTone.Objects
{
    class FrequencyTable
    {
        // TABLE OF MUSICAL NOTE FREQUENCIES(Hz)
        // Octave:  0   1   2   3   4   5   6       7       |MappedValue
        // Note:    ----------------------------------------------------
        //  C       16  33  65  131 262 523 1046    2093    |c
        //  C#      17  35  69  139 277 554 1109    2217    |cs
        //  D       18  37  73  147 294 587 1175    2349    |d
        //  D#      19  39  78  155 311 622 1244    2489    |ds
        //  E       21  41  82  165 330 659 1328    2637    |e
        //  F       22  44  87  175 349 698 1397    2794    |f
        //  F#      23  46  92  185 370 740 1480    2960    |fs
        //  G       24  49  98  196 392 784 1568    3136    |g
        //  G#      26  52  104 208 415 831 1661    3322    |gs
        //  A       27  55  110 220 440 880 1760    3520    |a
        //  A#      29  58  116 233 466 932 1865    3729    |as
        //  B       31  62  123 245 494 988 1975    3951    |b
        //          ------------------------------------

        // 1: Set absolute min and max based on human hearing range; extreme outliers
        private static int ABS_MIN_Hz = 12;
        private static int ABS_MAX_Hz = 20000;

        // 2: Set ideal min / max frequencies for outliers
        private static int PREF_MIN_Hz = 131;
        private static int PREF_MAX_HZ = 4186;

        // create vectors holding thresholds for each octave

    }
}

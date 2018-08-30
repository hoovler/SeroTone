using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeroTone.Objects
{
    class FrequencyTable
    {

        //| Octave 		| −1 			| 0 		  | 1    		| 2 		  | 3 			| 4 		  | 5 			| 6 		  | 7 				| 8 		   | 9 				| 10 	   |
        //| ----- 		| --- 			| --- 		  | --- 		| --- 		  | --- 		| --- 		  | --- 		| --- 		  | --- 			| --- 		   | --- 			| --- 	   |
        //| C 			| 8.1758 (0) 	| 16.352 (12) | 32.703 (24) | 65.406 (36) | 130.81 (48) | 261.63 (60) | 523.25 (72) | 1046.5 (84) | 2093.0 (96) 	| 4186.0 (108) | 8372.0 (120)	| 16744 () |
        //| C ♯ /D ♭  	| 8.6620 (1) 	| 17.324 (13) | 34.648 (25) | 69.296 (37) | 138.59 (49) | 277.18 (61) | 554.37 (73) | 1108.7 (85) | 2217.5 (97) 	| 4434.9 (109) | 8869.8 (121)	| 17740 () |
        //| D 			| 9.1770 (2) 	| 18.354 (14) | 36.708 (26) | 73.416 (38) | 146.83 (50) | 293.66 (62) | 587.33 (74) | 1174.7 (86) | 2349.3 (98) 	| 4698.6 (110) | 9397.3 (122)	| 18795 () |
        //| E ♭ /D ♯  	| 9.7227 (3) 	| 19.445 (15) | 38.891 (27) | 77.782 (39) | 155.56 (51) | 311.13 (63) | 622.25 (75) | 1244.5 (87) | 2489.0 (99) 	| 4978.0 (111) | 9956.1 (123)	| 19912 () |
        //| E 			| 10.301 (4) 	| 20.602 (16) | 41.203 (28) | 82.407 (40) | 164.81 (52) | 329.63 (64) | 659.26 (76) | 1318.5 (88) | 2637.0 (100)	| 5274.0 (112) | 10548 (124) 	| 21096 () |
        //| F 			| 10.914 (5) 	| 21.827 (17) | 43.654 (29) | 87.307 (41) | 174.61 (53) | 349.23 (65) | 698.46 (77) | 1396.9 (89) | 2793.8 (101)	| 5587.7 (113) | 11175 (125) 	| 22351 () |
        //| F ♯ /G ♭  	| 11.563 (6) 	| 23.125 (18) | 46.249 (30) | 92.499 (42) | 185.00 (54) | 369.99 (66) | 739.99 (78) | 1480.0 (90) | 2960.0 (102)	| 5919.9 (114) | 11840 (126) 	| 23680 () |
        //| G 			| 12.250 (7) 	| 24.500 (19) | 48.999 (31) | 97.999 (43) | 196.00 (55) | 392.00 (67) | 783.99 (79) | 1568.0 (91) | 3136.0 (103)	| 6271.9 (115) | 12544 (127) 	| 25088 () |
        //| A ♭ /G ♯  	| 12.979 (8) 	| 25.957 (20) | 51.913 (32) | 103.83 (44) | 207.65 (56) | 415.30 (68) | 830.61 (80) | 1661.2 (92) | 3322.4 (104)	| 6644.9 (116) | 13290() 		| 26580 () |
        //| A 			| 13.750 (9) 	| 27.500 (21) | 55.000 (33) | 110.00 (45) | 220.00 (57) | 440.00 (69) | 880.00 (81) | 1760.0 (93) | 3520.0 (105)	| 7040.0 (117) | 14080 () 		| 28160 () |
        //| B ♭ /A ♯  	| 14.568 (10)	| 29.135 (22) | 58.270 (34) | 116.54 (46) | 233.08 (58) | 466.16 (70) | 932.33 (82) | 1864.7 (94) | 3729.3 (106)	| 7458.6 (118) | 14917 () 		| 29834 () |
        //| B 			| 15.434 (11)	| 30.868 (23) | 61.735 (35) | 123.47 (47) | 246.94 (59) | 493.88 (71) | 987.77 (83) | 1975.5 (95) | 3951.1 (107)	| 7902.1 (119) | 15804 () 		| 31609 () |

        // Set ideal min / max frequencies for outliers
        private static int MIN_Hz = 131;
        private static int MAX_HZ = 4186;

        // parallel arrays where the first is the note; second is lowest corresponding freq (Hz); third is the highest
        // based on the tuning of a = 4400; the below covers four full octaves (3-7 above)
        private static string[] chromaticScale = { "c", "cs", "d", "ds", "e", "f", "fs", "g", "gs", "a", "bf", "b" };
        private static double[] loFreq = { 130.8128, 138.5913, 146.8324, 155.5635, 164.8138, 174.6141, 184.9972, 195.9977, 207.6523, 220.0000, 233.0819, 246.9417 };
        private static double[] hiFreq = { 2093.005, 2217.461, 2349.318, 2489.016, 2637.020, 2793.826, 2959.955, 3135.963, 3322.438, 3520.000, 3729.310, 3951.066 };
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public double GetLowest(string note)
        {
            double retVal;
            int idx = Array.FindIndex<string>(chromaticScale, x => x.Equals(note.ToLower()));

            if (idx < 0)
            {
                // print a warning somewhere; 
                // there's no actual note found, so use the value of the lowest "c"
                retVal = loFreq[0];
            }
            else
            {
                retVal = loFreq[idx];
            }

            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public double GetHighest(string note)
        {
            double retVal;
            int idx = Array.FindIndex<string>(chromaticScale, x => x.Equals(note.ToLower()));

            if (idx < 0)
            {
                // print a warning somewhere; 
                // there's no actual note found, so use the value of the highest "b"
                retVal = hiFreq[hiFreq.Length - 1];
            }
            else
            {
                retVal = hiFreq[idx];
            }

            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        /// <param name="octave"></param>
        /// <returns></returns>
        public double GetAtOctave(string note, int octave)
        {
            double baseVal = GetLowest(note.ToLower());
            for (int i = 0; i < octave; i++)
            {
                baseVal = baseVal * 2;
            }
            return baseVal;
        }

        /// <summary>
        /// This method evenly distributes a provided number of notes between two given frequencies;
        /// Defaults to using lowest and highest notes of the parallel frequency arrays.
        /// </summary>
        /// <param name="startTone">Optional, double.  Frequency of lowest tone.</param>
        /// <param name="endTone">Optional, double.  Frequency of highest tone.</param>
        /// <param name="numNotes">Required, int.  Number of evenly-spaced tones to generate.</param>
        /// <returns></returns>
        public double[] EvenSpread(int numNotes, double startTone = 130.8128, double endTone = 3951.066)
        {
            double[] retVal = {1.11111, 1.11111 };

            return retVal;
        }
    }
}

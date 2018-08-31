namespace SeroTone.Utils
{
    class Global
    {

        /// <summary>
        /// Set to <code>false</code> to use the funky radial brush patterns,
        /// and any other non-standard functionality I might bake in...
        /// </summary>
        public static bool RENDER_NORMAL = true;

        /// <summary>
        /// Format and file extension of the output audio file
        /// </summary>
        public const string OUTPUT_SUFFIX = ".wav";

        /// <summary>
        /// Name of the UI element containing the input data
        /// </summary>
        public static string[] DYNAMIC_ELEMENTS = { "TextBlock_InputData" };

        /// <summary>
        /// The font used for the UI element containing the input data
        /// </summary>
        public static string INPUT_DATA_FONT = "Source Code Pro";

        // each byte vector represents a color; used in Color.FromArgb()
        private static byte[] gs1 = { 0xFF, 0xFF, 0xFF, 0xFF };
        private static byte[] gs2 = { 0xFF, 0x7E, 0xFF, 0xA7 };
        private static byte[] gs3 = { 0xFF, 0xFF, 0xFF, 0xFF };
        private static byte[] gs4 = { 0xFF, 0x7E, 0xFF, 0xA7 };
        private static byte[] gs5 = { 0xFF, 0xFF, 0x7E, 0x98 };
        private static byte[] gs6 = { 0xFF, 0xF5, 0xB6, 0xC3 };
        private static byte[] gs7 = { 0xFF, 0xF5, 0xEF, 0xB6 };

        /// <summary>
        /// A vector of byte vectors, for use when <code>RENDER_NORMAL = false</code>
        /// Each element is a vector that represents a gradient stop used in context of: 
        ///     <code>
        ///         RadialGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(GRAD_STOP_COLORS[0]), GRAD_STOP_OFFSETS[0]));
        ///         RadialGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(GRAD_STOP_COLORS[GRAD_STOP_COLORS.Length]), GRAD_STOP_OFFSETS[0]));
        ///     </code>
        /// </summary>
        public static byte[][] GRAD_STOP_COLORS = { gs1, gs2, gs3, gs4, gs5, gs6, gs7 };
        
        /// <summary>
        /// 
        /// </summary>
        public static double[] GRAD_STOP_OFFSETS = { .218, .367, 0, .474, .758, .29, 1 };
    }
}

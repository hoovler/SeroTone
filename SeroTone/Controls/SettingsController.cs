using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeroTone.Controls
{
    class SettingsController 
    {
        // Problem 1:   How to define a class to prepare settings & configuration for run-time WHILE PRESERVING
        //              the notion of dynamic input?  Reflection?

        
        private static SettingsPropertyCollection PROPS = Properties.Settings.Default.Properties;
        

        public static void InitializeSettingsController()
        {
            foreach (SettingsProperty prop in PROPS)
            {
                if (IsList(prop))
                {
                    DoUnlist(prop);
                }
            }
        }

        private static bool IsList(SettingsProperty prop)
        {
            bool unlist = false;

            return unlist;
        }

        private static void DoUnlist(SettingsProperty prop)
        {

        }
    }
}

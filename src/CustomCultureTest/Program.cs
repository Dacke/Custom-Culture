using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Globalization;


namespace CustomCultureTest
{
    class Program
    {
        private const string customCultureLanguageCode = "en-CH";
        private const string puertoRicoLanguageCode = "es-PR";

        static void Main(string[] args)
        {
            CultureAndRegionInfoBuilder cib = null;

            try
            {
                // Create a CultureAndRegionInfoBuilder object named "x-en-US-sample".
                Console.WriteLine("Create and explore the CultureAndRegionInfoBuilder...\n");
                cib = new CultureAndRegionInfoBuilder(customCultureLanguageCode, CultureAndRegionModifiers.None);

                // Populate the new CultureAndRegionInfoBuilder object with culture information.
                var defaultCulture = new CultureInfo("en-US");
                Console.WriteLine("Culture to base custom culture on (\"en-US\")...");
                DisplayCultureInformation(defaultCulture);
                
                cib.LoadDataFromCultureInfo(defaultCulture);
                
                Console.WriteLine("Displaying region information for Spain");
                DisplayRegionInformation(new RegionInfo("ES"));

                Console.WriteLine("Displaying region information for Puerto Rico");
                DisplayRegionInformation(new RegionInfo("PR"));

                Console.WriteLine("Displaying region information for the United Kingdom");
                DisplayRegionInformation(new RegionInfo("GB"));
                
                var ri = new RegionInfo("CH");
                Console.WriteLine("Displaying region information for Switzerland");
                DisplayRegionInformation(ri);
                cib.LoadDataFromRegionInfo(ri);

                //  Set the name up for the custom name.
                cib.CultureEnglishName = cib.CultureNativeName = "English (Switzerland)";
                cib.ThreeLetterWindowsLanguageName = "END";
                
                Console.WriteLine("Custom Culture Information...");
                DisplayCultureAndRegionInfoBuilderInformation(cib);

                var ukCib = new CultureAndRegionInfoBuilder("en-GB", CultureAndRegionModifiers.Replacement);
                ukCib.LoadDataFromRegionInfo(new RegionInfo("GB"));
                DisplayCultureAndRegionInfoBuilderInformation(ukCib);

                // Register the custom culture.
                Console.WriteLine("Register the custom culture...\n");
                cib.Register();

                // Display some of the properties of the custom culture.
                Console.WriteLine("Create and explore the English (United Kingdom) culture...\n");
                DisplayCultureInformation(new CultureInfo("en-gb"));

                Console.WriteLine("Create and explore the custom culture...\n");
                DisplayCultureInformation(new CultureInfo(customCultureLanguageCode));

                Console.WriteLine("Create and explore the Spanish (Spain) culture...\n");
                DisplayCultureInformation(new CultureInfo("es"));
                
                Console.WriteLine("Create and explore the Spanish (Puerto Rico) culture...\n");
                DisplayCultureInformation(new CultureInfo(puertoRicoLanguageCode));

                //var rm = new ResourceManager("CustomCultureTest.App_GlobalResources.resources", Assembly.GetExecutingAssembly());
                var rm = new CustomResourceManager("CustomCultureTest.App_GlobalResources.resources", Assembly.GetExecutingAssembly());

                CultureInfo strCulture;
                String output;

                strCulture = new CultureInfo(customCultureLanguageCode);
                output = rm.GetString("Default", strCulture);
                Console.WriteLine("The current culture: {0}", strCulture.Name);
                Console.WriteLine("The value for the resource key... <{0}>\n", output);

                strCulture = new CultureInfo(puertoRicoLanguageCode);
                output = rm.GetString("Default", strCulture);
                Console.WriteLine("The current culture: {0}", strCulture.Name);
                Console.WriteLine("The value for the resource key... <{0}>\n", output);

                strCulture = new CultureInfo("en-GB");
                output = rm.GetString("Default", strCulture);
                Console.WriteLine("The current culture: {0}", strCulture.Name);
                Console.WriteLine("The value for the resource key... <{0}>\n", output);

                Console.WriteLine("\nNote:\n" + 
                                  "Use the example in the Unregister method topic to remove the custom culture.");
            }
            catch (Exception e)
            {
                if (Debugger.IsAttached)
                    Debugger.Break();
                Console.WriteLine(e);
            }
            finally
            {
                try { CultureAndRegionInfoBuilder.Unregister(customCultureLanguageCode); }
                catch { }
            }
        }

        private static void DisplayCultureAndRegionInfoBuilderInformation(CultureAndRegionInfoBuilder cib)
        {
// Display some of the properties of the CultureAndRegionInfoBuilder object.
            Console.WriteLine("CultureName:. . . . . . . . . . {0}", cib.CultureName);
            Console.WriteLine("CultureEnglishName: . . . . . . {0}", cib.CultureEnglishName);
            Console.WriteLine("CultureNativeName:. . . . . . . {0}", cib.CultureNativeName);
            Console.WriteLine("GeoId:. . . . . . . . . . . . . {0}", cib.GeoId);
            Console.WriteLine("IsMetric: . . . . . . . . . . . {0}", cib.IsMetric);
            Console.WriteLine("ISOCurrencySymbol:. . . . . . . {0}", cib.ISOCurrencySymbol);
            Console.WriteLine("RegionEnglishName:. . . . . . . {0}", cib.RegionEnglishName);
            Console.WriteLine("RegionName: . . . . . . . . . . {0}", cib.RegionName);
            Console.WriteLine("RegionNativeName: . . . . . . . {0}", cib.RegionNativeName);
            Console.WriteLine("ThreeLetterISOLanguageName: . . {0}", cib.ThreeLetterISOLanguageName);
            Console.WriteLine("ThreeLetterISORegionName: . . . {0}", cib.ThreeLetterISORegionName);
            Console.WriteLine("ThreeLetterWindowsLanguageName: {0}", cib.ThreeLetterWindowsLanguageName);
            Console.WriteLine("ThreeLetterWindowsRegionName: . {0}", cib.ThreeLetterWindowsRegionName);
            Console.WriteLine("TwoLetterISOLanguageName: . . . {0}", cib.TwoLetterISOLanguageName);
            Console.WriteLine("TwoLetterISORegionName: . . . . {0}", cib.TwoLetterISORegionName);
            Console.WriteLine();
        }

        private static void DisplayCultureInformation(CultureInfo ci)
        {
            Console.WriteLine("Name: . . . . . . . . . . . . . {0}", ci.Name);
            Console.WriteLine("EnglishName:. . . . . . . . . . {0}", ci.EnglishName);
            Console.WriteLine("NativeName: . . . . . . . . . . {0}", ci.NativeName);
            Console.WriteLine("TwoLetterISOLanguageName: . . . {0}", ci.TwoLetterISOLanguageName);
            Console.WriteLine("ThreeLetterISOLanguageName: . . {0}", ci.ThreeLetterISOLanguageName);
            Console.WriteLine("ThreeLetterWindowsLanguageName: {0}", ci.ThreeLetterWindowsLanguageName);
            Console.WriteLine();
        }

        private static void DisplayRegionInformation(RegionInfo ri)
        {
            Console.WriteLine("Name: . . . . . . . . . . . . . {0}", ri.Name);
            Console.WriteLine("DisplayName:  . . . . . . . . . {0}", ri.DisplayName);
            Console.WriteLine("EnglishName:  . . . . . . . . . {0}", ri.EnglishName);
            Console.WriteLine("NativeName: . . . . . . . . . . {0}", ri.NativeName);
            Console.WriteLine("ThreeLetterISORegionName: . . . {0}", ri.ThreeLetterISORegionName);
            Console.WriteLine("ThreeLetterWindowsRegionName: . {0}", ri.ThreeLetterWindowsRegionName);
            Console.WriteLine("TwoLetterISORegionName: . . . . {0}", ri.TwoLetterISORegionName);
            Console.WriteLine();
        }
    }
}

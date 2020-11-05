using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace GFrame.AssetPreprocessor
{
    public class AssetPreprocessorUtils
    {
        /// <summary>
        /// Checks if any regex strings in the list match the target string.
        /// </summary>
        /// <param name="regexStringList">List of regex strings.</param>
        /// <param name="targetString">Target string to compare the list of regex strings against.</param>
        /// <returns>Whether any regex strings in the list match the target string.</returns>
        public static bool DoesRegexStringListMatchString(List<string> regexStringList, string targetString)
        {
            var match = regexStringList.Find(regexString =>
            {
                //.*\w*.fbx
                //Assets/0Demo/Chr_ArmLowerLeft_Female_00_Static 8.fbx
                // https://stackoverflow.com/questions/15275718/regular-expression-wildcard
                //regexString = Regex.Escape(regexString).Replace("\\*", ".*?");
                // Debug.LogError(regexString + "---" + targetString + new Regex(regexString).IsMatch(targetString));
                return new Regex(regexString).IsMatch(targetString);
            });

            return match != null;
        }
    }
}

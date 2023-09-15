using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoCutter.Util
{
   public static class CommaSeperatedToListOfString
    {
        /// <summary>
        /// usage  string tagsFromTextBox = "one,two,three, sdfsdf";   List<string> tagList = tagsFromTextBox.SplitAndClean(',');
        /// </summary>
        /// <param name="input"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static List<string> SplitAndClean(this string input, char separator)
        {
            return input.Split(separator)
                .Select(entry => entry.Trim())
                .Where(entry => !string.IsNullOrWhiteSpace(entry))
                .ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Admin.Helpers
{
    public static class KeyEventsHelper
    {
        /// <summary>
        /// Pass the object and the argument to avoid the char typing, allow only numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DontAllowToTypeChars(object sender, KeyPressEventArgs e)
        {
            var keyPressed = e.KeyChar;

            bool isAlphaBet = Regex.IsMatch(keyPressed.ToString(), "[a-z]", RegexOptions.IgnoreCase);

            if (isAlphaBet)
                e.Handled = true;
        }

        public static void DontAllowToWriteMoreThan(object sender, KeyPressEventArgs e, int size)
        {
            var textBox = sender as TextBox;

            if(textBox.Text.Count() >= size)
                e.Handled = true;
        }
    }
}

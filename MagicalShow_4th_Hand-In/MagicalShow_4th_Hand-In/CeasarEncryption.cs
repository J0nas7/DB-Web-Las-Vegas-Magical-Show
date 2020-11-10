using System;
namespace MagicalShow_4th_HandIn
{
    public class CeasarEncryption
    {
        public static string Encrypt(string text, int shift = 12)
        {
            var result = "";

            var firstChar = 'A';
            var offset = ('z' - 'A') + 1;

            foreach (var c in text)
            {
                var newChar = ' ';

                if (c != ' ')
                {
                    var oldIndexInAlphabet = c - firstChar;

                    var indexShifted = oldIndexInAlphabet + shift;
                    while (indexShifted < 0) indexShifted = offset + indexShifted;

                    var newIndexInAlphabet = indexShifted % offset;

                    newChar = (char)(firstChar + newIndexInAlphabet);
                }

                result += newChar;
            }

            return result.ToLower();
        }
    }
}

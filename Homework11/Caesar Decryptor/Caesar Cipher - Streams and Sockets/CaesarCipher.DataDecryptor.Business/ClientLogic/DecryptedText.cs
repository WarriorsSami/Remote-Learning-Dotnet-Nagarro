using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaesarCipher.DataDecryptor.Business.ClientLogic
{
    public class DecryptedText
    {
        public char[] DecryptedChars { get; }

        public DecryptedText(string text)
        {
            DecryptedChars = Encode(text.ToCharArray());
        }

        public DecryptedText(char[] chars)
        {
            DecryptedChars = Encode(chars);
        }

        private static char[] Encode(IEnumerable<char> chars)
        {
            return chars
                .Select(Encode)
                .ToArray();
        }

        private static char Encode(char c)
        {
            if (char.IsLetter(c))
            {
                if (char.IsLower(c))
                {
                    if (c == 'a')
                        return 'z';

                    int code = c;
                    code--;
                    return (char)code;
                }

                if (char.IsUpper(c))
                {
                    if (c == 'A')
                        return 'Z';

                    int code = c;
                    code--;
                    return (char)code;
                }
            }

            return c;
        }

        public byte[] ToBytes(Encoding encoding)
        {
            return encoding.GetBytes(DecryptedChars);
        }
    }
}
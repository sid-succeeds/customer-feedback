using System.Text;

namespace cfms_web_api.Services
{
    public class PasswordHasher
    {
        private const int key = 6;
        private const int columns = 8;

        public static string HashPassword(string plaintext)
        {
            // Apply Caesar cipher encryption
            string caesarEncrypted = CaesarCipher(plaintext, key);

            // Calculate number of rows needed for transposition
            int rows = (int)Math.Ceiling((double)caesarEncrypted.Length / columns);

            // Create a matrix to store characters for transposition
            char[,] matrix = new char[rows, columns];

            // Fill matrix with characters from the Caesar encrypted text
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (index < caesarEncrypted.Length)
                    {
                        matrix[i, j] = caesarEncrypted[index];
                        index++;
                    }
                    else
                    {
                        matrix[i, j] = ' '; // Padding with space if necessary
                    }
                }
            }

            // Read characters from the matrix column-wise to get the transposed text
            StringBuilder transposedText = new StringBuilder();
            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    transposedText.Append(matrix[i, j]);
                }
            }

            return transposedText.ToString();
        }

        static string CaesarCipher(string input, int key)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    char shifted = (char)(c + key);

                    if ((char.IsLower(c) && shifted > 'z') || (char.IsUpper(c) && shifted > 'Z'))
                    {
                        shifted = (char)(c + key - 26);
                    }
                    else if ((char.IsLower(c) && shifted < 'a') || (char.IsUpper(c) && shifted < 'A'))
                    {
                        shifted = (char)(c + key + 26);
                    }

                    result.Append(shifted);
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }
    }
}
namespace Grammar
{
    /// <summary>
    /// Class provides methods for working with plural form of the words.
    /// </summary>
    public static class Plural
    {
        /// <summary>
        /// Method of converting singular form of the word to plural form that word.
        /// </summary>
        /// <param name="singular">Argument represents singular form of the word.</param>
        /// <returns></returns>
        public static string Convert(string singular)
        {
            //TODO: to implement proper formation of plural.

            var result = $"{singular}s";

            return result;
        }
    }
}

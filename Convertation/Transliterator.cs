using Network;
using System.Collections.Generic;

namespace Convertation
{
    public class Transliterator
    {
        private readonly Dictionary<string, string> dictionary;

        public delegate void MessageHandler(string message);
        public event MessageHandler TransliterationCompleet;

        public Transliterator(Client client)
        {
            client.MessageReceived += (message) => Transliterate(message);
            dictionary = new Dictionary<string, string>()
            {
                ["А"] = "A",
                ["Б"] = "B",
                ["В"] = "V",
                ["Г"] = "G",
                ["Д"] = "D",
                ["Е"] = "E",
                ["Ё"] = "E",
                ["Ж"] = "ZH",
                ["З"] = "Z",
                ["И"] = "I",
                ["Й"] = "Y",
                ["К"] = "K",
                ["Л"] = "L",
                ["М"] = "M",
                ["Н"] = "N",
                ["О"] = "O",
                ["П"] = "P",
                ["Р"] = "R",
                ["С"] = "S",
                ["Т"] = "T",
                ["У"] = "U",
                ["Ф"] = "F",
                ["Х"] = "H",
                ["Ц"] = "C",
                ["Ч"] = "CH",
                ["Ш"] = "SH",
                ["Щ"] = "SH'",
                ["Ъ"] = "'",
                ["Ы"] = "I",
                ["Ь"] = "",
                ["Э"] = "E",
                ["Ю"] = "YU",
                ["Я"] = "YA",
                ["а"] = "a",
                ["б"] = "b",
                ["в"] = "v",
                ["г"] = "g",
                ["д"] = "d",
                ["е"] = "e",
                ["ё"] = "e",
                ["ж"] = "zh",
                ["з"] = "z",
                ["и"] = "i",
                ["й"] = "y",
                ["к"] = "k",
                ["л"] = "l",
                ["м"] = "m",
                ["н"] = "n",
                ["о"] = "o",
                ["п"] = "p",
                ["р"] = "r",
                ["с"] = "s",
                ["т"] = "t",
                ["у"] = "u",
                ["ф"] = "f",
                ["х"] = "h",
                ["ц"] = "c",
                ["ч"] = "ch",
                ["ш"] = "sh",
                ["щ"] = "sh'",
                ["ъ"] = "'",
                ["ы"] = "i",
                ["ь"] = "",
                ["э"] = "e",
                ["ю"] = "yu",
                ["я"] = "ya"
            };
        }

        private void Transliterate(string message)
        {
            foreach (var item in dictionary)
            {
                message.Replace(item.Key, item.Value);
            }
            TransliterationCompleet?.Invoke(message);
        }
    }
}

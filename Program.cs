using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keyTranslator
{
    class Program
    {
        static void Main(string[] args)
        {

            byte option_start, option_trans, option_retrans;
            char option_trans_new, option_retrans_new;
            string[] sentence, translatedSentence;
            int[] key;

        start:
            Console.Clear();

            Console.WriteLine("---------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Private Message Translator 2000");
            Console.ResetColor();
            Console.WriteLine("---------------------------------");

            Console.WriteLine();
            Console.WriteLine("[1] Eine Nachricht verschlüsseln");
            Console.WriteLine("[2] Eine verschlüsselte Nachricht entschlüsseln");
            Console.WriteLine("[3] Beenden");
            Console.WriteLine();

            input_option_start:
            Console.Write("Eingabe: ");
            option_start = Convert.ToByte(Console.ReadLine());

            switch (option_start)
            {
                case 1:
                    goto translateMessage;
                    break;
                case 2:
                    goto reTranslateMessage;
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    goto input_option_start;
                    break;
            }


        translateMessage:
            Console.Clear();

            Console.WriteLine("---------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Eine Nachricht verschlüsseln");
            Console.ResetColor();
            Console.WriteLine("---------------------------------");

            Console.WriteLine();
            Console.WriteLine("[1] Eine Nachricht eingebn");
            Console.WriteLine("[2] Zum Hauptmenü zurück");
            Console.WriteLine("[3] Beenden");
            Console.WriteLine();

            input_option_trans:
            Console.Write("Eingabe: ");
            option_trans = Convert.ToByte(Console.ReadLine());

            switch (option_trans)
            {
                case 1:
                    goto input_sentence;
                    break;
                case 2:
                    goto start;
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    goto input_option_trans;
                    break;
            }

        input_sentence:
            Console.WriteLine();
            sentence = wordsInput();
            translatedSentence = new string[sentence.Length];
            key = KeyGenerator();

            translatedSentence = Translate(sentence, key);

            Console.WriteLine();
            Console.WriteLine("Dein neuer Satz: ");

            for (int i = 0; i < translatedSentence.Length; i++)
            {
                Console.Write(translatedSentence[i] + " ");
            }


        input_translate_new:
            Console.WriteLine();
            Console.Write("Einen neuen Satz eingeben [y/N]? ");
            option_trans_new = Convert.ToChar(Console.ReadLine());

            switch (option_trans_new)
            {
                case 'y':
                    goto input_sentence;
                    break;
                case 'N':
                    goto start;
                    break;
                default:
                    goto input_translate_new;
                    break;
            }



        reTranslateMessage:
            Console.Clear();

            Console.WriteLine("-----------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Eine verschlüsselte Nachricht entschlüsseln");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------");

            Console.WriteLine();
            Console.WriteLine("[1] Einen Code eingeben");
            Console.WriteLine("[2] Zum Hauptmenü zurück");
            Console.WriteLine("[3] Beenden");
            Console.WriteLine();

            input_option_retrans:
            Console.Write("Eingabe: ");
            option_retrans = Convert.ToByte(Console.ReadLine());

            switch (option_retrans)
            {
                case 1:
                    goto input_code;
                    break;
                case 2:
                    goto start;
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    goto input_option_retrans;
                    break;
            }

            input_code:
            Console.WriteLine();
            sentence = wordsInput();
            translatedSentence = new string[sentence.Length];
            key = KeyGenerator();

            translatedSentence = ReTranslate(sentence, key);

            Console.WriteLine();
            Console.WriteLine("Dein neuer Satz: ");

            for (int i = 0; i < translatedSentence.Length; i++)
            {
                Console.Write(translatedSentence[i] + " ");
            }
            Console.WriteLine();


        input_retranslate_new:
            Console.WriteLine();
            Console.Write("Einen neuen Satz eingeben [y/N]? ");
            option_trans_new = Convert.ToChar(Console.ReadLine());

            switch (option_trans_new)
            {
                case 'y':
                    goto input_sentence;
                    break;
                case 'N':
                    goto start;
                    break;
                default:
                    goto input_retranslate_new;
                    break;
            }

        }

        static int[] KeyGenerator()
        {
            Console.Write("Gebe die Länge deines Keys ein: ");
            int lengthOfKey = Convert.ToInt32(Console.ReadLine());

            int[] key = new int[lengthOfKey];

            for (int i = 0; i < lengthOfKey; i++)
            {
                Console.Write("{0}. Zeichen: ", i + 1);
                key[i] = Convert.ToInt32(Console.ReadLine());
            }

            return key;
        }

        static string[] Translate(string[] input, int[] key)
        {
            char[] alphabet = new char[26]
            {
                'a',
                'b',
                'c',
                'd',
                'e',
                'f',
                'g',
                'h',
                'i',
                'j',
                'k',
                'l',
                'm',
                'n',
                'o',
                'p',
                'q',
                'r',
                's',
                't',
                'u',
                'v',
                'w',
                'x',
                'y',
                'z'
            };
            int keyPointer = 0, newIndex, index;
            string word = "";
            string newWord = "";
            string[] newSentence = new string[input.Length];
            char searchChar;

            for (int i = 0; i < input.Length; i++)
            {

                word = input[i].ToLower();

                for (int j = 0; j < word.Length; j++)
                {
                    if (keyPointer == key.Length)
                    {
                        keyPointer = 0;
                    }

                    searchChar = word[j];
                    index = Array.IndexOf(alphabet, searchChar);
                    newIndex = index + key[keyPointer];

                    if (alphabet.Length - newIndex < 0)
                    {
                        newIndex -= alphabet.Length;
                    }
                    if(newIndex > alphabet.Length-1)
                    {
                        newIndex -= alphabet.Length;
                    }


                    newWord += alphabet[newIndex];

                    keyPointer++;

                }
                
                newSentence[i] = newWord;
                newWord = "";
            }

            return newSentence;

        }

        static string[] ReTranslate(string[] input, int[] key)
        {
            char[] alphabet = new char[26]
            {
                'a',
                'b',
                'c',
                'd',
                'e',
                'f',
                'g',
                'h',
                'i',
                'j',
                'k',
                'l',
                'm',
                'n',
                'o',
                'p',
                'q',
                'r',
                's',
                't',
                'u',
                'v',
                'w',
                'x',
                'y',
                'z'
            };
            int keyPointer = 0, newIndex, index;
            string word = "";
            string newWord = "";
            string[] newSentence = new string[input.Length];
            char searchChar;


            for (int i = 0; i < input.Length; i++)
            {

                word = input[i].ToLower();

                for (int j = 0; j < word.Length; j++)
                {

                    if (keyPointer == key.Length)
                    {
                        keyPointer = 0;
                    }

                    searchChar = word[j];
                    index = Array.IndexOf(alphabet, searchChar);
                    newIndex = index - key[keyPointer];
                    if (newIndex < 0)
                    {
                        newIndex += alphabet.Length;
                    }


                    newWord += alphabet[newIndex];

                    keyPointer++;

                }
                newSentence[i] = newWord;
                newWord = "";
            }

            return newSentence;

        }

        static string[] wordsInput()
        {
            Console.Write("Gebe einen Satz ein: ");
            string sentence = Console.ReadLine();
            String[] words = sentence.Split(' ');

            return words;
        }



    }
}

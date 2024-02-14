using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace lab1
{
    class Program
    {

        static void Main(string[] args)
        {

            var inputString = "(^A+B)(D+E)(B^C+^BC)(CD+^C^D)(^E+AD)";
            var terms = inputString.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var resultArguments = terms[1].Split(new[] { '+', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int counter = 0;

            while (true)
            {
                if (terms.Count == 0)
                    break;

                var nexTermArguments = terms[0].Split(new[] { '+', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var newResultArguments = new List<string>();

                foreach (var argument1 in resultArguments)
                {
                    foreach (var argument2 in nexTermArguments)
                    {
                        var newArgument = argument1 + argument2;
                        newResultArguments.Add(newArgument);
                    }
                }

                resultArguments = newResultArguments;



                terms.Remove(terms[0]);
                counter++;
                if (counter == 1)
                {
                    if (terms.Count > 0)
                        terms.Remove(terms[0]);
                }
            }

            var sb = new StringBuilder();


            for (var i = 0; i < resultArguments.Count; i++)
            {
                var argument = resultArguments[i];
                sb.Append(" " + argument);
                if (i + 1 != resultArguments.Count) sb.Append(" +");
            }

            //Console.WriteLine(sb.ToString());*/

            var str = sb.ToString();
            var expression = str.Split(new[] { '+', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < expression.Count; i++)
            {
                string buff = expression[i];
                foreach (char el in buff) //буковки
                {
                    string otricanie = "^" + el;
                    if (buff.Contains(otricanie))
                    {
                        buff = buff.Remove(buff.IndexOf('^'), 2);
                        if (buff.Contains(el))
                        {
                            expression[i] = "0";
                        }
                    }

                }

            }
            for (int i = 0; i < expression.Count; i++)
            {
                if (expression[i] != "0")
                {
                    var argument = expression[i];
                    sb.Append(argument);
                    for (int k = 0; k < sb.Length; k++)
                    {
                        int first = -1;
                        int last = -1;
                        foreach (char ch in argument)
                        {
                            if (ch == '^') continue;
                            first = argument.IndexOf(ch);
                            last = argument.LastIndexOf(ch);
                            if (first != -1 && last != -1 && first != last)
                                argument = argument.Replace(ch.ToString(), "").Insert(k, ch.ToString());
                        }
                    }
                    Console.WriteLine("Результат: " + argument + "\n\n" + "Расшифровка:");
                    foreach (char el in argument)
                    {
                        if (el == '^') continue;
                        else
                        {
                            string otricanie = "^" + el;
                            if (argument.Contains(otricanie))
                            {
                                Console.WriteLine(el + " не смотрит телевизор");
                            }
                            else Console.WriteLine(el + " смотрит телевизор");
                        }
                    }
                }

            }
            Console.ReadLine();
        }
    }
}


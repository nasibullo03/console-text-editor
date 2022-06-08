using System;
using System.Collections.Generic;

class TextEditor
{
    /// <summary>
    /// Изменить текст
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string Edit(string text)
    {
        return ReadLine(text);
    }

    private static void GoToDefautPosition(List<char> chars, int defPosX, int startPosition, int defPosY = 0)
    {
        if (defPosY == 0)
        {
            if (startPosition < 0) startPosition = 0;
            if (startPosition < chars.Count)
            {
                for (int i = startPosition; i < chars.Count; ++i)
                    Console.Write(chars[i]);
            }

        }
        else
        {
            int textBuferSize = Console.BufferWidth * (defPosY + 1);
            int lastColumnFilledSpace = (chars.Count + 7) % Console.BufferWidth;
            int lastColumnEmptySpace = Console.BufferWidth - lastColumnFilledSpace;
            int lastColumnEndTextPosiotion = textBuferSize - lastColumnEmptySpace;

            startPosition = lastColumnEndTextPosiotion - (lastColumnFilledSpace - startPosition);
            if (startPosition < chars.Count)
            {
                for (int i = startPosition; i < chars.Count; ++i)
                    Console.Write(chars[i]);
            }
        }



        Console.SetCursorPosition(++defPosX, defPosY);

    }

    private static string ReadLine(string Default)
    {
        int pos = Console.CursorLeft, defPos = Console.CursorLeft;
        bool CursorLeftZero = false;
        Console.Write(Default);
        ConsoleKeyInfo info;
        List<Char> chars = new List<char>();
        if (string.IsNullOrEmpty(Default) == false)
        {
            chars.AddRange(Default.ToCharArray());
        }
        while (true)
        {

            info = Console.ReadKey();

            if ((info.Key == ConsoleKey.Backspace) && (Console.CursorLeft >= 0) && chars.Count != 0 && ((Console.CursorTop == 0 && Console.CursorLeft > 6) || Console.CursorTop > 0))
            {
                if (Console.CursorLeft == 0 && !CursorLeftZero)
                {
                    chars.RemoveAt(chars.Count - 1);
                    Console.Write(' ');
                    Console.CursorLeft -= 1;
                    CursorLeftZero = true;
                }
                else if (Console.CursorLeft == 0)
                {
                    chars.RemoveAt(chars.Count - 1);
                    Console.CursorTop -= 1;
                    Console.CursorLeft = Console.BufferWidth - 1;
                    Console.Write(' ');
                    Console.CursorLeft = Console.BufferWidth - 1;
                    Console.CursorTop -= 1;
                    CursorLeftZero = false;

                }
                else
                {
                    chars.RemoveAt(chars.Count - 1);
                    Console.Write(' ');
                    Console.CursorLeft -= 1;
                }

            }
            else if ((info.Key == ConsoleKey.Backspace) && (Console.CursorTop >= 0 && Console.CursorLeft < 7))
            {
                Console.CursorLeft += 1;
            }
            else if (info.Key == ConsoleKey.Enter)
            {
                Console.SetCursorPosition(Console.BufferWidth - 1, (int)((chars.Count + 7) / Console.BufferWidth));
                Console.Write(Environment.NewLine);
                break;
            }
            ///------------RIGHT------------
            else if (info.Key == ConsoleKey.RightArrow)
            {

                void GoDown()
                {
                    Console.CursorLeft = Console.BufferWidth - 3;
                    defPos = Console.CursorLeft;
                    GoToDefautPosition(chars, defPos - 1, defPos - 7, defPosY: (Console.CursorTop == 0) ? 0 : --Console.CursorTop);
                    Console.CursorTop++;
                    Console.CursorLeft = 0;
                }

                int lastColumnFilledSpace = (chars.Count + 7) % Console.BufferWidth;

                if ((Console.CursorTop == (int)((chars.Count + 7) / Console.BufferWidth) && Console.CursorLeft <= lastColumnFilledSpace + 1)
                    || Console.CursorTop <= (int)((chars.Count + 7) / Console.BufferWidth))
                {
                    if (Console.CursorTop == (int)((chars.Count + 7) / Console.BufferWidth))
                    {
                        if (Console.CursorLeft >= lastColumnFilledSpace)
                        {
                            --Console.CursorLeft;
                            continue;
                        }
                    }
                    if (Console.CursorLeft == 0)
                    {
                        GoDown();
                    }
                    else
                    {
                        Console.CursorLeft -= (Console.CursorLeft <= 0) ? 0 : 1;
                        defPos = Console.CursorLeft;
                        GoToDefautPosition(chars, defPos - 1, defPos - 7, defPosY: Console.CursorTop);
                        Console.CursorLeft += 1;
                    }
                }
                else if (Console.CursorTop <= (int)((chars.Count + 7) / Console.BufferWidth))
                {
                    defPos = Console.CursorLeft - 1;
                    GoToDefautPosition(chars, defPos, defPos - 7, defPosY: Console.CursorTop);
                    --Console.CursorLeft;
                }
                else if (Console.CursorTop == (int)((chars.Count + 7) / Console.BufferWidth + 1))
                {
                    --Console.CursorTop;
                    Console.CursorLeft = Console.BufferWidth - 1;
                }

            }
            ///------------LEFT------------
            else if (info.Key == ConsoleKey.LeftArrow)
            {
                void GoToUP()
                {
                    Console.CursorLeft = Console.BufferWidth - 1;
                    Console.CursorTop -= (Console.CursorTop > 0) ? 1 : 0;
                    defPos = Console.CursorLeft;
                    GoToDefautPosition(chars, defPos - 1, defPos - 7, defPosY: Console.CursorTop);
                    --Console.CursorLeft;
                }
                if (Console.CursorLeft > 8 && Console.CursorTop == 0)
                {
                    Console.CursorLeft -= (Console.CursorLeft - 2 <= 0) ? 0 : 2;
                    defPos = Console.CursorLeft;
                    GoToDefautPosition(chars, defPos - 1, defPos - 7, defPosY: Console.CursorTop);

                }
                else if (Console.CursorTop > 0)
                {
                    if (Console.CursorLeft == 0)
                    {
                        GoToUP();
                    }
                    else
                    {
                        try
                        {
                            Console.CursorLeft -= 1;
                        }
                        catch
                        {

                            Console.CursorLeft = Console.BufferWidth - 1;
                            Console.CursorTop -= (Console.CursorTop > 0) ? 1 : 0;
                        }
                        finally
                        {
                            defPos = Console.CursorLeft;
                            GoToDefautPosition(chars, defPos - 1, defPos - 7, defPosY: Console.CursorTop);

                            if (Console.CursorLeft - 1 < 0) GoToUP();
                            else --Console.CursorLeft;
                        }
                    }

                }
                else
                {
                    Console.CursorLeft -= 1;
                    defPos = Console.CursorLeft;
                    GoToDefautPosition(chars, defPos - 1, defPos - 7, defPosY: Console.CursorTop);
                }

            }
            ///------------UP------------
            else if (info.Key == ConsoleKey.UpArrow)
            {
                int CursorTop = Console.CursorTop;
                if (CursorTop == 0)
                {
                    defPos = --Console.CursorLeft;
                    GoToDefautPosition(chars, defPos - 1, defPos - 7, defPosY: Console.CursorTop);
                }
                else
                {

                    Console.CursorLeft = (Console.CursorTop - 1 == 0) ? (Console.CursorLeft < 8) ? 7 : Console.CursorLeft : Console.CursorLeft;
                    --Console.CursorTop;
                    defPos = Console.CursorLeft;
                    GoToDefautPosition(chars, defPos - 2, defPos - 7, defPosY: Console.CursorTop);
                }
                if (Console.CursorLeft < 7 && Console.CursorTop == 0)
                {
                    Console.CursorLeft = 7;
                }

            }
            ///------------DOWN------------
            else if (info.Key == ConsoleKey.DownArrow)
            {
                int CursorTop = Console.CursorTop;
                int textBuferSize = Console.BufferWidth * (Console.CursorTop + 1);
                int lastColumnFilledSpace = (chars.Count + 7) % Console.BufferWidth;

                if (CursorTop == (int)((chars.Count + 7) / Console.BufferWidth - 1) && Console.CursorLeft >= lastColumnFilledSpace)
                {
                    Console.CursorLeft = lastColumnFilledSpace;
                    GoToDefautPosition(chars, Console.CursorLeft - 1, Console.CursorLeft - 7, defPosY: Console.CursorTop);
                    ++Console.CursorTop;
                }
                else if (CursorTop == (int)((chars.Count + 7) / Console.BufferWidth) && Console.CursorLeft >= lastColumnFilledSpace)
                {
                    Console.CursorLeft = lastColumnFilledSpace;
                    GoToDefautPosition(chars, Console.CursorLeft - 1, Console.CursorLeft - 7, defPosY: Console.CursorTop);
                }
                else
                {
                    Console.SetCursorPosition((Console.CursorLeft == 0) ? 0 : Console.CursorLeft - 1, Console.CursorTop);
                    defPos = Console.CursorLeft;
                    GoToDefautPosition(chars, defPos, defPos - 7, defPosY: Console.CursorTop);
                    defPos = Console.CursorLeft;
                    Console.SetCursorPosition(Console.CursorLeft, ++Console.CursorTop);
                    GoToDefautPosition(chars, defPos - 2, defPos - 7, defPosY: Console.CursorTop);

                }
            }
            else if (char.IsLetterOrDigit(info.KeyChar) ||
                char.IsWhiteSpace(info.KeyChar) ||
                char.IsSeparator(info.KeyChar) ||
                char.IsSymbol(info.KeyChar) ||
                char.IsPunctuation(info.KeyChar) ||
                char.IsSurrogate(info.KeyChar))
            {
                int letterPosition = Console.CursorLeft;
                GoToDefautPosition(chars, letterPosition - 1, letterPosition - 8, defPosY: Console.CursorTop);

                if (Console.CursorTop == 0) chars.Insert(letterPosition - 8, info.KeyChar);
                else
                {

                    int textBuferSize = Console.BufferWidth * (Console.CursorTop + 1);
                    int lastColumnFilledSpace = (chars.Count + 7) % Console.BufferWidth;
                    int lastColumnEmptySpace = Console.BufferWidth - lastColumnFilledSpace;
                    int lastColumnEndTextPosiotion = textBuferSize - lastColumnEmptySpace;

                    letterPosition -= 8;
                    letterPosition = lastColumnEndTextPosiotion - (lastColumnFilledSpace - letterPosition);
                    chars.Insert(letterPosition, info.KeyChar);
                }
            }
        }
        return new string(chars.ToArray());
    }
}

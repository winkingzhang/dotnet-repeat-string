using System.Text;

namespace org.zhangwenqing.stringutils;

public static class Repeat
{
    public static string RepeatByStringBuilder(this string text, uint n)
    {
        return new StringBuilder(text.Length * (int)n)
            .Insert(0, text, (int)n)
            .ToString();
    }

    public static string RepeatByLinq(this string text, uint n)
    {
        return string.Concat(Enumerable.Repeat(text, (int)n));
    }

    public static string RepeatByArray(this string text, uint n)
    {
        var arr = new char[text.Length * (int)n];
        for (var i = 0; i < n; i++)
        {
            text.CopyTo(0, arr, i * text.Length, text.Length);
        }

        return new string(arr);
    }

    public static string RepeatByArrayFill(this string text, uint n)
    {
        var arr = new string[(int)n];
        Array.Fill(arr, text);
        return string.Concat(arr);
    }

    public static string RepeatBySpan(this string text, uint n)
    {
        var textAsSpan = text.AsSpan();
        var resultSpan = new Span<char>(new char[textAsSpan.Length * (int)n]);

        for (var i = 0; i < n; i++)
        {
            textAsSpan.CopyTo(resultSpan.Slice(i * textAsSpan.Length, textAsSpan.Length));
        }

        return resultSpan.ToString();
    }
}
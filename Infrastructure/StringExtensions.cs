public static class StringExtensions
{
    public static int VowelCount(this string text)
    {
            return text.Count(x=>x == 'a' || x=='y');
    }


}
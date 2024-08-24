using StreamReader reader = new StreamReader(args[0]);
Interpret(reader.ReadToEnd());
Console.Read();

static void Interpret(string code)
{
    var m = new byte[30000];
    int p = 0, l = code.Length;
    for (int i = 0; i < l; i++)
    {
        switch (code[i])
        {
            case '>': p++; break;
            case '<': p--; break;
            case '+': m[p]++; break;
            case '-': m[p]--; break;
            case '.': Console.Write((char)m[p]); break;
            case ',': m[p] = (byte)Console.Read(); break;
            case '[': if (m[p] == 0) i = code.IndexOf(']', i); break;
            case ']': if (m[p] != 0) i = code.LastIndexOf('[', i); break;
        }
    }
}
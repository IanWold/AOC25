var banks = Array.Empty<int[]>();
using (var reader = new StreamReader("input")){
    banks = [..
        reader.ReadToEnd().Split("\r\n").Select(b => b.ToCharArray().Select(c => Convert.ToInt32(c.ToString())).ToArray())
    ];
}

Console.WriteLine(banks.Sum(b => {
    var largestFirst = b[..^1].Max();
    var largestLast = b.Skip(b.IndexOf(largestFirst) + 1).Max();
    return Convert.ToInt32($"{largestFirst}{largestLast}");
}));